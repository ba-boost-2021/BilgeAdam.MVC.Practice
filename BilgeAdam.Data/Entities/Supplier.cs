using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgeAdam.Data.Entities
{
    [Table("Suppliers")]
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
    }
}
