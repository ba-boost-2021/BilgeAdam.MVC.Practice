using System.ComponentModel.DataAnnotations;

namespace BilgeAdam.MVC.Practice.Models.Dtos
{
    public class ProductAddDto
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public string Name { get; set; }
        public short? Stock { get; set; }
        public decimal? Price { get; set; }
    }
}
