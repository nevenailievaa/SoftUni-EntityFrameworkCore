using Cadastre.Common;
using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Cadastre.Data.Models;

public class Citizen
{
    //Properties
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CommonConstraints.CitizenFirstNameMaxLength)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(CommonConstraints.CitizenLastNameMaxLength)]
    public string LastName { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public MaritalStatus MaritalStatus { get; set; }

    //Collections
    public ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = new HashSet<PropertyCitizen>();
}