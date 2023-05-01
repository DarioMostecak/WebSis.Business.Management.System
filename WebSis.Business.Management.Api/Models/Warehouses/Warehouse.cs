namespace WebSis.Business.Managmant.Api.Models.Warehouses
{
    public class Warehouse
    {
        public Guid WarehouseID { get; set; }
        public Guid ManagerID { get; set; }
        public string WarehouseName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string? Phone2 { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
