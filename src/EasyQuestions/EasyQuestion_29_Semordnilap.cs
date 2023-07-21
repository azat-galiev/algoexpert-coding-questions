using System.Text;

namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/semordnilap"/>
    /// Time: O(n * m) where n is the number of words, m is the length of the longest word
    /// Space: O(n * m)
    internal class EasyQuestion_29_Semordnilap : CodingQuestion<string[], List<List<string>>>
    {
        protected override List<List<string>> ExecuteSolution(string[] words)
        {
            var result = new List<List<string>>();
            var hashTable = new Dictionary<string, bool>();
            for (var i = 0; i < words.Length; i++)
            {
                var reversedStringBuilder = new StringBuilder(words[i].Length);
                for (var j = words[i].Length - 1; j >= 0; j--)
                {
                    reversedStringBuilder.Append(words[i][j]);
                }

                var reversedString = reversedStringBuilder.ToString();
                if (hashTable.ContainsKey(reversedString) && hashTable[reversedString])
                {
                    result.Add(new List<string> { words[i], reversedString });
                    hashTable[reversedString] = false;
                }
                else
                {
                    hashTable[words[i]] = true;
                }
            }

            return result;
        }

        protected override bool CompareActualAndExpectedOuputs(List<List<string>> expected, List<List<string>> actual)
        {
            if (expected.Count != actual.Count) return false;

            expected = expected
                .Select(x => x.OrderBy(y => y).ToList())
                .OrderBy(x => x.First())
                .ToList();
            actual = actual
                .Select(x => x.OrderBy(y => y).ToList())
                .OrderBy(x => x.First())
                .ToList();
            for (var i = 0; i < expected.Count; i++)
            {
                if (expected[i][0] != actual[i][0] || expected[i][1] != actual[i][1]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<string[], List<List<string>>> GetTests()
        {
            return new Dictionary<string[], List<List<string>>>
            {
                {
                    new string[] { "diaper", "abc", "test", "cba", "repaid" },
                    new List<List<string>>
                    {
                        new List<string> { "diaper", "repaid" },
                        new List<string> { "abc", "cba" },
                    }
                }
            };
        }
    }
}
