using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RepositoryPattern.Models;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Repositories;

namespace RepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            DoWork(new TransactionsFromFileRepository());
            DoWork(new TransactionsFromDatabaseRepository());
        }

        private static void DoWork(ITransactionRepository repository)
        {
            var transactions = repository.GetAll();
            Console.WriteLine($"Found {transactions.Count()} transactions.");

            var specificTransaction = repository.Get("TheOne");
            if (specificTransaction != null)
                Console.WriteLine($"Found the {specificTransaction.RecordId} transactions.");
            else
                Console.WriteLine("Couldn't find that one transaction we were looking for. Bummer.");
        }
    }
}
