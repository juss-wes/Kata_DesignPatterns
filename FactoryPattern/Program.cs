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

            var camry = new ToyotaCamry();
            camry.Color = color;
            camry.Drive();

            var viper = new DodgeViper();
            viper.Color = color;
            viper.Drive();

            var superLow = new HarleyDavidsonSuperLow();
            superLow.Color = color;
            superLow.Drive();

            Automobile randomAuto;
            switch (new Random(DateTime.Now.Millisecond).Next(0, 2))
            {
                case 0:
                    randomAuto = new ToyotaCamry();
                    break;
                case 1:
                    randomAuto = new DodgeViper();
                    break;
                case 2:
                    randomAuto = new HarleyDavidsonSuperLow();
                    break;
                default:
                    throw new Exception("Unexpected random number.");
            }
            randomAuto.Color = color;
            randomAuto.Drive();
        }
    }
}
