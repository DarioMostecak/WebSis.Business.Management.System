using WebSis.Business.Managmant.Api.Models.Orders;
using WebSis.Business.Managmant.Api.Models.Products;

namespace WebSis.Business.Managmant.Api.Models.OrderProducts
{
    public class OrderProduct
    {
        public Guid OrderID { get; set; }
        public Order Order { get; set; }
        public Guid ProductID { get; set; }
        public Product ProductProduct { get; set; }
    }
}
