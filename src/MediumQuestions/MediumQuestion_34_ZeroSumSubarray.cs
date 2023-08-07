namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/zero-sum-subarray"/>
    /// Time: O(n) where n is the number of elements in the input array.
    /// Space: O(n)
    internal class MediumQuestion_34_ZeroSumSubarray : CodingQuestion<int[], bool>
    {
        protected override bool ExecuteSolution(int[] nums)
        {
            // We'll keep track of all the sums of subarrays starting from the 1st element.
            var sums = new HashSet<int> { 0 };

            var sum = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                // If we already saw this value, it means that the sum of elements between
                // the 1st occurrence (let's say at index x) and the current one (at index y)
                // is 0, i.e. sum of elements between x and y is 0.
                if (sums.Contains(sum)) return true;

                sums.Add(sum);
            }

            return false;
        }

        protected override bool CompareActualAndExpectedOuputs(bool expected, bool actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<int[], bool> GetTests()
        {
            return new Dictionary<int[], bool>
            {
                { new int[] { -5, -5, 2, 3, -2}, true },
            };
        }
    }
}
