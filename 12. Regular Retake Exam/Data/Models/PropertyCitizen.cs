using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cadastre.Data.Models;

//Mapping table between Peoperties and Citizens
public class PropertyCitizen
{
    //Property
    [Required]
    public int PropertyId { get; set; }

    [ForeignKey(nameof(PropertyId))]
    public Property Property { get; set; }

    //Citizen
    [Required]
    public int CitizenId { get; set; }

    [ForeignKey(nameof(CitizenId))]
    public Citizen Citizen { get; set; }
}