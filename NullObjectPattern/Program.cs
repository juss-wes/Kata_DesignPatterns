using System;
using System.Collections.Generic;
using System.Linq;
using NullObjectPattern.Models;

namespace NullObjectPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var transactionId = 0;

            while (transactionId != 100)
            {
                Console.Clear();
                Console.WriteLine("Enter a transaction ID: ");
                Console.Write("ID: ");
                if(int.TryParse(Console.ReadLine(), out transactionId))
                {
                    var transaction = GetTransaction(transactionId);

                    // Process the requested transaction
                    transaction.ProcessTransaction();

                    Console.WriteLine();
                    Console.WriteLine("Press 'Enter' to submit another transaction.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid entry. Press 'Enter' to continue.");
                    Console.ReadLine();
                }
            }
        }

        private static Transaction GetTransaction(int id)
        {
            // Should be returned from the database or something, but this will work for this
            var transactions = new List<Transaction>
            {
                new Transaction(1, "Wes Vollmar", 5.27, DateTime.Now),
                new Transaction(2, "Thomas Harris", 8.50, DateTime.Now),
                new Transaction(3, "Tom Jacoby", 1.45, DateTime.Now),
                new Transaction(4, "Paul Burns", 12.80, DateTime.Now),
                new Transaction(5, "Brian Cobb", 800.20, DateTime.Now),
                new Transaction(6, "Loch Ness Monster", 3.50, DateTime.Now)
            };

            return transactions.SingleOrDefault(_ => _.ID == id) ?? Transaction.Null();
        }
    }
}
