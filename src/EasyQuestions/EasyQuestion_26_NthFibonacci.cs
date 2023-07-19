namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/nth-fibonacci"/>
    /// Time: O(n)
    /// Space: O(1)
    internal class EasyQuestion_26_NthFibonacci : CodingQuestion<int, int>
    {
        protected override int ExecuteSolution(int n)
        {
            if (n == 1) return 0;
            if (n == 2) return 1;

            var nMinus1 = 1;
            var nMinus2 = 0;
            var result = 0;
            for (var i = 3; i <= n; i++)
            {
                result = nMinus1 + nMinus2;
                nMinus2 = nMinus1;
                nMinus1 = result;
            }

            return result;
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<int, int> GetTests()
        {
            return new Dictionary<int, int>
            {
                { 1, 0 },
                { 2, 1 },
                { 3, 1 },
                { 4, 2 },
                { 5, 3 },
                { 6, 5 },
            };
        }
    }
}
