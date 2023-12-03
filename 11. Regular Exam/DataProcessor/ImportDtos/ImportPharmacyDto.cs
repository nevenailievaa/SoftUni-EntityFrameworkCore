using Medicines.Data.Models.Enums;
using Medicines.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Medicines.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos;

[XmlType("Pharmacy")]
public class ImportPharmacyDto
{
    [XmlAttribute("non-stop")]
    [Required]
    public string IsNonStop { get; set; }

    [XmlElement("Name")]
    [Required]
    [MinLength(CommonConstraints.PharmacyNameMinLength)]
    [MaxLength(CommonConstraints.PharmacyNameMaxLength)]
    public string Name { get; set; }

    [XmlElement("PhoneNumber")]
    [Required]
    [RegularExpression(CommonConstraints.PharmacyPhoneNumberRegex)]
    public string PhoneNumber { get; set; }

    [XmlArray("Medicines")]
    public ImportMedicineDto[] Medicines { get; set; }
}

[XmlType("Medicine")]
public class ImportMedicineDto
{
    [XmlAttribute("category")]
    [Required]
    [Range(CommonConstraints.MedicineCategoryMinRange, CommonConstraints.MedicineCategoryMaxRange)]
    public int Category { get; set; }

    [XmlElement("Name")]
    [Required]
    [MinLength(CommonConstraints.MedicineNameMinLength)]
    [MaxLength(CommonConstraints.MedicineNameMaxLength)]
    public string Name { get; set; }

    [XmlElement("Price")]
    [Required]
    [Range(CommonConstraints.MedicinePriceMinRange, CommonConstraints.MedicinePriceMaxRange)]
    public decimal Price { get; set; }

    [XmlElement("ProductionDate")]
    [Required]
    public string ProductionDate { get; set; }

    [XmlElement("ExpiryDate")]
    [Required]
    public string ExpiryDate { get; set; }

    [XmlElement("Producer")]
    [Required]
    [MinLength(CommonConstraints.MedicineProducerMinLength)]
    [MaxLength(CommonConstraints.MedicineProducerMaxLength)]
    public string Producer { get; set; }
}