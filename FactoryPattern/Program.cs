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

            var camry = AutomobileFactory.GetAutomobileOfColor(AutomobileFactory.CarType.ToyotaCamry, color);
            camry.Drive();

            var viper = AutomobileFactory.GetAutomobileOfColor(AutomobileFactory.CarType.DodgeViper, color);
            viper.Drive();

            var superLow = AutomobileFactory.GetAutomobileOfColor(AutomobileFactory.CarType.HarleyDavidsonSuperLow, color);
            superLow.Drive();

            var randomAuto = AutomobileFactory.GetRandomAutomobileOfColor(color);
            randomAuto.Drive();

            camry = AutomobileFactory.GetAutomobileOfColor<ToyotaCamry>(color);
            camry.Drive();

            viper = AutomobileFactory.GetAutomobileOfColor<DodgeViper>(color);
            viper.Drive();

            superLow = AutomobileFactory.GetAutomobileOfColor<HarleyDavidsonSuperLow>(color);
            superLow.Drive();
        }
    }
}
