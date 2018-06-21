using FactoryPattern.Interfaces;
using FactoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Factories
{
    public static class AutomobileFactory
    {
        public enum CarType
        {
            DailyDriver = 0,
            SportsCar = 1,
            Motorcycle = 2
        }

        public static IAutomobile GetAutomobileOfColor(CarType type, string color)
        {
            IAutomobile auto;
            switch (type)
            {
                case CarType.DailyDriver:
                    auto = new ToyotaCamry();
                    break;
                case CarType.SportsCar:
                    auto = new DodgeViper();
                    break;
                case CarType.Motorcycle:
                    auto = new HarleyDavidsonSuperLow();
                    break;
                default:
                    throw new Exception("Where did you find that enum???");
            }

            auto.Color = color;

            return auto;
        }

        public static IAutomobile GetRandomAutomobileOfColor(string color)
        {
            var carTypes = new[] { CarType.SportsCar, CarType.Motorcycle, CarType.DailyDriver };
            var randomIndex = new Random(DateTime.Now.Millisecond).Next(0, carTypes.Length - 1);
            var randomCarType = carTypes[randomIndex];
            return GetAutomobileOfColor(randomCarType, color);
        }
    }
}
