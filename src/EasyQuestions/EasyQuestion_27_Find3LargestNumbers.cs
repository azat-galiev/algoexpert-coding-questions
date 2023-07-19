namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/find-three-largest-numbers"/>
    /// Time: O(n)
    /// Space: O(1)
    internal class EasyQuestion_27_Find3LargestNumbers : CodingQuestion<int[], int[]>
    {
        protected override int[] ExecuteSolution(int[] array)
        {
            var largestNumbers = new int?[3];

            // Iterating over input array
            for (var i = 0; i < array.Length; i++)
            {
                // Iterating over the list of largest numbers to find if current number is larger than some of them
                for (var j = 2; j >= 0; j--)
                {
                    // If we didn't store any number at all, just store it right away
                    if (largestNumbers[j] == null)
                    {
                        largestNumbers[j] = array[i];
                        break;
                    }

                    // If we did store something before, but it's smaller, then...
                    if (largestNumbers[j] < array[i])
                    {
                        // Shift all the largest numbers to the left, to give new largest number the room
                        for (var k = 1; k <= j; k++)
                        {
                            largestNumbers[k - 1] = largestNumbers[k];
                        }

                        largestNumbers[j] = array[i];
                        break;
                    }
                }
            }

            return new int[]
            {
                largestNumbers[0].Value,
                largestNumbers[1].Value,
                largestNumbers[2].Value,
            };
        }

        protected override bool CompareActualAndExpectedOuputs(int[] expected, int[] actual)
        {
            if (expected.Length != actual.Length) return false;
            for (var i = 0; i < expected.Length; i++)
            {
                if (actual[i] != expected[i]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<int[], int[]> GetTests()
        {
            return new Dictionary<int[], int[]>
            {
                { new int[] { 141, 1, 17, -7, -17, -27, 18, 541, 8, 7, 7 }, new int[] { 18, 141, 541 } },
            };
        }
    }
}
