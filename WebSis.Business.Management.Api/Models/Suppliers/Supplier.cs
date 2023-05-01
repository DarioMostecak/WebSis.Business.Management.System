namespace WebSis.Business.Managmant.Api.Models.Suppliers
{
    public class Supplier
    {
        public Guid SupplierID { get; set; }
        public string SupplierCompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; } //Make ti Nullable
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
