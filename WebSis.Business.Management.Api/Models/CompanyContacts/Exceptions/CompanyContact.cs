using WebSis.Business.Managmant.Api.Models.Companies;
using WebSis.Business.Managmant.Api.Models.Contacts;

namespace WebSis.Business.Managmant.Api.Models.CompanyContacts.Exceptions
{
    public class CompanyContact
    {
        public Guid CompanyID { get; set; }
        public Company Company { get; set; }
        public Guid ContactID { get; set; }
        public Contact Contact { get; set; }
    }
}
