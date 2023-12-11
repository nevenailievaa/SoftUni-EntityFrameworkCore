using Cadastre.Common;
using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Cadastre.Data.Models;

public class District
{
    //Properties
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CommonConstraints.DistrictNameMaxLength)]
    public string Name { get; set; }

    [Required]
    public string PostalCode { get; set; }

    [Required]
    public Region Region { get; set; }

    //Collecions
    public virtual ICollection<Property> Properties { get; set; } = new HashSet<Property>();
}