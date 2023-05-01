using WebSis.Business.Managmant.Api.Models.Products;

namespace WebSis.Business.Managmant.Api.Models.Inventories
{
    public class Inventory
    {
        public Guid InventoryID { get; set; }
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int QuantityOnHand { get; set; }
        public int MinimumQuantity { get; set; }
        public int CommittedQuantity { get; set; }
        public bool IsLowQuantity { get; set; }
        public decimal CostPerItem { get; set; }
        public decimal TotalCost { get; set; }
        public float Discount { get; set; }
        public string Note { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
