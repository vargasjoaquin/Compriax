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

        public FormMercadoPagoQrPayment(IBarcodeService barcodeService, IHttpClientFactory httpClientFactory, string orderId, decimal totalAmount, string qrData, string apiBaseUrl)
        {
            _barcodeService = barcodeService;
            _httpClientFactory = httpClientFactory;
            _orderId = orderId;
            _totalAmount = totalAmount;
            _qrData = qrData;
            _apiBaseUrl = apiBaseUrl.TrimEnd('/');

            InitializeComponent();
            
            ButtonIconOverlayHelper.BindEvents(this.buttonCancelPayment, this.picIconCancelPayment);
            

            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelPaymentCard);

            this.Load += async (s, e) => await InitializeMercadoPagoPaymentViewAsync();
            this.buttonCancelPayment.Click += async (s, e) => await CancelMercadoPagoPaymentOrderAsync();
            this.FormClosing += (s, e) => StopPaymentStatusPollingTimer();
        }

        private async Task InitializeMercadoPagoPaymentViewAsync()
        {
            labelAmountToPay.Text = _totalAmount.ToString("C2");
            labelPaymentStatus.Text = "Esperando que el cliente escanee y pague...";
            labelPaymentStatus.ForeColor = UIThemeHelper.Primary;

            RenderMercadoPagoQrCodeImage(_qrData);

            _pollingTimer = new System.Windows.Forms.Timer
            {
                Interval = 2500
            };

            _pollingTimer.Tick += async (s, e) =>
                await CheckMercadoPagoPaymentStatusAsync();

            _pollingTimer.Start();

            await Task.CompletedTask;
        }

        private void RenderMercadoPagoQrCodeImage(string qrData)
        {
            try
            {
                var qrBarcodeWriter = new ZXing.Windows.Compatibility.BarcodeWriter
                {
                    Format = ZXing.BarcodeFormat.QR_CODE,
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Height = pictureBoxQrCode.Height,
                        Width = pictureBoxQrCode.Width,
                        Margin = 1
                    }
                };

                pictureBoxQrCode.Image?.Dispose();
                pictureBoxQrCode.Image = qrBarcodeWriter.Write(qrData);
            }
            catch
            {
                labelPaymentStatus.Text =  "Código QR disponible (Escanee el enlace generado).";
            }
        }

        private async Task CheckMercadoPagoPaymentStatusAsync()
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
                            StopPaymentStatusPollingTimer();

                            IsPaymentApproved = true;

                            SystemSounds.Asterisk.Play();

                            labelPaymentStatus.Text = "¡PAGO APROBADO EXITOSAMENTE!";

                            labelPaymentStatus.ForeColor =
                                UIThemeHelper.Success;

                            await Task.Delay(1000);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else if (paymentStatus.Equals("Rejected", StringComparison.OrdinalIgnoreCase) || paymentStatus.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
                        {
                            StopPaymentStatusPollingTimer();

                            labelPaymentStatus.Text = "El pago fue rechazado o cancelado por el cliente.";

                            labelPaymentStatus.ForeColor = UIThemeHelper.Danger;

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

        private async Task CancelMercadoPagoPaymentOrderAsync()
        {
            StopPaymentStatusPollingTimer();

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

        private void StopPaymentStatusPollingTimer()
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










