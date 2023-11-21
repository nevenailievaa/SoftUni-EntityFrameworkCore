namespace Boardgames.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using Boardgames.Shared;

    [XmlType("Creator")]
    public class ImportCreatorDto
    {
        [XmlElement("FirstName")]
        [Required]
        [MinLength(GlobalConstants.CreatorNameMinLength)]
        [MaxLength(GlobalConstants.CreatorNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [XmlElement("LastName")]
        [MinLength(GlobalConstants.CreatorNameMinLength)]
        [MaxLength(GlobalConstants.CreatorNameMaxLength)]
        public string LastName { get; set; } = null!;

        [XmlArray("Boardgames")]
        public ImportCreatorBoardgameDto[] Boardgames { get; set; } = null!;
    }
}
