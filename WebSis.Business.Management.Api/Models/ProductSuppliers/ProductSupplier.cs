using WebSis.Business.Managmant.Api.Models.Products;
using WebSis.Business.Managmant.Api.Models.Suppliers;

namespace WebSis.Business.Managmant.Api.Models.ProductSuppliers
{
    public class ProductSupplier
    {
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public Guid SupplierID { get; set; }
        public Supplier Supplier { get; set; }
    }
}
