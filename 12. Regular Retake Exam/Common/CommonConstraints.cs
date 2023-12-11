namespace Cadastre.Common;

public class CommonConstraints
{
    //District
    public const int DistrictNameMinLength = 2;
    public const int DistrictNameMaxLength = 80;

    public const string DistrictPostalCodeRegex = @"^[A-Z]{2}-\d{5}$";

    public const int DistrictRegionMinRange = 0;
    public const int DistrictRegionMaxRange = 3;


    //Property
    public const int PropertyIdentifierMinLength = 16;
    public const int PropertyIdentifierMaxLength = 20;

    public const int PropertyAreaMinRange = 0;

    public const int PropertyDetailsMinLength = 5;
    public const int PropertyDetailsMaxLength = 500;

    public const int PropertyAddressMinLength = 5;
    public const int PropertyAddressMaxLength = 200;


    //Citizen
    public const int CitizenFirstNameMinLength = 2;
    public const int CitizenFirstNameMaxLength = 30;

    public const int CitizenLastNameMinLength = 2;
    public const int CitizenLastNameMaxLength = 30;

    public const int CitizenMartialStatusMinRange = 0;
    public const int CitizenMartialStatusMaxRange = 3;
}