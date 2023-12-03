namespace Medicines.Common;

public class CommonConstraints
{
    //Pharmacy
    public const int PharmacyNameMinLength = 2;
    public const int PharmacyNameMaxLength = 50;

    public const string PharmacyPhoneNumberRegex = @"^\(\d{3}\) \d{3}-\d{4}$";

    //Medicine
    public const int MedicineNameMinLength = 3;
    public const int MedicineNameMaxLength = 150;

    public const double MedicinePriceMinRange = 0.01;
    public const double MedicinePriceMaxRange = 1000.0;

    public const int MedicineProducerMinLength = 3;
    public const int MedicineProducerMaxLength = 100;

    public const double MedicineCategoryMinRange = 0;
    public const double MedicineCategoryMaxRange = 4;

    //Patient
    public const int PatientFullNameMinLength = 5;
    public const int PatientFullNameMaxLength = 100;

    public const int PatientAgeGroupMinRange = 0;
    public const int PatientAgeGroupMaxRange = 2;

    public const int PatientGenderMinRange = 0;
    public const int PatientGenderMaxRange = 1;
}