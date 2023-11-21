namespace Boardgames.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Boardgames.Shared;

    public class Creator
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CreatorNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(GlobalConstants.CreatorNameMaxLength)]
        public string LastName { get; set; } = null!;

        public ICollection<Boardgame> Boardgames { get; set; } = new List<Boardgame>();
    }
}
