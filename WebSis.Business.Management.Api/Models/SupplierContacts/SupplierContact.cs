using WebSis.Business.Managmant.Api.Models.Contacts;
using WebSis.Business.Managmant.Api.Models.Suppliers;

namespace WebSis.Business.Managmant.Api.Models.SupplierContacts
{
    public class SupplierContact
    {
        public Guid SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        public Guid ContactID { get; set; }
        public Contact Contact { get; set; }
    }
}
