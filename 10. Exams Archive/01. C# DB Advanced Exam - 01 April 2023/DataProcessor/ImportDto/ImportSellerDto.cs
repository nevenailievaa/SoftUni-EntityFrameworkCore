namespace Boardgames.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using Boardgames.Shared;

    public class ImportSellerDto
    {
        [Required]
        [MinLength(GlobalConstants.SellerNameMinLength)]
        [MaxLength(GlobalConstants.SellerNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(GlobalConstants.SellerAddressMinLength)]
        [MaxLength(GlobalConstants.SellerAddressMaxLength)]
        public string Address { get; set; } = null!;


        [Required]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression(GlobalConstants.SellerWebsiteRegex)]
        public string Website { get; set; } = null!;

        public int[] Boardgames { get; set; } = null!;
    }
}
