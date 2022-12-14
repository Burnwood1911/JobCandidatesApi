using CsvHelper;
using System.Globalization;
using JobCandidatesApi.Models;
using CsvHelper.Configuration;


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
            var reader = new StreamReader(@"file.csv");
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
            var reader = new StreamReader(@"file.csv");

            var csv = new CsvReader(reader, config);

            var records = csv.GetRecords<Candidate>().ToList();
            var ri = records.FindIndex(i => i.Email == record.Email);
            records.RemoveAt(ri);
            records.Add(record);

            csv.Dispose();
            reader.Close();

            File.Delete(@"file.csv");

            using (StreamWriter sw = File.AppendText(@"file.csv"))
            {
                records.ForEach(i => {
                    var line = i.FirstName + "," + i.LastName + "," + i.PhoneNumber + "," + i.Email + "," + i.CallTime + "," + i.LinkedIn + "," + i.Github + "," + i.Comment;
                    sw.WriteLine(line);
                });
               
            }

        }

        //newaddition checks if it is the first record in the csv if so it adds the headers.
        public void CreateCandidate(Candidate record, bool newAddition)
        {
            if (newAddition) {
                using (StreamWriter sw = File.AppendText(@"file.csv"))
                {
                    sw.WriteLine("FirstName,LastName,PhoneNumber,Email,CallTime,LinkedIn,Github,Comment");
                    var line = record.FirstName + "," + record.LastName + "," + record.PhoneNumber + "," + record.Email + "," + record.CallTime + "," + record.LinkedIn + "," + record.Github + "," + record.Comment;
                    sw.WriteLine(line);

                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(@"file.csv"))
                {
                    var line = record.FirstName + "," + record.LastName + "," + record.PhoneNumber + "," + record.Email + "," + record.CallTime + "," + record.LinkedIn + "," + record.Github + "," + record.Comment;
                    sw.WriteLine(line);

                }
            }
            

        }

    }
}
