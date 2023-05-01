namespace WebSis.Business.Managmant.Api.Models.Products
{
    public class Product
    {
        //TO DO: add category and subcategory, create entity category, add barcode filed

        public Guid ProductID { get; set; }
        public Guid Sku { get; set; }  // (Stock Keeping Unit): A unique identifier assigned to the product for inventory and tracking purposes.
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string PackageType { get; set; }
        public string Brand { get; set; }
        public string Warranty { get; set; }
        public string CountryOfOrigin { get; set; }
        public decimal PriceWithoutTax { get; set; }
        public decimal PriceWithTax { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Weight { get; set; }
        public string Note { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
