namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/bubble-sort"/>
    /// Time: O(n^2)
    /// Space: O(1)
    internal class EasyQuestion_17_BubbleSort : CodingQuestion<int[], int[]>
    {
        protected override int[] ExecuteSolution(int[] input)
        {
            bool thereWereSwaps;
            do
            {
                thereWereSwaps = false;
                for (var i = 1; i < input.Length; i++)
                {
                    if (input[i] < input[i - 1])
                    {
                        thereWereSwaps = true;

                        var temp = input[i];
                        input[i] = input[i - 1];
                        input[i - 1] = temp;
                    }
                }
            }
            while (thereWereSwaps);

            return input;
        }

        protected override bool CompareActualAndExpectedOuputs(int[] expected, int[] actual)
        {
            if (expected.Length != actual.Length) return false;
            for (var i = 0; i < expected.Length; i++)
            {
                if (actual[i] != expected[i]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<int[], int[]> GetTests()
        {
            return new Dictionary<int[], int[]>
            {
                {  new int[] { 8, 5, 2, 9, 5, 6, 3 }, new int[] { 2, 3, 5, 5, 6, 8, 9} },
            };
        }
    }
}
