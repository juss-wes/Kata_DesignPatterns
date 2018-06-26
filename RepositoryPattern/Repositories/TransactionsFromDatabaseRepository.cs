using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Repositories
{
    class TransactionsFromDatabaseRepository : ITransactionRepository
    {
        private const string _connectionString = "my database connection";
        public Transaction Get(string recordId)
        {
            var transaction = ExecuteQuery($"select * from MainframeTransactions where RecordId = '{recordId}'").FirstOrDefault();

            return transaction;
        }

        public IEnumerable<Transaction> GetAll()
        {
            var transactions = ExecuteQuery("select * from MainframeTransactions");

            return transactions;
        }

        private static IEnumerable<Transaction> ExecuteQuery(string query)
        {
            DataTable results = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
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
