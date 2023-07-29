namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/levenshtein-distance"/>
    /// Time: O(n * m) where n is the length of str1, m is the length of str2
    /// Space: O(min(n, m))
    internal class MediumQuestion_15_LevenshteinDistance : CodingQuestion<Tuple<string, string>, int>
    {
        protected override int ExecuteSolution(Tuple<string, string> input)
        {
            var small = input.Item1.Length < input.Item2.Length ? input.Item1 : input.Item2;
            var big = input.Item1.Length >= input.Item2.Length ? input.Item1 : input.Item2;

            // We'll store only the last two rows (evenEdits, oddEdits) 
            // in our DP matrix to improve space complexity,
            // because we don't actually need the whole matrix.
            var evenEdits = new int[small.Length + 1];
            var oddEdits = new int[small.Length + 1];

            // Initialize the first row, because it looks
            // exactly the same on any input data.
            for (var i = 0; i < evenEdits.Length; i++) evenEdits[i] = i;

            // Iterate over rows.
            for (var i = 1; i < big.Length + 1; i++)
            {
                // Swap the current and previous rows depending on the evenness of the row.
                int[] currentEdits;
                int[] previousEdits;
                if (i % 2 == 1)
                {
                    currentEdits = oddEdits;
                    previousEdits = evenEdits;
                }
                else
                {
                    currentEdits = evenEdits;
                    previousEdits = oddEdits;
                }

                // The very first column always looks the same, the same way as the very first row.
                currentEdits[0] = i;

                // Iterate over columns.
                for (var j = 1; j < small.Length + 1; j++)
                {
                    // If letters are the same, we use the value to the top-left.
                    if (big[i - 1] == small[j - 1])
                        currentEdits[j] = previousEdits[j - 1];
                    // If letters are different, we take the minimum from 3 sides, and add 1.
                    else
                        currentEdits[j] = 1 + Math.Min(
                            previousEdits[j - 1],
                            Math.Min(previousEdits[j], currentEdits[j - 1]));
                }
            }

            // We need to determine the last current row again (we did that inside the loop).
            return big.Length % 2 == 0
                ? evenEdits[evenEdits.Length - 1]
                : oddEdits[oddEdits.Length - 1];
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<Tuple<string, string>, int> GetTests()
        {
            return new Dictionary<Tuple<string, string>, int>
            {
                {
                    new Tuple<string, string>("abc", "yabd"),
                    2
                }
            };
        }
    }
}
