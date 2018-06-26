using FactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Models
{
    public class HarleyDavidsonSuperLow : Automobile, IAutomobile
    {
        public HarleyDavidsonSuperLow() : base("Harley Davidson", "SuperLow", 0, 160) { }
        public override void Drive()
        {
            Console.WriteLine($"*Inaudible over engine noise of {Color} Harley Davidson SuperLow*");
        }
    }
}
