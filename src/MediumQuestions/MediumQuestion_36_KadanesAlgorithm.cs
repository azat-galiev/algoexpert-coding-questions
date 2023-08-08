namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/kadane's-algorithm"/>
    /// Time: O(n) where n is the number of elements in the array
    /// Space: O(1)
    internal class MediumQuestion_36_KadanesAlgorithm : CodingQuestion<int[], int>
    {
        protected override int ExecuteSolution(int[] array)
        {
            var maxEndingHere = array[0];
            var maxSoFar = array[0];

            // At every element, we calculate the maximum sum of any subarray including the current element,
            // and we also track the maximum sum of any subarray we saw so far (that will be our result in the end).
            for (var i = 1; i < array.Length; i++)
            {
                // If the current element itself is larger than the sum of any possible subarray before it,
                // it doesn't worth adding it up to it, rather just take the current element, and dismiss
                // any elements before it.
                maxEndingHere = Math.Max(array[i], array[i] + maxEndingHere);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }

            return maxSoFar;
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
                    new int[] { 3, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4 },
                    19
                }
            };
        }
    }
}
