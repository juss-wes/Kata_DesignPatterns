using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesPattern.Kata
{
    public class ScoreEngine
    {
        private readonly IEnumerable<IGreedScoringRule> _scoringRules;

        public ScoreEngine(IEnumerable<IGreedScoringRule> greedScoringRules)
        {
            _scoringRules = greedScoringRules;
        }

        public int ScoreDiceRolls(IEnumerable<DiceRoll> diceRolls)
        {
            var score = 0;
            foreach (var rule in _scoringRules.OrderByDescending(rule => rule.RuleScore))
            {
                score += rule.ScoreDice(diceRolls.Where(x => x.Evaluated == false));
            }
            Console.WriteLine($"Your total score was {score}");
            return score;
        }
    }
}
