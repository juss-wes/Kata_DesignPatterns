using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesPattern.Kata.ScoringRules
{
    public class SingleScoringRule : IGreedScoringRule
    {
        public int TestDieRollValue { get; }
        public int RuleScore { get; }

        public SingleScoringRule(int testDieRollValue, int score)
        {
            if (testDieRollValue <= 0 || testDieRollValue > 6)
                throw new ArgumentOutOfRangeException(nameof(testDieRollValue), $"A die value of {testDieRollValue} is invalid");
            if (score < 0)
                throw new ArgumentOutOfRangeException(nameof(score), "Score values cannot be negative");

            TestDieRollValue = testDieRollValue;
            RuleScore = score;
        }

        public int ScoreDice(IEnumerable<DiceRoll> UnevaluatedDiceRolls)
        {
            var score = 0;
            foreach (var dice in UnevaluatedDiceRolls.Where(dice => dice.NumberRolled == TestDieRollValue))
            {
                dice.Evaluated = true;
                score += RuleScore;
            }
            return score;
        }
    }
}
