using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesPattern.Kata
{
    public static class ScoreCalculator
    {
        private const int _tripleOnes = 1000;
        private const int _tripleTwos = 200;
        private const int _tripleThrees = 300;
        private const int _tripleFours = 400;
        private const int _tripleFives = 500;
        private const int _tripleSixes = 600;
        private const int _singleOne = 100;
        private const int _singleFive = 50;
        private const int _straight = 1200;
        private const int _threePairs = 800;

        public static void ScoreRolls(List<DiceRoll> diceRolls)
        {
            var score = 0;
            var unevaluated = diceRolls.Where(dice => dice.Evaluated == false);

            //check for 6 of a kind
            if(unevaluated.Count() == 6 && unevaluated.All(dice => dice.NumberRolled == diceRolls.First().NumberRolled))
            {
                //score 6 of a kind
                score += getTriplesScore(unevaluated.First().NumberRolled) * 8;
                foreach (var dice in diceRolls)
                    dice.Evaluated = true;
            }

            //check for 5 of a kind
            if (unevaluated.GroupBy(dice => dice.NumberRolled).Any(diceWithSameNumberRoll => diceWithSameNumberRoll.Count() == 5))
            {
                //score 5 of a kind
                var fiveOfAKindRolled = unevaluated.GroupBy(dice => dice.NumberRolled).First(diceWithSameNumberRoll => diceWithSameNumberRoll.Count() == 5).Key;
                score += getTriplesScore(fiveOfAKindRolled) * 4;
                foreach (var dice in unevaluated.Where(x => x.NumberRolled ==fiveOfAKindRolled))
                    dice.Evaluated = true;
            }

            //check for 4 of a kind
            if (unevaluated.GroupBy(dice => dice.NumberRolled).Any(diceWithSameNumberRoll => diceWithSameNumberRoll.Count() == 4))
            {
                //score 4 of a kind
                var fourOfAKindRolled = unevaluated.GroupBy(dice => dice.NumberRolled).First(diceWithSameNumberRoll => diceWithSameNumberRoll.Count() == 4).Key;
                score += getTriplesScore(fourOfAKindRolled) * 2;
                foreach (var dice in unevaluated.Where(x => x.NumberRolled == fourOfAKindRolled))
                    dice.Evaluated = true;
            }

            //check for any 3 of a kinds
            var threeOfAKinds = unevaluated.GroupBy(dice => dice.NumberRolled).Where(diceWithSameNumberRoll => diceWithSameNumberRoll.Count() == 3);
            foreach (var threeOfAKind in threeOfAKinds)
            {
                //score 3 of a kind
                score += getTriplesScore(threeOfAKind.Key);
                foreach (var dice in unevaluated.Where(x => x.NumberRolled == threeOfAKind.Key))
                    dice.Evaluated = true;
            }

            //check for straight
            if(unevaluated.Count() == 6 && unevaluated.GroupBy(dice => dice.NumberRolled).All(diceWithSameNumberRoll => diceWithSameNumberRoll.Count() == 1))
            {
                //score straight
                score += _straight;
                foreach (var dice in diceRolls)
                    dice.Evaluated = true;
            }

            //check for Three Pairs
            if (unevaluated.Count() == 6 && unevaluated.GroupBy(dice => dice.NumberRolled).All(diceWithSameNumberRoll => diceWithSameNumberRoll.Count() == 2))
            {
                //score straight
                score += _threePairs;
                foreach (var dice in diceRolls)
                    dice.Evaluated = true;
            }

            //check for single one
            if(unevaluated.Any(dice => dice.NumberRolled == 1))
            {
                //score any unevaluated ones rolled
                score += _singleOne * unevaluated.Count(dice => dice.NumberRolled == 1);
                foreach (var dice in unevaluated.Where(dice => dice.NumberRolled == 1))
                    dice.Evaluated = true;
            }

            //check for single five
            if (unevaluated.Any(dice => dice.NumberRolled == 5))
            {
                //score any unevaluated fives rolled
                score += _singleFive * unevaluated.Count(dice => dice.NumberRolled == 5);
                foreach (var dice in unevaluated.Where(dice => dice.NumberRolled == 5))
                    dice.Evaluated = true;
            }

            Console.WriteLine($"Your total score was {score}");
        }

        private static int getTriplesScore(int tripleRolled)
        {
            switch (tripleRolled)
            {
                case 1:
                    return _tripleOnes;
                case 2:
                    return _tripleTwos;
                case 3:
                    return _tripleThrees;
                case 4:
                    return _tripleFours;
                case 5:
                    return _tripleFives;
                case 6:
                    return _tripleSixes;
                default:
                    throw new ArgumentOutOfRangeException("The number rolled was not 1-6!");
            }
        }
    }
}
