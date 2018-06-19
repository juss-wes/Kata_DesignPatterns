using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Models
{
    public abstract class Automobile
    {
        protected Automobile(string make, string model, int doors, int topSpeed)
        {
            Make = make;
            Model = model;
            Doors = doors;
            TopSpeed = topSpeed;
        }
        protected string Make { get; set; }
        protected string Model { get; set; }
        protected int Doors { get; set; }
        protected int TopSpeed { get; set; }
        public string Color { get; set; }
        public abstract void Drive();
    }
}
