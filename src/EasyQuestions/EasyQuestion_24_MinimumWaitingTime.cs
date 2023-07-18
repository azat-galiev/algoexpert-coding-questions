namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/minimum-waiting-time"/>
    /// Time: O(nlog(n))
    /// Space: O(1)
    internal class EasyQuestion_24_MinimumWaitingTime : CodingQuestion<int[], int>
    {
        protected override int ExecuteSolution(int[] queries)
        {
            Array.Sort(queries);

            var currentWaitingTime = 0;
            var totalWaitingTime = 0;
            for (var i = 0; i < (queries.Length - 1); i++)
            {
                currentWaitingTime += queries[i];
                totalWaitingTime += currentWaitingTime;
            }

            return totalWaitingTime;
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<int[], int> GetTests()
        {
            return new Dictionary<int[], int>
            {
                { new int[] { 3, 2, 1, 2, 6 }, 17 },
            };
        }
    }
}
