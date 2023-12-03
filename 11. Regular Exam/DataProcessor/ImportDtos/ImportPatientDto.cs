using Medicines.Common;
using Medicines.Data.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Medicines.DataProcessor.ImportDtos;

public class ImportPatientDto
{
    [JsonProperty("FullName")]
    [Required]
    [MinLength(CommonConstraints.PatientFullNameMinLength)]
    [MaxLength(CommonConstraints.PatientFullNameMaxLength)]
    public string FullName { get; set; }

    [JsonProperty("AgeGroup")]
    [Required]
    [Range(CommonConstraints.PatientAgeGroupMinRange, CommonConstraints.PatientAgeGroupMaxRange)]
    public int AgeGroup { get; set; }

    [JsonProperty("Gender")]
    [Required]
    [Range(CommonConstraints.PatientGenderMinRange, CommonConstraints.PatientGenderMaxRange)]
    public int Gender { get; set; }

    [JsonProperty("Medicines")]
    public int[] Medicines { get; set; }
}