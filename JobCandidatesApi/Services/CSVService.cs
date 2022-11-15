using CsvHelper;
using System.Globalization;
using JobCandidatesApi.Models;
using CsvHelper.Configuration;
using System.Diagnostics;


namespace JobCandidatesApi.Services
{
    public class CSVService : ICSVService
    {
        public IEnumerable<T> ReadCSV<T>()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            var reader = new StreamReader("D:\\file.csv");
            var csv = new CsvReader(reader, config);
               
            var records = csv.GetRecords<T>().ToList();
            csv.Dispose();
            reader.Close();
            
            return records;
        }

        public void UpdateCandidate(Candidate record)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            var reader = new StreamReader("D:\\file.csv");

            var csv = new CsvReader(reader, config);

            var records = csv.GetRecords<Candidate>().ToList();
            var ri = records.FindIndex(i => i.Email == record.Email);
            records.RemoveAt(ri);
            records.Add(record);

            csv.Dispose();
            reader.Close();

            File.Delete("D:\\file.csv");

            using (StreamWriter sw = File.AppendText(@"D:\file.csv"))
            {
                records.ForEach(i => {
                    var line = i.FirstName + "," + i.LastName + "," + i.PhoneNumber + "," + i.Email + "," + i.CallTime + "," + i.LinkedIn + "," + i.Github + "," + i.Comment;
                    sw.WriteLine(line);
                });
               
            }

        }

        public void CreateCandidate(Candidate record)
        {
            using (StreamWriter sw = File.AppendText(@"D:\file.csv"))
            {
                var line = record.FirstName + "," + record.LastName + "," + record.PhoneNumber + "," + record.Email + "," + record.CallTime + "," + record.LinkedIn + "," + record.Github + "," + record.Comment;
                sw.WriteLine(line);

            }
           

        }

    }
}
