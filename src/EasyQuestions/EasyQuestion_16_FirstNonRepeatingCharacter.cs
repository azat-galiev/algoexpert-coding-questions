namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/first-non-repeating-character"/>
    /// Time: O(n) where n is the number of characters
    /// Space: O(n)
    internal class EasyQuestion_16_FirstNonRepeatingCharacter : CodingQuestion<string, int>
    {
        protected override int ExecuteSolution(string input)
        {
            var hashTable = new Dictionary<char, int[]>();
            var i = 0;
            foreach (var @char in input)
            {
                if (!hashTable.ContainsKey(@char))
                {
                    hashTable.Add(@char, new int[] { i, 0 });
                }

                hashTable[@char][1]++;
                i++;
            }

            int? minimalIndex = null;
            foreach (var @char in hashTable.Keys)
            {
                var el = hashTable[@char];
                if (el[1] == 1 && (minimalIndex == null || el[0] < minimalIndex))
                {
                    minimalIndex = el[0];
                }
            }

            return minimalIndex ?? -1;
        }
        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<string, int> GetTests()
        {
            return new Dictionary<string, int>
            {
                { "abcdcaf", 1 } 
            };
        }
    }
}
