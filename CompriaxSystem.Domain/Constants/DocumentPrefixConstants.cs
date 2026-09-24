namespace CompriaxSystem.Domain.Constants
{
    public static class DocumentPrefixConstants
    {
        public const string DEFAULT = "FAC-X";

        // 1. Facturas y Comprobantes Directos
        public const string CASUAL_CUSTOMER = "FAC-CAS";
        public const string INVOICE_A = "FAC-A";
        public const string INVOICE_B = "FAC-B";
        public const string INVOICE_C = "FAC-C";
        public const string INVOICE_M = "FAC-M";
        public const string EXPORT_INVOICE_E = "FAC-E";

        // 2. Tickets
        public const string TICKET_INVOICE_A = "TKT-A";
        public const string TICKET_INVOICE_B = "TKT-B";
        public const string TICKET_FINAL_CONSUMER = "TKT-CF";

        // 3. Notas de Débito
        public const string DEBIT_NOTE_A = "ND-A";
        public const string DEBIT_NOTE_B = "ND-B";
        public const string DEBIT_NOTE_C = "ND-C";
        public const string DEBIT_NOTE_M = "ND-M";

        // 4. Notas de Crédito
        public const string CREDIT_NOTE_A = "NC-A";
        public const string CREDIT_NOTE_B = "NC-B";
        public const string CREDIT_NOTE_C = "NC-C";
        public const string CREDIT_NOTE_M = "NC-M";

        // 5. Recibos
        public const string RECEIPT_A = "REC-A";
        public const string RECEIPT_B = "REC-B";
        public const string RECEIPT_C = "REC-C";

        // 6. Remitos y Presupuestos
        public const string DELIVERY_NOTE_R = "REM-R";
        public const string DELIVERY_NOTE_X = "REM-X";
        public const string QUOTATION = "PRE";
        public const string VOUCHER_X = "CMP-X";
    }
}
