namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/merge-overlapping-intervals"/>
    /// Time: O(nlog(n)) where n is the number of input intervals
    /// Space: O(n)
    internal class MediumQuestion_12_MergeOverlappingIntervals : CodingQuestion<int[][], int[][]>
    {
        protected override int[][] ExecuteSolution(int[][] intervals)
        {
            // First, we sort intervals by their starts to allow sequential traversing through them.
            Array.Sort(intervals, new IntervalComparer());

            var result = new List<int[]>();
            for (var i = 0; i < intervals.Length; i++)
            {
                // If we already have some interval in the result,
                // we first check if we can expand it with the current interval.
                // If we can, then we do it, otherwise we add it as a separate interval.
                if (result.Count > 0 && result[result.Count - 1][1] >= intervals[i][0])
                {
                    result[result.Count - 1][1] = Math.Max(result[result.Count - 1][1], intervals[i][1]);
                    continue;
                }

                result.Add(intervals[i]);
            }

            return result.ToArray();
        }

        protected override bool CompareActualAndExpectedOuputs(int[][] expected, int[][] actual)
        {
            if (expected.Length != actual.Length) return false;
            for (var i = 0; i < expected.Length; i++)
            {
                if (expected[i].Length != actual[i].Length) return false;
                for (var j = 0; j < expected[i].Length; j++)
                {
                    if (expected[i][j] != actual[i][j]) return false;
                }
            }

            return true;
        }

        protected override IReadOnlyDictionary<int[][], int[][]> GetTests()
        {
            return new Dictionary<int[][], int[][]>
            {
                {
                    new int[][]
                    {
                        new int[] { 1, 2, },
                        new int[] { 3, 5, },
                        new int[] { 4, 7, },
                        new int[] { 6, 8, },
                        new int[] { 9, 10, },
                    },
                    new int[][]
                    {
                        new int[] { 1, 2, },
                        new int[] { 3, 8, },
                        new int[] { 9, 10, },
                    }
                }
            };
        }

        private class IntervalComparer : IComparer<int[]>
        {
            public int Compare(int[] a, int[] b)
            {
                return a[0] - b[0];
            }
        }
    }
}
