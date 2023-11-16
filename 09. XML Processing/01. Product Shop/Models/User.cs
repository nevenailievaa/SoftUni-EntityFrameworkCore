namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class User
    {
        //Constructor
        public User()
        {
            this.ProductsSold = new List<Product>();
            this.ProductsBought = new List<Product>();
        }

        //Properties
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string LastName { get; set; } = null!;

        public int? Age { get; set; }

        public ICollection<Product> ProductsSold { get; set; } = null!;
        public ICollection<Product> ProductsBought { get; set; } = null!;
    }
}