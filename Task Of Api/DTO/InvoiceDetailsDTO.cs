using Task_Of_Api.Model;

namespace Task_Of_Api.DTO
{
    public class InvoiceDetailsDTO
    {
        public int lineNo { get; set; }
        public string productName { get; set; }
        public int UnitNo { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public Decimal total { get; set; }
        public DateTime expiryDate { get; set; }
    }
}
