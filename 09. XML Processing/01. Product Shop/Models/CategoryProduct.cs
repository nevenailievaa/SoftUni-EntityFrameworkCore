using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class CategoryProduct
    {
        //Properties

        //Category
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        //Product
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
