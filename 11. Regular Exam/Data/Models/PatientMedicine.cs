using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medicines.Data.Models;

public class PatientMedicine
{
    //Patient
    [Required]
    public int PatientId { get; set; }

    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; }

    //Medicine
    [Required]
    public int MedicineId { get; set; }

    [ForeignKey(nameof(MedicineId))]
    public Medicine Medicine { get; set; }
}