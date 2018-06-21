using FactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Models
{
    public class DodgeViper : Automobile, IAutomobile
    {
        public DodgeViper() : base ("Dodge", "Viper", 2, 202) { }
        public override void Drive()
        {
            Console.WriteLine($"*10 cylinders of fury rage as the {Color} Dodge Viper screams down the road*");
        }
    }
}
