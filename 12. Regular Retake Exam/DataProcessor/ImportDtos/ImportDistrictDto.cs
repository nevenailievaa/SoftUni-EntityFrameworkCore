using Cadastre.Common;
using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType("District")]
public class ImportDistrictDto
{
    [XmlAttribute("Region")]
    [Required]
    public string Region { get; set; }

    [XmlElement("Name")]
    [Required]
    [MinLength(CommonConstraints.DistrictNameMinLength)]
    [MaxLength(CommonConstraints.DistrictNameMaxLength)]
    public string Name { get; set; }

    [XmlElement("PostalCode")]
    [Required]
    [RegularExpression(CommonConstraints.DistrictPostalCodeRegex)]
    public string PostalCode { get; set; }

    [XmlArray("Properties")]
    public ImportDistrictPropertyDto[] Properties { get; set; }
}

[XmlType("Property")]
public class ImportDistrictPropertyDto
{
    [XmlElement("PropertyIdentifier")]
    [Required]
    [MinLength(CommonConstraints.PropertyIdentifierMinLength)]
    [MaxLength(CommonConstraints.PropertyIdentifierMaxLength)]
    public string PropertyIdentifier { get; set; }

    [XmlElement("Area")]
    [Required]
    [Range(CommonConstraints.PropertyAreaMinRange, int.MaxValue)]
    public int Area { get; set; }

    [XmlElement("Details")]
    [MinLength(CommonConstraints.PropertyDetailsMinLength)]
    [MaxLength(CommonConstraints.PropertyDetailsMaxLength)]
    public string? Details { get; set; }

    [XmlElement("Address")]
    [Required]
    [MinLength(CommonConstraints.PropertyAddressMinLength)]
    [MaxLength(CommonConstraints.PropertyAddressMaxLength)]
    public string Address { get; set; }

    [XmlElement("DateOfAcquisition")]
    [Required]
    public string DateOfAcquisition { get; set; }
}