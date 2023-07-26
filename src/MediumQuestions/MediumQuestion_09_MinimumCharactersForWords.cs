namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/minimum-characters-for-words"/>
    /// Time: O(n * l) where n is the number of words, l is the length of the longest word
    /// Space: O(c) where c is the number of unique characters across all words
    internal class MediumQuestion_09_MinimumCharactersForWords : CodingQuestion<string[], string[]>
    {
        protected override string[] ExecuteSolution(string[] words)
        {
            var charCounts = new Dictionary<char, int>();

            // Let's iterate over words, and every char inside them.
            foreach (var word in words)
            {
                var wordCharCounts = new Dictionary<char, int>();
                foreach (var @char in word)
                {
                    if (!wordCharCounts.ContainsKey(@char)) wordCharCounts.Add(@char, 0);

                    // We count how many times we saw the char in the current word.
                    wordCharCounts[@char]++;

                    // Then, if we didn't see this specific char so many times in other words, we record it.
                    if (!charCounts.ContainsKey(@char) || charCounts[@char] < wordCharCounts[@char])
                        charCounts[@char] = wordCharCounts[@char];
                }
            }

            // Now, we have all the counts, we only need to convert it to the expected form.
            var result = new List<string>();
            foreach (var @char in charCounts.Keys)
            {
                var count = charCounts[@char];
                for (var i = 0; i < count; i++) result.Add(@char.ToString());
            }

            return result.ToArray();
        }

        protected override bool CompareActualAndExpectedOuputs(string[] expected, string[] actual)
        {
            if (expected.Length != actual.Length) return false;

            Array.Sort(expected);
            Array.Sort(actual);

            for (var i = 0; i < expected.Length; i++)
            {
                if (expected[i] != actual[i]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<string[], string[]> GetTests()
        {
            return new Dictionary<string[], string[]>
            {
                {
                    new string[] { "this", "that", "did", "deed", "them!", "a" },
                    new string[] { "t", "t", "h", "i", "s", "a", "d", "d", "e", "e", "m", "!" }
                }
            };
        }
    }
}
