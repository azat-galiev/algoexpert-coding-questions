namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/single-cycle-check"/>
    /// Time: O(n) where n is the number of elements
    /// Space: O(1)
    internal class MediumQuestion_31_SingleCycleCheck : CodingQuestion<int[], bool>
    {
        protected override bool ExecuteSolution(int[] array)
        {
            // We'll keep track of how many times we jumped.
            var jumps = 0;
            var currentIndex = 0;

            // If we jumped more times than there are elements,
            // then we've got into an inner loop.
            while (jumps < array.Length)
            {
                // If we reached the first element inside the while, it means that we didn't traverse through
                // all the elements, otherwise while's condition wouldn't be satisfied.
                if (currentIndex == 0 && jumps > 0) return false;

                jumps++;

                // Calculate the next element handling overflows.
                currentIndex += array[currentIndex];
                currentIndex %= array.Length;
                if (currentIndex < 0)
                    currentIndex += array.Length;
            }

            return currentIndex == 0;
        }

        protected override bool CompareActualAndExpectedOuputs(bool expected, bool actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<int[], bool> GetTests()
        {
            return new Dictionary<int[], bool>
            {
                { new int[] { 2, 3, 1, -4, -4, 2 }, true }
            };
        }
    }
}
