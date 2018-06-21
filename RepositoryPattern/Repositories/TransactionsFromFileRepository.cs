using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Repositories
{
    class TransactionsFromFileRepository : ITransactionRepository
    {
        private const string FILE_SOURCE_PATH = @"c:\temp\transaction-data.txt";
        private const char FILE_DELIMITER = '~';
        public Transaction Get(string recordId) => GetAll().FirstOrDefault(x => x.RecordId == recordId);

        public IEnumerable<Transaction> GetAll()
        {
            var fileLines = System.IO.File.ReadAllLines(FILE_SOURCE_PATH);
            var transactions = fileLines.Select(line => line.Split(FILE_DELIMITER))
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
    }
}