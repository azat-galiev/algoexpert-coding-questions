namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/insertion-sort"/>
    /// Time: O(n^2) on average, O(n) best
    /// Space: O(1)
    internal class EasyQuestion_18_InsertionSort : CodingQuestion<int[], int[]>
    {
        protected override int[] ExecuteSolution(int[] input)
        {
            for (var i = 1; i < input.Length; i++)
            {
                for (var j = i; j > 0 && input[j] < input[j - 1]; j--)
                {
                    var temp = input[j];
                    input[j] = input[j - 1];
                    input[j - 1] = temp;
                }
            }

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
                { new int[] { 8, 5, 2, 9, 5, 6, 3 }, new int[] { 2, 3, 5, 5, 6, 8, 9 } },
            };
        }
    }
}
