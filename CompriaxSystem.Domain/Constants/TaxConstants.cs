namespace CompriaxSystem.Domain.Constants
{
    public static class TaxConstants
    {
        public const decimal STANDARD_VAT_RATE = 21.00m;
        public const decimal STANDARD_VAR_RATE = 21.00m;
        public const int DEFAULT_POINT_OF_SALE = 1;

        public const string DEFAULT_TAX_CONDITION_NAME = "Consumidor Final";
        public const string FINAL_CONSUMER_DOCUMENT_PLACEHOLDER = "S/D";

        public const string REGISTERED_TAXPAYER = "IVA Responsable Inscripto";
        public const string TAX_EXEMPT = "IVA Sujeto Exento";
        public const string FINAL_CONSUMER = "Consumidor Final";
        public const string SIMPLIFIED_REGIME = "Responsable Monotributo";
        public const string FOREIGN_SUPPLIER = "Proveedor del Exterior";
        public const string FOREIGN_CUSTOMER = "Cliente del Exterior";

        public const int CUIT_RAW_LENGTH = 11;
        public const int CUIT_FORMATTED_LENGTH = 13;
        public const int DNI_MIN_LENGTH = 7;
        public const int DNI_MAX_LENGTH = 8;
    }
}
