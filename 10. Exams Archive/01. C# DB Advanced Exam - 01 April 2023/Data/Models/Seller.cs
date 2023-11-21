namespace Boardgames.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Boardgames.Shared;

    public class Seller
    {
        public Seller()
        {
            BoardgamesSellers = new List<BoardgameSeller>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.SellerNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(GlobalConstants.SellerAddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        public string Website { get; set; } = null!;


        public ICollection<BoardgameSeller> BoardgamesSellers { get; set; }


    }
}
