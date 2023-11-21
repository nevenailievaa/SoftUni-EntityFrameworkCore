namespace Boardgames.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using Boardgames.Shared;

    [XmlType("Boardgame")]
    public class ImportCreatorBoardgameDto
    {
        [Required]
        [MinLength(GlobalConstants.BoardgameNameMinLength)]
        [MaxLength(GlobalConstants.BoardgameNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("Rating")]
        [Range(GlobalConstants.BoardgameRatingMin,GlobalConstants.BoardgameRatingMax)]
        public double Rating { get; set; }

        [Required]
        [XmlElement("YearPublished")]
        [Range(GlobalConstants.YearPublishedMin, GlobalConstants.YearPublishedMax)]
        public int YearPublished  { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        [Range(0, 4)]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("Mechanics")]
        public string Mechanics { get; set; } = null!;
    }
}
