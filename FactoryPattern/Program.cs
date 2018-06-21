using FactoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var color = "Red";

            var dailyDriver = new ToyotaCamry();
            dailyDriver.Color = color;
            dailyDriver.Drive();

            var sportsCar = new DodgeViper();
            sportsCar.Color = color;
            sportsCar.Drive();

            var motorcycle = new HarleyDavidsonSuperLow();
            motorcycle.Color = color;
            motorcycle.Drive();
        }
    }
}
