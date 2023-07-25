namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/task-assignment"/>
    /// Time: O(nlog(n))
    /// Space: O(n)
    internal class MediumQuestion_08_TaskAssignment : CodingQuestion<List<int>, List<List<int>>>
    {
        protected override List<List<int>> ExecuteSolution(List<int> tasks)
        {
            // We need to remember indicies before sorting the array.
            var timeToIndex = new Dictionary<int, Stack<int>>();
            for (var i = 0; i < tasks.Count; i++)
            {
                var time = tasks[i];

                if (!timeToIndex.ContainsKey(time))
                    timeToIndex[time] = new Stack<int>();

                timeToIndex[time].Push(i);
            }

            tasks.Sort((a, b) => a - b);

            // Make up pairs of quick and long tasks together.
            var pairs = new List<List<int>>();
            for (var i = 0; i < tasks.Count / 2; i++)
            {
                var quickTaskTime = tasks[i];
                var longTaskTime = tasks[tasks.Count - 1 - i];

                var quickTaskIndex = timeToIndex[quickTaskTime].Pop();
                var longTaskIndex = timeToIndex[longTaskTime].Pop();

                pairs.Add(new List<int> { quickTaskIndex, longTaskIndex });
            }

            return pairs;
        }

        protected override bool CompareActualAndExpectedOuputs(List<List<int>> expected, List<List<int>> actual)
        {
            if (expected.Count != actual.Count) return false;
            for (var i = 0; i < expected.Count; i++)
            {
                if (expected[i].Count != actual[i].Count) return false;
                for (var j = 0; j < expected[i].Count; j++)
                {
                    if (expected[i][j] != actual[i][j]) return false;
                }
            }

            return true;
        }

        protected override IReadOnlyDictionary<List<int>, List<List<int>>> GetTests()
        {
            return new Dictionary<List<int>, List<List<int>>>
            {
                {
                    new List<int> { 1, 3, 5, 3, 1, 4 },
                    new List<List<int>>
                    {
                        new List<int> { 4, 2 },
                        new List<int> { 0, 5 },
                        new List<int> { 3, 1 },
                    }
                }
            };
        }
    }
}
