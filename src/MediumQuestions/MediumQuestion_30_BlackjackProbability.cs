namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/blackjack-probability"/>
    /// Time: O(t - s) where t is the target, s is the starting hard
    /// Space: O(t - s)
    internal class MediumQuestion_30_BlackjackProbability : CodingQuestion<Tuple<int, int>, float>
    {
        protected override float ExecuteSolution(Tuple<int, int> input)
        {
            var target = input.Item1;
            var startingHand = input.Item2;

            // That's where we store already calculated probability for different hands,
            // because we'll most likely need it multiple times
            var memo = new Dictionary<int, float>();

            return (float)Math.Round(CalculateProbability(target, startingHand, memo), 3);
        }

        private float CalculateProbability(int target, int hand, Dictionary<int, float> memo)
        {
            // We already calculated probability for this hand, so just returning it.
            if (memo.ContainsKey(hand)) return memo[hand];

            // So, we already busted, so probability of busting is 100% in that case.
            if (hand > target) return 1.0f;

            // We're within allowed range to stop, which means that probability of busting is 0%.
            if (hand + 4 >= target) return 0.0f;

            var totalProbability = 0.0f;

            // We multiply it by 0.1 (10%) because probability of getting every card is only 10%.
            for (var card = 1; card <= 10; card++)
                totalProbability += 0.1f * CalculateProbability(target, hand + card, memo);

            memo[hand] = totalProbability;
            return totalProbability;
        }

        protected override bool CompareActualAndExpectedOuputs(float expected, float actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<Tuple<int, int>, float> GetTests()
        {
            return new Dictionary<Tuple<int, int>, float>
            {
                {
                    new Tuple<int, int>(21, 15),
                    0.45f
                }
            };
        }
    }
}
