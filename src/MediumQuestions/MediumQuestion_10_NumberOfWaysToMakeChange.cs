namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/number-of-ways-to-make-change"/>
    /// Time: O(c * a), where c is the number of coins, a is the target amount
    /// Space: O(a)
    internal class MediumQuestion_10_NumberOfWaysToMakeChange : CodingQuestion<MediumQuestion_10_NumberOfWaysToMakeChange.Input, int>
    {
        protected override int ExecuteSolution(Input input)
        {
            // Index in this array is the amount we want to get using the coins.
            var amounts = new int[input.TargetAmount + 1];

            // That's our base case: there's only a single way to get amount of 0 (not use any coins at all).
            amounts[0] = 1;

            // We'll use dynamic programming here.
            // Let's spit the whole task into a set of simpler subtasks.
            foreach (var coin in input.Coins)
            {
                for (var amount = 1; amount <= input.TargetAmount; amount++)
                {
                    // If the coin even bigger than the whole amount,
                    // it's impossible to use it for this amount.
                    if (coin > amount) continue;

                    // If we need to make some amount using a given coin,
                    // we can make it one way more than an amount smaller
                    // than this amount by the size of the coin.
                    amounts[amount] += amounts[amount - coin];
                }
            }

            return amounts[input.TargetAmount];
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<Input, int> GetTests()
        {
            return new Dictionary<Input, int>
            {
                {
                    new Input
                    {
                        TargetAmount = 6,
                        Coins = new int[] { 1, 5 }
                    },
                    2
                }
            };
        }

        internal class Input
        {
            public int TargetAmount { get; set; }
            public required int[] Coins { get; set; }
        }
    }
}
