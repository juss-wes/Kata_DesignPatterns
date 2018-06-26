using FactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Models
{
    public class ToyotaCamry : Automobile, IAutomobile
    {
        public ToyotaCamry() : base("Toyota", "Camry", 4, 100) { }

        public override void Drive()
        {
            Console.WriteLine($"*Motor drones as the {Color} Toyota Camry rolls down the road*");
        }
    }
}
