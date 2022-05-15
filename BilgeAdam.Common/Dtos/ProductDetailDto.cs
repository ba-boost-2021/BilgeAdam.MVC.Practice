namespace BilgeAdam.Common.Dtos
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Order { get; set; }
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }
        public string SupplierContactName { get; set; }
        public string Quantity{ get; set; }
    }
}
