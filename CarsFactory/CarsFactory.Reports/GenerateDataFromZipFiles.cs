using System.Collections.Generic;
using System.IO.Compression;

using CarsFactory.Data;
using CarsFactory.Models;
using CarsFactory.Utilities;

namespace CarsFactory.Reports
{
    public class GenerateDataFromZipFiles
    {
        public void GetDataFromZip()
        {
            var repo = new MSSqlRepository();
            var filePath = @"..\..\..\..\SampleData.zip";
            var zip = ZipFile.Open(filePath, ZipArchiveMode.Read);
            using (zip)
            {
                var entries = ExcelFromZip.GetFileEntries(zip);
                var currentTownEntries = ExcelFromZip.GetCurrentEntries(entries, "Towns.xls");
                var currentPlatformEntries = ExcelFromZip.GetCurrentEntries(entries, "Platforms.xls");
                var currentEngineEntries = ExcelFromZip.GetCurrentEntries(entries, "Engines.xls");
                var currentModelEntries = ExcelFromZip.GetCurrentEntries(entries, "Models.xls");
                var currentCarEntries = ExcelFromZip.GetCurrentEntries(entries, "Cars.xls");
                var towns = ExcelFromZip.GetAllTowns(new List<Town>(), currentTownEntries);
                var platforms = ExcelFromZip.GetAllPlatforms(new List<Platform>(), currentPlatformEntries);
                var engines = ExcelFromZip.GetAllEngines(new List<Engine>(), currentEngineEntries);
                var models = ExcelFromZip.GetAllModels(new List<Model>(), currentModelEntries);
                var cars = ExcelFromZip.GetAllCars(new List<Car>(), currentCarEntries);
                repo.ExtractTownsFromZip(towns);
                repo.ExtractPlatformsFromZip(platforms);
                repo.ExtractEnginesFromZip(engines);
                repo.ExtractModelsFromZip(models);
                repo.ExtractCarsFromZip(cars);
            }
        }
    }
}
