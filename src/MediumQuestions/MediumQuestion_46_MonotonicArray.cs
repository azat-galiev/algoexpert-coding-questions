namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/monotonic-array"/>
    /// Time: O(n)
    /// Space: O(1)
    internal class MediumQuestion_46_MonotonicArray : CodingQuestion<int[], bool>
    {
        protected override bool ExecuteSolution(int[] array)
        {
            var direction = Direction.Undefined;

            for (var i = 1; i < array.Length; i++)
            {
                // The value neither increasing nor decreasing, so skipping.
                if (array[i - 1] == array[i]) continue;

                // If direction is not defined yet, just determine it for the future, and that's it.
                if (direction == Direction.Undefined)
                {
                    direction = array[i - 1] < array[i]
                        ? Direction.Increasing
                        : Direction.Decreasing;
                }
                // We were increasing, but suddently decreased.
                else if (direction == Direction.Increasing && array[i - 1] > array[i])
                {
                    return false;
                }
                // We were decreasing, but suddently increased.
                else if (direction == Direction.Decreasing && array[i - 1] < array[i])
                {
                    return false;
                }
            }

            return true;
        }

        private enum Direction
        {
            Undefined,
            Increasing,
            Decreasing,
        }

        protected override bool CompareActualAndExpectedOuputs(bool expected, bool actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<int[], bool> GetTests()
        {
            return new Dictionary<int[], bool>
            {
                { new int[] { -1, -5, -10, -1100, -1100, -1101, -1102, -9001 }, true }
            };
        }
    }
}
