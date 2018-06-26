using System;

namespace NullObjectPattern.Models
{
    public class NullTransaction : Transaction
    {
        public NullTransaction()
        {
            ID = 0;
            Name = "No Sale";
            Cost = 0.00d;
            Date = DateTime.MinValue;
        }

        public override void ProcessTransaction()
        {
            // Since this is a null sale, we still have this function, but do something else!
            Console.WriteLine("Null handled!");
        }
    }
}
