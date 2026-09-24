namespace CompriaxSystem.Domain.Constants
{
    public static class DocumentTypeConstants
    {
        public const int CASUAL_CUSTOMER_ID = 1;
        public const int INVOICE_A_ID = 2;
        public const int INVOICE_B_ID = 6;
        public const int INVOICE_C_ID = 10;

        public const string CASUAL_CUSTOMER = "Cliente Casual";

        // A
        public const string INVOICE_A = "Factura A";
        public const string DEBIT_NOTE_A = "Nota de Débito A";
        public const string CREDIT_NOTE_A = "Nota de Crédito A";
        public const string RECEIPT_A = "Recibo A";
        public const string TICKET_INVOICE_A = "Ticket Factura A";
        
        // B
        public const string INVOICE_B = "Factura B";
        public const string DEBIT_NOTE_B = "Nota de Débito B";
        public const string CREDIT_NOTE_B = "Nota de Crédito B";
        public const string RECEIPT_B = "Recibo B";
        public const string TICKET_INVOICE_B = "Ticket Factura B";
        
        // C
        public const string INVOICE_C = "Factura C";
        public const string DEBIT_NOTE_C = "Nota de Débito C";
        public const string CREDIT_NOTE_C = "Nota de Crédito C";
        public const string RECEIPT_C = "Recibo C";
        
        // E
        public const string EXPORT_INVOICE_E = "Factura de Exportación E";
        
        // M
        public const string INVOICE_M = "Factura M";
        public const string DEBIT_NOTE_M = "Nota de Débito M";
        public const string CREDIT_NOTE_M = "Nota de Crédito M";
        
        // Consumidor final, Remito X/R, Presupuesto, Comprobante X
        public const string TICKET_FINAL_CONSUMER = "Ticket Consumidor Final";
        public const string DELIVERY_NOTE_R = "Remito R (Oficial)";
        public const string DELIVERY_NOTE_X = "Remito X (Uso Interno / No Fiscal)";
        public const string QUOTATION = "Presupuesto / Cotización";
        public const string VOUCHER_X = "Comprobante X (No Fiscal)";

        public const string INITIAL_DOCUMENT_NUMBER = "00000001";
        public const string EMPTY_DOCUMENT_NUMBER = "00000000";
        public const int DEFAULT_DOCUMENT_PADDING = 8;
    }
}
