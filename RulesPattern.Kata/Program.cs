using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesPattern.Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var exit = false;
            while (!exit)
            {
                var diceRolls = RollDice();
                ScoreCalculator.ScoreRolls(diceRolls);
                Console.WriteLine("Press Y to play again, anything else to quit");
                exit = Console.ReadKey().KeyChar == 'Y';
                if (!exit)
                    Console.WriteLine();
            }
        }

        private static List<DiceRoll> RollDice()
        {
            Console.WriteLine("How many dice would you like to roll? (1-6)");
            var rollCount = 0;
            var exit = false;
            while (!exit)
            {
                if(!int.TryParse(Console.ReadLine(), out rollCount) || !(rollCount > 0 && rollCount < 7))
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a number (1-6)");
                }
                else
                {
                    Console.WriteLine();
                    exit = true;
                }
            }
            var diceRolls = new List<DiceRoll>();
            for (var i = 0; i < rollCount; i++)
            {
                diceRolls.Add(new DiceRoll());
            }
            Console.WriteLine($"You rolled: [{string.Join(",", diceRolls.Select(x => x.NumberRolled))}]");
            return diceRolls;
        }
    }
}
