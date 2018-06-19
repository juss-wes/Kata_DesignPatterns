using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Models
{
    public class ToyotaCamry : Automobile
    {
        public ToyotaCamry() : base("Toyota", "Camry", 4, 100) { }

        public override void Drive()
        {
            Console.WriteLine($"*Motor drones as {Color} Camry rolls down the road*");
        }
    }
}
