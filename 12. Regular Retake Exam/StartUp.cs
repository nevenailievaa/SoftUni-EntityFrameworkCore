namespace Cadastre
{
    using Cadastre.Data;

    using Microsoft.EntityFrameworkCore;


    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new CadastreContext();

            ResetDatabase(dbContext, shouldDropDatabase: false);

            var projectDir = GetProjectDirectory();

            ImportEntities(dbContext, projectDir + @"Datasets/", projectDir + @"ImportResults/");
            ExportEntities(dbContext, projectDir + @"ExportResults/");

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                transaction.Rollback();
            }
        }
        private static void ImportEntities(CadastreContext dbContext, string baseDirectory, string exportDir)
        {
            var districts = DataProcessor.Deserializer
                .ImportDistricts(dbContext, File.ReadAllText(baseDirectory + "districts.xml"));

            PrintAndExportEntityToFile(districts, exportDir + "Actualt Result - ImportedDistricts.txt");

            var citizens = DataProcessor.Deserializer
                .ImportCitizens(dbContext, File.ReadAllText(baseDirectory + "citizens.json"));

            PrintAndExportEntityToFile(citizens, exportDir + "Actual Result - ImportedCitizens.txt");
        }

        private static void ExportEntities(CadastreContext dbContext, string exportDir)
        {
            var exportPropertiesWithOwners = DataProcessor.Serializer
                .ExportPropertiesWithOwners(dbContext);

            Console.WriteLine(exportPropertiesWithOwners);
            File.WriteAllText(exportDir + "Actual Result - ExportPropertiesWithOwners.json", exportPropertiesWithOwners);

            var exportFilteredPropertiesWithDistrict = DataProcessor.Serializer
                .ExportFilteredPropertiesWithDistrict(dbContext);

            Console.WriteLine(exportFilteredPropertiesWithDistrict);
            File.WriteAllText(exportDir + "Actual Result - ExportFilteredPropertiesWithDistrict.xml", exportFilteredPropertiesWithDistrict);
        }


        private static void PrintAndExportEntityToFile(string entityOutput, string outputPath)
        {
            Console.WriteLine(entityOutput);
            File.WriteAllText(outputPath, entityOutput.TrimEnd());
        }

        private static string GetProjectDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var directoryName = Path.GetFileName(currentDirectory);
            var relativePath = directoryName.StartsWith("net6.0") ? @"../../../" : string.Empty;

            return relativePath;
        }

        private static void ResetDatabase(CadastreContext dbContext, bool shouldDropDatabase = false)
        {
            if (shouldDropDatabase)
            {
                dbContext.Database.EnsureDeleted();
            }

            if (dbContext.Database.EnsureCreated())
            {
                return;
            }

            var disableIntegrityChecksQuery =
                "EXEC sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL'";
            dbContext.Database.ExecuteSqlRaw(disableIntegrityChecksQuery);

            var deleteRowsQuery =
                "EXEC sp_MSforeachtable @command1='SET QUOTED_IDENTIFIER ON;DELETE FROM ?'";
            dbContext.Database.ExecuteSqlRaw(deleteRowsQuery);

            var enableIntegrityChecksQuery =
                "EXEC sp_MSforeachtable @command1='ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'";
            dbContext.Database.ExecuteSqlRaw(enableIntegrityChecksQuery);

            var reseedQuery =
                "EXEC sp_MSforeachtable @command1='IF OBJECT_ID(''?'') IN (SELECT OBJECT_ID FROM SYS.IDENTITY_COLUMNS) DBCC CHECKIDENT(''?'', RESEED,0)'";
            dbContext.Database.ExecuteSqlRaw(reseedQuery);
        }
    }
}