namespace WebSis.Business.Managmant.Api.Models.Orders
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public string Status { get; set; }
        public string PromoCode { get; set; }
        public string PaymentMethod { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public bool IsRepeatCustomer { get; set; }
        public decimal TotalAmaunt { get; set; }
        public decimal TotalAmauntWithoutTax { get; set; }
        public decimal Discount { get; set; }
        public int ProductCount { get; set; }
        public decimal Tax { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
