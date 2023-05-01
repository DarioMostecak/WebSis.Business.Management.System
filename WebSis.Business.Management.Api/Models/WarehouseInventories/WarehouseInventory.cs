using WebSis.Business.Managmant.Api.Models.Inventories;
using WebSis.Business.Managmant.Api.Models.Warehouses;

namespace WebSis.Business.Managmant.Api.Models.WarehouseInventories
{
    public class WarehouseInventory
    {
        public Guid WarehouseID { get; set; }
        public Warehouse Warehouse { get; set; }
        public Guid InventoryID { get; set; }
        public Inventory Inventory { get; set; }
    }
}
