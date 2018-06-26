using FactoryPattern.Factories;
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

            var dailyDriver = AutomobileFactory.GetAutomobileOfColor(AutomobileFactory.CarType.DailyDriver, color);
            dailyDriver.Drive();

            var sportsCar = AutomobileFactory.GetAutomobileOfColor(AutomobileFactory.CarType.SportsCar, color);
            sportsCar.Drive();

            var motorcycle = AutomobileFactory.GetAutomobileOfColor(AutomobileFactory.CarType.Motorcycle, color);
            motorcycle.Drive();

            Console.ReadKey();
        }
    }
}
