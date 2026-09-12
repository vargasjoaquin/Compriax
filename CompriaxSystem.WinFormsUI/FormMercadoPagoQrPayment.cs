using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;
using System.Media;
using System.Text.Json;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormMercadoPagoQrPayment : Form
    {
        private readonly IBarcodeService _barcodeService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _orderId;
        private readonly decimal _totalAmount;
        private readonly string _qrData;
        private readonly string _apiBaseUrl;

        private System.Windows.Forms.Timer? _pollingTimer;
        private bool _isCheckingStatus = false;

        public bool IsPaymentApproved { get; private set; } = false;

        public FormMercadoPagoQrPayment(IBarcodeService barcodeService, IHttpClientFactory httpClientFactory, string orderId, decimal totalAmount, string qrData, string apiBaseUrl = "https://localhost:7133")
        {
            _barcodeService = barcodeService;
            _httpClientFactory = httpClientFactory;
            _orderId = orderId;
            _totalAmount = totalAmount;
            _qrData = qrData;
            _apiBaseUrl = apiBaseUrl.TrimEnd('/');

            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(pnlCard);

            this.Load += async (s, e) => await InitializePaymentViewAsync();
            this.btnCancel.Click += async (s, e) => await CancelPaymentAsync();
            this.FormClosing += (s, e) => StopPolling();
        }

        private async Task InitializePaymentViewAsync()
        {
            lblAmount.Text = _totalAmount.ToString("C2");
            lblStatus.Text = "Esperando que el cliente escanee y pague...";
            lblStatus.ForeColor = UIThemeHelper.Primary;

            RenderQrCodeImage(_qrData);

            _pollingTimer = new System.Windows.Forms.Timer
            {
                Interval = 2500
            };

            _pollingTimer.Tick += async (s, e) =>
                await CheckPaymentStatusAsync();

            _pollingTimer.Start();

            await Task.CompletedTask;
        }

        private void RenderQrCodeImage(string qrData)
        {
            try
            {
                var barcodeWriter = new ZXing.Windows.Compatibility.BarcodeWriter
                {
                    Format = ZXing.BarcodeFormat.QR_CODE,
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Height = picQr.Height,
                        Width = picQr.Width,
                        Margin = 1
                    }
                };

                picQr.Image?.Dispose();
                picQr.Image = barcodeWriter.Write(qrData);
            }
            catch
            {
                lblStatus.Text =  "Código QR disponible (Escanee el enlace generado).";
            }
        }

        private async Task CheckPaymentStatusAsync()
        {
            if (_isCheckingStatus || IsPaymentApproved)
                return;

            _isCheckingStatus = true;

            try
            {
                var httpClient = _httpClientFactory.CreateClient();

                var paymentStatusResponse = await httpClient.GetAsync($"{_apiBaseUrl}/api/mercadopago/payments/{_orderId}");

                if (paymentStatusResponse.IsSuccessStatusCode)
                {
                    var responseContent = await paymentStatusResponse.Content.ReadAsStringAsync();

                    using var responseDocument = JsonDocument.Parse(responseContent);

                    if (responseDocument.RootElement.TryGetProperty("status", out var statusProperty))
                    {
                        string paymentStatus = statusProperty.GetString() ?? "Pending";

                        if (paymentStatus.Equals("Approved", StringComparison.OrdinalIgnoreCase))
                        {
                            StopPolling();

                            IsPaymentApproved = true;

                            SystemSounds.Asterisk.Play();

                            lblStatus.Text = "¡PAGO APROBADO EXITOSAMENTE!";

                            lblStatus.ForeColor =
                                UIThemeHelper.Success;

                            await Task.Delay(1000);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else if (paymentStatus.Equals("Rejected", StringComparison.OrdinalIgnoreCase) || paymentStatus.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
                        {
                            StopPolling();

                            lblStatus.Text = "El pago fue rechazado o cancelado por el cliente.";

                            lblStatus.ForeColor = UIThemeHelper.Danger;

                            UIHelper.WarnMessage(this, "El pago no pudo ser completado.", "Pago No Aprobado");

                            this.DialogResult = DialogResult.Cancel;
                            this.Close();
                        }
                    }
                }
            }
            catch
            {
                // Silencioso para no interrumpir el sondeo
                // si hay micro-cortes de red local.
            }
            finally
            {
                _isCheckingStatus = false;
            }
        }

        private async Task CancelPaymentAsync()
        {
            StopPolling();

            try
            {
                var httpClient = _httpClientFactory.CreateClient();

                await httpClient.PostAsync($"{_apiBaseUrl}/api/mercadopago/payments/{_orderId}/cancel", null);
            }
            catch
            {
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void StopPolling()
        {
            if (_pollingTimer != null)
            {
                _pollingTimer.Stop();
                _pollingTimer.Dispose();
                _pollingTimer = null;
            }
        }
    }
}