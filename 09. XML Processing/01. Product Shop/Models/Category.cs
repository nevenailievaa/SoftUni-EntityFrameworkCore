namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class Category
    {
        //Constructor
        public Category()
        {
            this.CategoryProducts = new List<CategoryProduct>();
        }

        //Properties
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
