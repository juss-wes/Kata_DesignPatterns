using System;

namespace NullObjectPattern.Models
{
    public class Transaction
    {
        public static NullTransaction Null() => new NullTransaction();

        public int ID { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public double Cost { get; set; } = 0.00d;
        public DateTime Date { get; set; } = DateTime.MinValue;

        public Transaction()
        { }

        public Transaction(int id, string name, double cost, DateTime date)
        {
            ID = id;
            Name = name;
            Cost = cost;
            Date = date;
        }

        public virtual void ProcessTransaction()
        {
            // Save/charge transaction using whatever method that might use
            Console.WriteLine($"Transaction {ID} for {Cost} Processed");
        }
    }
}
