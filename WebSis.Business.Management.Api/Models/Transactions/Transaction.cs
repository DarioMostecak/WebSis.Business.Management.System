using WebSis.Business.Managmant.Api.Models.Warehouses;

namespace WebSis.Business.Managmant.Api.Models.Transactions
{
    public class Transaction
    {
        public Guid TransactionID { get; set; }
        public Guid WarehouseID { get; set; }
        public Warehouse Warehouse { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public string TransactionType { get; set; } // enum
        public string TransactionStatus { get; set; } //emum
        public bool TrasactionComplete { get; set; }
        public string Notes { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
