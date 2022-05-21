namespace BilgeAdam.Common.Dtos
{
    public class ProductViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool Discontinued { get; set; }
    }
    public class ProductUpdateInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public bool Discontinued { get; set; }
    }
}
