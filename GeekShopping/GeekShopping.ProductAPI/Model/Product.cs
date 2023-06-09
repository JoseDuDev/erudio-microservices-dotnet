using GeekShopping.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Model
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("price")]
        [Required]
        [Range(0, 500)]
        public decimal Price { get; set; }

        [Column("description")]
        [StringLength(512)]
        public string Description { get; set; }

        [Column("category_name")]
        [Required]
        [StringLength(150)]
        public string CategoryName { get; set; }

        [Column("image_url")]
        [StringLength(256)]
        public string ImageURL { get; set; }
    }
}
