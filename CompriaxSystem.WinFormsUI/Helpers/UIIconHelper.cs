using System.Drawing.Drawing2D;

namespace CompriaxSystem.WinFormsUI.Helpers
{
    public static class UIIconHelper
    {
        public static Image? GetIcon(string resourceName, int width = 20, int height = 20)
        {
            try
            {
                object? obj = Resources.ResourceManager.GetObject(resourceName, Resources.Culture);

                if (obj == null && resourceName.Contains('-'))
                {
                    obj = Resources.ResourceManager.GetObject(resourceName.Replace('-', '_'), Resources.Culture);
                }

                if (obj is Image img)
                {
                    return ResizeImage(img, width, height);
                }
            }
            catch
            {
            }
            return null;
        }

        private static Image ResizeImage(Image original, int width, int height)
        {
            var resized = new Bitmap(width, height);
            using var g = Graphics.FromImage(resized);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawImage(original, 0, 0, width, height);
            return resized;
        }

        public static Image? IngresoManual => GetIcon("075-ingreso-manual");
        public static Image? RetiroEgreso => GetIcon("076-retiro-egreso");
        public static Image? Guardar => GetIcon("077-guardar");
        public static Image? Editar => GetIcon("078-editar");
        public static Image? Eliminar => GetIcon("079-eliminar");
        public static Image? Buscar => GetIcon("080-buscar");
        public static Image? RestaurarSeleccion => GetIcon("081-restaurar-seleccion");
        public static Image? Imprimir => GetIcon("082-imprimir");
        public static Image? EnviarMensaje => GetIcon("083-enviar-mensaje");
        public static Image? ExportarExcel => GetIcon("084-exportar-excel");
        public static Image? ExportarPdf => GetIcon("085-exportar-pdf");
        public static Image? CapturarFoto => GetIcon("086-capturar-foto");
        public static Image? CamaraEncender => GetIcon("087-camara-encender");
        public static Image? GenerarCodigo => GetIcon("088-generar-codigo");
        public static Image? EstadoActivo => GetIcon("089-estado-activo");
        public static Image? EstadoInactivo => GetIcon("090-estado-inactivo");
        public static Image? EstadoDisponible => GetIcon("091-estado-disponible");
        public static Image? Exito => GetIcon("092-exito");
        public static Image? Error => GetIcon("093-error");
        public static Image? Advertencia => GetIcon("094-advertencia");
        public static Image? BloqueoOperativo => GetIcon("095-bloqueo-operativo");
        public static Image? BloqueoCierre => GetIcon("096-bloqueo-cierre");
        public static Image? ActivacionSupervisor => GetIcon("097-activacion-supervisor");
        public static Image? VistaPreviaTicket => GetIcon("098-vista-previa-ticket");
    }
}