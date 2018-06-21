using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Interfaces
{
    public interface IAutomobile
    {
        string Make { get; set; }
        string Model { get; set; }
        int Doors { get; set; }
        int TopSpeed { get; set; }
        string Color { get; set; }
        void Drive();
    }
}
