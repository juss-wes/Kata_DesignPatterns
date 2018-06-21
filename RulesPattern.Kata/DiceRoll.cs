using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesPattern.Kata
{
    public class DiceRoll
    {
        private static Random _rand = new Random();
        public bool Evaluated { get; set; } = false;
        public int NumberRolled { get; set; } = _rand.Next(1, 7);
    }
}
