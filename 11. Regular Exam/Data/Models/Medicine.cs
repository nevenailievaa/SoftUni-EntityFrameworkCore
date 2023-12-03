using Medicines.Common;
using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicines.Data.Models;

public class Medicine
{
    //Properties
    public int Id { get; set; }

    [Required]
    [MaxLength(CommonConstraints.MedicineNameMaxLength)]
    public string Name { get; set; }

    [Required]
    [Range(CommonConstraints.MedicinePriceMinRange, CommonConstraints.MedicinePriceMaxRange)]
    public decimal Price { get; set; }

    [Required]
    public Category Category { get; set; }

    [Required]
    public DateTime ProductionDate { get; set; }

    [Required]
    public DateTime ExpiryDate { get; set; }

    [Required]
    [MaxLength(CommonConstraints.MedicineProducerMaxLength)]
    public string Producer { get; set; }

    //Pharmacy
    [Required]
    public int PharmacyId { get; set; }

    [ForeignKey(nameof(PharmacyId))]
    public Pharmacy Pharmacy { get; set; }

    //Collections
    public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; } = new HashSet<PatientMedicine>();
}