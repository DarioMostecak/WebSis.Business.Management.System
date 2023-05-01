namespace WebSis.Business.Managmant.Api.Models.Contacts
{
    public class Contact
    {
        public Guid ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; } //Nullable
        public string Email { get; set; }
        public string Note { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
