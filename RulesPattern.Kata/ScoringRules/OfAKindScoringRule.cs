using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesPattern.Kata.ScoringRules
{
    public class OfAKindScoringRule : IGreedScoringRule
    {
        public int TestDieRollValue { get; }
        public int RuleScore { get; }
        public int RollCount { get; }

        public OfAKindScoringRule(int testDieRollValue, int rollCount, int score)
        {
            if (testDieRollValue <= 0 || testDieRollValue > 6)
                throw new ArgumentOutOfRangeException(nameof(testDieRollValue), $"A die value of {testDieRollValue} is invalid");
            if (score < 0)
                throw new ArgumentOutOfRangeException(nameof(score), "Score values cannot be negative");
            if (rollCount < 3 || rollCount > 6)
                throw new ArgumentOutOfRangeException(nameof(testDieRollValue), $"Roll count must be 3-6, inclusive");

            TestDieRollValue = testDieRollValue;
            RuleScore = score;
            RollCount = rollCount;
        }

        public int ScoreDice(IEnumerable<DiceRoll> UnevaluatedDiceRolls)
        {
            var score = 0;
            while (UnevaluatedDiceRolls.Where(r => !r.Evaluated).Count(r => r.NumberRolled == TestDieRollValue) >= RollCount)
            {
                score += RuleScore;

                // Update die as used to avoid double counting
                var dieUsed = 0;
                UnevaluatedDiceRolls
                    .Where(r => !r.Evaluated && r.NumberRolled == TestDieRollValue)
                    .ToList()
                    .ForEach(r =>
                    {
                        if (dieUsed < RollCount)
                        {
                            r.Evaluated = true;
                            dieUsed++;
                        }
                    });
            }
            return score;
        }
    }
}
