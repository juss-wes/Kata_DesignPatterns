using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesPattern.Kata.ScoringRules
{
    public class StraightScoringRule : IGreedScoringRule
    {
        public int RuleScore { get; }

        public StraightScoringRule(int score)
        {
            if (score < 0)
                throw new ArgumentOutOfRangeException(nameof(score), "Score values cannot be negative");

            RuleScore = score;
        }

        public int ScoreDice(IEnumerable<DiceRoll> UnevaluatedDiceRolls)
        {
            var score = 0;

            if (UnevaluatedDiceRolls.Count() == 6 && UnevaluatedDiceRolls.GroupBy(dice => dice.NumberRolled).All(diceWithSameNumberRoll => diceWithSameNumberRoll.Count() == 1))
            {
                score += RuleScore;
                foreach (var dice in UnevaluatedDiceRolls)
                    dice.Evaluated = true;
            }

            return score;
        }
    }
}
