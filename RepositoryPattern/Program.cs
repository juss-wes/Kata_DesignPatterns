using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RepositoryPattern.Models;
using System.Data.SqlClient;
using System.Data;

namespace RepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            DoWork();
        }

        private static void DoWork()
        {
            var transactions = GetTransactionsFromFile();
            Console.WriteLine($"Found {transactions.Count()} transactions.");

            var specificTransaction = transactions.FirstOrDefault(x => x.RecordId == "TheOne");
            if (specificTransaction != null)
                Console.WriteLine($"Found the {specificTransaction.RecordId} transactions.");
            else
                Console.WriteLine("Couldn't find that one transaction we were looking for. Bummer.");
        }

        private static IEnumerable<Transaction> GetTransactionsFromFile()
        {
            var fileLines = System.IO.File.ReadAllLines(@"c:\temp\transaction-data.txt");
            var transactions = fileLines.Select(line => line.Split('~'))
                                        .Select(values => new Transaction
                                        {
                                            RecordId = values[0],
                                            Customer = values[1],
                                            Location = values[2],
                                            Product = values[3],
                                            Timestamp = DateTime.TryParse(values[4], out var datetimeValue) ? datetimeValue : DateTime.MinValue,
                                            Volume = double.TryParse(values[5], out var doubleValue) ? doubleValue : 0
                                        }).ToList();

            return transactions;
        }

        private static IEnumerable<Transaction> GetTransactionsFromDatabase()
        {
            DataTable results = null;
            using (var conn = new SqlConnection("my database connection"))
            {
                using (var cmd = new SqlCommand("select * from MainframeTransactions", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (!reader.IsClosed)
                        {
                            results = new DataTable();
                            results.Load(reader);
                        }
                    }
                }
            }

            var transactions = results.AsEnumerable()
                                    .Select(row => new Transaction
                                    {
                                        RecordId = row[0].ToString(),
                                        Customer = row[1].ToString(),
                                        Location = row[2].ToString(),
                                        Product = row[3].ToString(),
                                        Timestamp = DateTime.TryParse(row[4].ToString(), out var datetimeValue) ? datetimeValue : DateTime.MinValue,
                                        Volume = double.TryParse(row[5].ToString(), out var doubleValue) ? doubleValue : 0
                                    });

            return transactions;
        }
    }
}
