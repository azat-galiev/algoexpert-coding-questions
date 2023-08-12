namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/longest-peak"/>
    /// Time: O(n) where n is the number of elements in the array.
    /// Space: O(1)
    internal class MediumQuestion_43_LongestPeak : CodingQuestion<int[], int>
    {
        protected override int ExecuteSolution(int[] array)
        {
            var peakStart = -1;
            var peakEnd = -1;
            var longestPeak = 0;

            for (var i = 1; i < array.Length; i++)
            {
                // Outside of peak.
                if (peakStart == -1 && peakEnd == -1)
                {
                    // Peak started growing.
                    if (array[i - 1] < array[i]) peakStart = i - 1;
                }
                // Inside a growing peak.
                else if (peakStart != -1 && peakEnd == -1)
                {
                    // Peak is still growing.
                    if (array[i - 1] < array[i])
                    {
                        // no-op
                    }
                    // It's not actually a peak.
                    else if (array[i - 1] == array[i])
                    {
                        peakStart = -1;
                        peakEnd = -1;
                    }
                    // Peak started decaying.
                    else if (array[i - 1] > array[i])
                    {
                        peakEnd = i;
                    }
                }
                // Inside a decaying peak.
                else if (peakStart != -1 && peakEnd != -1)
                {
                    // Peak is still decaying.
                    if (array[i - 1] > array[i])
                    {
                        peakEnd = i;
                    }
                    // Peak stopped decaying.
                    else if (array[i - 1] <= array[i])
                    {
                        longestPeak = Math.Max(longestPeak, peakEnd - peakStart + 1);
                        peakStart = -1;
                        peakEnd = -1;

                        // A new peak immediately started.
                        if (array[i - 1] < array[i])
                            peakStart = i - 1;
                    }
                }
            }

            if (peakStart != -1 && peakEnd != -1)
                longestPeak = Math.Max(longestPeak, peakEnd - peakStart + 1);

            return longestPeak;
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<int[], int> GetTests()
        {
            return new Dictionary<int[], int>
            {
                { new int[] { 1, 2, 3, 3, 4, 0, 10, 6, 5, -1, -3, 2, 3 }, 6 },
            };
        }
    }
}
