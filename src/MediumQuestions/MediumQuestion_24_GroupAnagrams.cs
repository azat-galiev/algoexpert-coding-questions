namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/group-anagrams"/>
    /// Time: O(w * nlog(n)) where w is the number of words, and n is the length of the longest word
    /// Space: O(wn)
    internal class MediumQuestion_24_GroupAnagrams : CodingQuestion<List<string>, List<List<string>>>
    {
        protected override List<List<string>> ExecuteSolution(List<string> words)
        {
            var anagrams = new Dictionary<string, List<string>>();

            foreach (var word in words)
            {
                // We create a "normalized" version of the word that would be the same for all anagrams.
                // To achieve that, we just sort all the characters in the word.
                var charArray = word.ToCharArray();
                Array.Sort(charArray);
                var normalizedWord = new string(charArray);

                if (!anagrams.ContainsKey(normalizedWord))
                    anagrams.Add(normalizedWord, new List<string>());

                // Using this approach, we'll have all the anagrams groupped since they all use a common
                // invariant as a hashtable key.
                anagrams[normalizedWord].Add(word);
            }

            var result = new List<List<string>>();
            foreach (var key in anagrams.Keys)
            {
                result.Add(anagrams[key]);
            }

            return result;
        }

        protected override bool CompareActualAndExpectedOuputs(List<List<string>> expected, List<List<string>> actual)
        {
            if (expected.Count != actual.Count) return false;
            for (var i = 0; i < actual.Count; i++)
            {
                if (actual[i].Count != expected[i].Count) return false;
                for (var j = 0; j < actual[i].Count; j++)
                {
                    if (actual[i][j] != expected[i][j]) return false;
                }
            }

            return true;
        }

        protected override IReadOnlyDictionary<List<string>, List<List<string>>> GetTests()
        {
            return new Dictionary<List<string>, List<List<string>>>
            {
                {
                    new List<string> { "yo", "act", "flop", "tac", "foo", "cat", "oy", "olfp" },
                    new List<List<string>>
                    {
                        new List<string> { "yo", "oy" },
                        new List<string> { "act", "tac", "cat" },
                        new List<string> { "flop", "olfp" },
                        new List<string> { "foo" },
                    }
                }
            };
        }
    }
}
