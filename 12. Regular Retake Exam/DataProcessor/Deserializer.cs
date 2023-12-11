namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Cadastre.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Text.Json.Serialization;

    public class Deserializer
    {
        //Messages
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported districts - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizens - {0} {1} with {2} properties.";

        //XML Import
        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            var xmlHelper = new XmlHelper();
            ImportDistrictDto[] districtDtos = xmlHelper.Deserialize<ImportDistrictDto[]>(xmlDocument, "Districts");

            //Selecting only the Valid Districts and their Valid Properties
            var allDistricts = dbContext.Districts.ToArray();
            var allProperties = dbContext.Properties.ToArray();
            HashSet<District> validDistricts = new HashSet<District>();
            StringBuilder sb = new StringBuilder();

            //Districts
            foreach (var districtDto in districtDtos)
            {
                //Invalid District
                if (!IsValid(districtDto)
                    || allDistricts.Any(d => d.Name == districtDto.Name)
                    || !Enum.TryParse(districtDto.Region, out Region validRegion))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                //Valid District
                District validDistrict = new District()
                {
                    Region = validRegion,
                    Name = districtDto.Name,
                    PostalCode = districtDto.PostalCode
                };

                //Properties
                foreach (var propertyDto in districtDto.Properties)
                {




                    //Invalid Property
                    if (!IsValid(propertyDto)
                        || !DateTime.TryParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validDateOfAquistion)
                        || allProperties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier || p.Address == propertyDto.Address)
                        || validDistrict.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier || p.Address == propertyDto.Address))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    //Valid Property
                    validDistrict.Properties.Add(new Property()
                    { 
                        PropertyIdentifier = propertyDto.PropertyIdentifier,
                        Area = propertyDto.Area,
                        Details = propertyDto.Details,
                        Address = propertyDto.Address,
                        DateOfAcquisition = validDateOfAquistion
                    });
                }
                //Adding the Valid Property to it's Collection
                validDistricts.Add(validDistrict);
                sb.AppendLine(String.Format(SuccessfullyImportedDistrict, validDistrict.Name, validDistrict.Properties.Count));
            }
            //Adding and Saving
            dbContext.Districts.AddRange(validDistricts);
            dbContext.SaveChanges();

            //Output
            return sb.ToString().TrimEnd();
        }

        //JSON Import
        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            ImportCitizenDto[] citizenDtos = JsonConvert.DeserializeObject<ImportCitizenDto[]>(jsonDocument);
            
            //Selecting only the valid Citizens and their Valid Properties
            HashSet<Citizen> validCitizens = new HashSet<Citizen>();
            StringBuilder sb = new StringBuilder();

            //Citizens
            foreach (var citizenDto in citizenDtos)
            {
                //Invalid Citizen
                if (!IsValid(citizenDto)
                    || !Enum.TryParse(citizenDto.MaritalStatus, out MaritalStatus validMaritalStatus)
                    || !DateTime.TryParseExact(citizenDto.BirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validBirthDate))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                //Valid Citizen
                Citizen validCitizen = new Citizen()
                {
                    FirstName = citizenDto.FirstName,
                    LastName = citizenDto.LastName,
                    BirthDate = validBirthDate,
                    MaritalStatus = validMaritalStatus
                };

                //Adding the DTO Properties to the Valid Citizen
                foreach (var propertyId in citizenDto.PropertiesIds)
                {
                    validCitizen.PropertiesCitizens.Add(new PropertyCitizen()
                    {
                        PropertyId = propertyId
                    });
                }
                //Adding the Valid Citizen to it's Collection
                validCitizens.Add(validCitizen);
                sb.AppendLine(String.Format(SuccessfullyImportedCitizen, validCitizen.FirstName, validCitizen.LastName, validCitizen.PropertiesCitizens.Count()));
            }
            //Adding and Saving
            dbContext.Citizens.AddRange(validCitizens);
            dbContext.SaveChanges();

            //Output
            return sb.ToString().TrimEnd();
        }

        //DTOs Attributes Validation
        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
