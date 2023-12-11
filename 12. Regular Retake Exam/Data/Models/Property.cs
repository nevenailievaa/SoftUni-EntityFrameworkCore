using Cadastre.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastre.Data.Models;

public class Property
{
    //Properties
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CommonConstraints.PropertyIdentifierMaxLength)]
    public string PropertyIdentifier { get; set; }

    [Required]
    [Range(CommonConstraints.PropertyAreaMinRange, int.MaxValue)]
    public int Area { get; set; }

    [MaxLength(CommonConstraints.PropertyDetailsMaxLength)]
    public string? Details { get; set; }

    [Required]
    [MaxLength(CommonConstraints.PropertyAddressMaxLength)]
    public string Address { get; set; }

    [Required]
    public DateTime DateOfAcquisition { get; set; }

    //District
    [Required]
    public int DistrictId { get; set; }

    [ForeignKey(nameof(DistrictId))]
    public District District { get; set; }

    //Collections
    public ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = new HashSet<PropertyCitizen>();
}