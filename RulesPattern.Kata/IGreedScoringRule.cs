using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesPattern.Kata
{
    public interface IGreedScoringRule
    {
        int ScoreDice(IEnumerable<DiceRoll> UnevaluatedDiceRolls);
        int RuleScore { get; }
    }
}
