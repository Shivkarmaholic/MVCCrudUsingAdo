using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCrudUsingAdo.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Product Name Required")]
        [Display(Name="Product Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Price is Required")]
        [Display(Name = "Product Price")]
        [Range(minimum:1,maximum:50000)]
        public double Price { get; set; }
    }
}
