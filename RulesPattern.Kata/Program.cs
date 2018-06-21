using RulesPattern.Kata.ScoringRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesPattern.Kata
{
    class Program
    {
        private const int _fourOfAKindMultiplier = 2;
        private const int _fiveOfAKindMultiplier = 4;
        private const int _sixOfAKindMultiplier = 5;

        static void Main(string[] args)
        {
            var exit = false;
            var scoreEngine = new ScoreEngine(getGreedScoringRules());
            while (!exit)
            {
                var diceRolls = RollDice();
                scoreEngine.ScoreDiceRolls(diceRolls);
                Console.WriteLine("Press Y to play again, anything else to quit");
                exit = Console.ReadLine().ToUpper() != "Y";
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

        private static IEnumerable<IGreedScoringRule> getGreedScoringRules()
        {
            var scoringRules = new List<IGreedScoringRule>();
            for (var i = 1; i <= 6; i++)
            {
                //determine base score
                var baseScore = i * 100;
                if (i == 1) baseScore *= 10;

                //add rule for 3, 4, 5, 6 of a kind
                scoringRules.Add(new OfAKindScoringRule(i, 3, baseScore));
                scoringRules.Add(new OfAKindScoringRule(i, 4, baseScore * _fourOfAKindMultiplier));
                scoringRules.Add(new OfAKindScoringRule(i, 5, baseScore * _fiveOfAKindMultiplier));
                scoringRules.Add(new OfAKindScoringRule(i, 6, baseScore * _sixOfAKindMultiplier));
            }

            scoringRules.Add(new ThreePairsScoringRule(800));

            scoringRules.Add(new StraightScoringRule(1200));

            scoringRules.Add(new SingleScoringRule(1, 100));
            scoringRules.Add(new SingleScoringRule(5, 50));
            return scoringRules;
        }
    }
}
