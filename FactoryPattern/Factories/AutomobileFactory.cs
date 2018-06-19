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
            ToyotaCamry = 0,
            DodgeViper = 1,
            HarleyDavidsonSuperLow = 2
        }

        public static Automobile GetAutomobileOfColor<T>(string color) where T: Automobile, new()
        {
            var auto = new T();
            auto.Color = color;

            return auto;
        }

        public static Automobile GetAutomobileOfColor(CarType type, string color)
        {
            Automobile auto;
            switch (type)
            {
                case CarType.ToyotaCamry:
                    auto = new ToyotaCamry();
                    break;
                case CarType.DodgeViper:
                    auto = new DodgeViper();
                    break;
                case CarType.HarleyDavidsonSuperLow:
                    auto = new HarleyDavidsonSuperLow();
                    break;
                default:
                    throw new Exception("Where did you find that enum???");
            }

            auto.Color = color;

            return auto;
        }

        public static Automobile GetRandomAutomobileOfColor(string color)
        {
            var carTypes = new[] { CarType.DodgeViper, CarType.HarleyDavidsonSuperLow, CarType.ToyotaCamry };
            var randomIndex = new Random(DateTime.Now.Millisecond).Next(0, carTypes.Length - 1);
            var randomCarType = carTypes[randomIndex];
            return GetAutomobileOfColor(randomCarType, color);
        }
    }
}
