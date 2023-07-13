namespace CodingQuestions.EasyQuestions
{
    /// <see cref="https://www.algoexpert.io/questions/common-characters"/>
    /// Time: O(n * m) where n is the number of strings, and m is the length of the longest string
    /// Space: O(m)
    internal class EasyQuestion_14_CommonCharacters : CodingQuestion<List<string>, List<char>>
    {
        protected override List<char> ExecuteSolution(List<string> input)
        {
            var dictionary = new Dictionary<char, bool[]>();
            var i = 0;
            foreach (var str in input)
            {
                foreach (var @char in str)
                {
                    if (!dictionary.ContainsKey(@char))
                    {
                        dictionary.Add(@char, new bool[input.Count]);
                    }

                    dictionary[@char][i] = true;
                }

                i++;
            }

            var result = new List<char>();
            foreach (var @char in dictionary.Keys)
            {
                var charUsedIn = 0;
                foreach (var usedInString in dictionary[@char])
                {
                    if (!usedInString) break;

                    charUsedIn++;
                }

                if (charUsedIn == input.Count) result.Add(@char);
            }

            return result;
        }

        protected override bool CompareActualAndExpectedOuputs(List<char> expected, List<char> actual)
        {
            if (expected.Count != actual.Count) return false;

            for (var i = 0; i < expected.Count; i++)
            {
                if (actual[i] != expected[i]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<List<string>, List<char>> GetTests()
        {
            return new Dictionary<List<string>, List<char>>
            {
                { new List<string> { "abcp", "bcd", "cbaccd" }, new List<char> { 'b', 'c' } },
            };
        }
    }
}
