using Cadastre.Common;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Cadastre.DataProcessor.ImportDtos;

public class ImportCitizenDto
{
    [JsonProperty("FirstName")]
    [Required]
    [MinLength(CommonConstraints.CitizenFirstNameMinLength)]
    [MaxLength(CommonConstraints.CitizenFirstNameMaxLength)]
    public string FirstName { get; set; }

    [JsonProperty("LastName")]
    [Required]
    [MinLength(CommonConstraints.CitizenLastNameMinLength)]
    [MaxLength(CommonConstraints.CitizenLastNameMaxLength)]
    public string LastName { get; set; }

    [JsonProperty("BirthDate")]
    [Required]
    public string BirthDate { get; set; }

    [JsonProperty("MaritalStatus")]
    [Required]
    public string MaritalStatus { get; set; }

    [JsonProperty("Properties")]
    public int[] PropertiesIds { get; set; }
}