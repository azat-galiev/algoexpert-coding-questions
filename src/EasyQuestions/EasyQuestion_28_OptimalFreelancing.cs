namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/optimal-freelancing"/>
    /// Time: O(nlog(n))
    /// Space: O(1)
    internal class EasyQuestion_28_OptimalFreelancing : CodingQuestion<Dictionary<string, int>[], int>
    {
        protected override int ExecuteSolution(Dictionary<string, int>[] jobs)
        {
            Array.Sort(jobs, new ReversedComparer());
            var days = new int?[7];
            foreach (var job in jobs)
            {
                var i = Math.Min(6, job["deadline"] - 1);

                // Skipping all days when we're busy
                for (; i >= 0 && days[i] != null; i--) { }

                if (i >= 0 && days[i] == null)
                {
                    days[i] = job["payment"];
                }
            }

            return days.Where(x => x != null).Select(x => x.Value).Sum();
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<Dictionary<string, int>[], int> GetTests()
        {
            return new Dictionary<Dictionary<string, int>[], int>
            {
                {
                    new Dictionary<string, int>[]
                    {
                        new Dictionary<string, int> { { "deadline", 1 }, { "payment", 1 } },
                        new Dictionary<string, int> { { "deadline", 2 }, { "payment", 1 } },
                        new Dictionary<string, int> { { "deadline", 2 }, { "payment", 2 } },
                    },
                    3
                }
            };
        }

        internal class ReversedComparer : IComparer<Dictionary<string, int>>
        {
            public int Compare(Dictionary<string, int> x, Dictionary<string, int> y)
            {
                return y["payment"] - x["payment"];
            }
        }
    }
}
