using Medicines.Common;
using System.ComponentModel.DataAnnotations;

namespace Medicines.Data.Models;

public class Pharmacy
{
    //Properties
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CommonConstraints.PharmacyNameMaxLength)]
    public string Name { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public bool IsNonStop { get; set; }

    //Collections
    public virtual ICollection<Medicine> Medicines { get; set; } = new HashSet<Medicine>();
}