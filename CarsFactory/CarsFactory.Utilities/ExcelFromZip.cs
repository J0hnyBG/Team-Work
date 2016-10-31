using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.IO.Compression;

using CarsFactory.Models;

namespace CarsFactory.Utilities
{
    public class ExcelFromZip
    {
        private const string TempExcelFile = "TempExcelFile.xls";

        public static List<Town> GetAllTowns(ZipArchive zip)
        {
            var dealershipTowns = new List<Town>();

            foreach (var entry in zip.Entries)
            {
                if (entry.FullName.EndsWith("Towns.xls"))
                {
                    var entryParts = entry.FullName.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
                    var fileName = entry.FullName;
                    if (entryParts.Length > 1)
                    {
                        fileName = entryParts[entryParts.Length - 1];
                    }

                    using (var ms = new MemoryStream())
                    {
                        var file = File.Create(TempExcelFile);
                        using (file)
                        {
                            CopyStream(entry.Open(), ms);
                            ms.WriteTo(file);
                        }
                    }

                    var connection = new OleDbConnection();
                    var connectionString = new OleDbConnectionStringBuilder
                    {
                        { "Provider", "Microsoft.ACE.OLEDB.12.0" },
                        { "Extended Properties", "Excel 12.0 XML" },
                        { "Data Source", TempExcelFile }
                    };

                    connection.ConnectionString = connectionString.ToString();

                    using (connection)
                    {
                        connection.Open();

                        var excelSchema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                        var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

                        var oleDbCommand = new OleDbCommand("SELECT * FROM [" + sheetName + "]", connection);

                        using (var adapter = new OleDbDataAdapter(oleDbCommand))
                        {
                            var dataSet = new DataSet();
                            adapter.Fill(dataSet);

                            using (var reader = dataSet.CreateDataReader())
                            {
                                var count = 0;
                                while (reader.Read())
                                {
                                    var town = new Town()
                                    {
                                        Id = count + 1000,
                                        Name = reader["Name"].ToString(),
                                    };
                                    Console.WriteLine(town.Name);
                                    dealershipTowns.Add(town);
                                    count++;
                                }
                            }
                        }
                    }
                }
            }

            File.Delete(TempExcelFile);
            return dealershipTowns;
        }

        private static void CopyStream(Stream input, Stream output)
        {
            var buffer = new byte[2048];
            var read = input.Read(buffer, 0, buffer.Length);
            while (read > 0)
            {
                output.Write(buffer, 0, read);
                read = input.Read(buffer, 0, buffer.Length);
            }
        }
    }
}
