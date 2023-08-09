namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/first-duplicate-value"/>
    /// Time: O(n) where n is the length of the input array.
    /// Space: O(1)
    internal class MediumQuestion_37_FirstDuplicateValue : CodingQuestion<int[], int>
    {
        protected override int ExecuteSolution(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                // Value might be "as is" (positive), or might be "flagged" (negative).
                // We're interested in the actual (positive) value.
                var value = Math.Abs(array[i]);

                // Check if current value is "flagged".
                var index = value - 1;
                if (array[index] < 0) return value;

                // Since we can mutate the input array, we can "flag" places which numbers
                // we already saw. For example, a place for number 2 is  array[1], i.e. 
                // its inddex is value - 1. We can safely do that because prompt says 
                // that numbers are in the range 1..n.
                array[index] *= -1;
            }

            return -1;
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<int[], int> GetTests()
        {
            return new Dictionary<int[], int>
            {
                {
                    new int[] { 2, 1, 5, 2, 3, 3, 4 },
                    2
                }
            };
        }
    }
}
