using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesPattern.Kata.ScoringRules
{
    public class SingleScoringRule : IGreedScoringRule
    {
        private readonly int _diceNumberToScore;
        private readonly int _pointValue;
        public int EvaluationOrder { get; private set; }

        public SingleScoringRule(int diceNumberToScore, int pointValue, int evaluationOrder)
        {
            _diceNumberToScore = diceNumberToScore;
            _pointValue = pointValue;
            EvaluationOrder = evaluationOrder;
        }

        public int ScoreDice(IEnumerable<DiceRoll> UnevaluatedDiceRolls)
        {
            var score = 0;
            foreach (var dice in UnevaluatedDiceRolls.Where(dice => dice.NumberRolled == _diceNumberToScore))
            { 
                dice.Evaluated = true;
                score += _pointValue;
            }
            return score;
        }
    }
}
