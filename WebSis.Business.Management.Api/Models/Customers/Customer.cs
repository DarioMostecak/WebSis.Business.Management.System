namespace WebSis.Business.Managmant.Api.Models.Customers
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string AccountStatus { get; set; }
        public decimal AccountBalance { get; set; }
        public string PaymentTerms { get; set; }
        public bool TaxExempt { get; set; }
        public string CustomerNotes { get; set; }
    }
}
