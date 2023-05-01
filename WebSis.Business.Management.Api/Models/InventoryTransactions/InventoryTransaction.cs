using System.Transactions;
using WebSis.Business.Managmant.Api.Models.Inventories;

namespace WebSis.Business.Managmant.Api.Models.InventoryTransactions
{
    public class InventoryTransaction
    {
        public Guid InventoryID { get; set; }
        public Inventory Invetory { get; set; }
        public Guid TransactionID { get; set; }
        public Transaction Transaction { get; set; }
    }
}
