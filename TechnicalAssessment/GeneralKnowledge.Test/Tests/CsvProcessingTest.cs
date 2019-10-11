using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// CSV processing test
    /// </summary>
    public class CsvProcessingTest : ITest
    {
        public void Run()
        {
            // TODO: 
            // Create a domain model via POCO classes to store the data available in the CSV file below
            // Objects to be present in the domain model: Asset, Country and Mime type
            // Process the file in the most robust way possible
            // The use of 3rd party plugins is permitted
            const int Padding = 20;
            const Char Space = ' ';
            var csvFile = Resources.AssetImport;
            var engine = new FileHelperEngine<Asset>();
            List<Asset> Assets = engine.ReadString(csvFile).ToList();
            List<Asset> ProcessedAssets = Assets.Where(x => x.Country.ToLower() == "belgium".ToLower()).Take(10).ToList();
            Console.WriteLine("\r\nSample 10 records for Country Belgium from Processed CSV File\r\n");
            Console.WriteLine("File Name".PadRight(Padding + 8, Space) + "Mime Type".PadRight(Padding, Space) + "Created By".PadRight(Padding, Space) + "Email");
            Console.WriteLine(new String('-', 100));
            foreach (Asset ast in ProcessedAssets)
            {
                Console.Write(ast.FileName.PadRight(Padding + 8, Space));
                Console.Write(ast.MimeType.PadRight(Padding, Space));
                Console.Write(ast.CreatedBy.PadRight(Padding, Space));
                Console.Write(ast.Email.PadRight(Padding, Space) + "\r\n");
            }
            Console.WriteLine(new String('x', 40));
        }
    }
    [IgnoreFirst(1)]
    [DelimitedRecord(",")]
    [IgnoreEmptyLines()]
    public class Asset
    {
        public string AssetID { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string CreatedBy { get; set; }
        public string Email { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.NotAllow)]
        public string Country { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.NotAllow)]
        public string Description { get; set; }
    }

}
