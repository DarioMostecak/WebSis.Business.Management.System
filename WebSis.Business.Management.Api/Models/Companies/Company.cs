namespace WebSis.Business.Managmant.Api.Models.Companies
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyOwnerFirstName { get; set; }
        public string CompanyOwnerLastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string WebsiteUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string TaxIdNumber { get; set; }
        public string PaymentTerms { get; set; } //see beter
        public bool TaxExempt { get; set; }
        public string Notes { get; set; }
    }
}
