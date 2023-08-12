using System.Text;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/reverse-words-in-string"/>
    /// Time: O(n) where n is the length of the input string.
    /// Space: O(n)
    internal class MediumQuestion_41_ReverseWordsInString : CodingQuestion<string, string>
    {
        protected override string ExecuteSolution(string input)
        {
            var stringBuilder = new StringBuilder(input.Length);
            var inputPointer = input.Length - 1;

            while (inputPointer >= 0)
            {
                // Step 1. Rewind to the start of the word
                while (inputPointer > 0 && input[inputPointer - 1] != ' ')
                    inputPointer--;

                // Edge-case: when we don't have any word at all, only spacing.
                var wordStartPointer = input[inputPointer] == ' '
                    ? inputPointer + 1
                    : inputPointer;

                // Step 2. Copy the word to the result
                while (inputPointer < input.Length && input[inputPointer] != ' ')
                    stringBuilder.Append(input[inputPointer++]);

                // Step 3. Rewind to the start of the word, and copy spacing
                inputPointer = wordStartPointer - 1;
                while (inputPointer >= 0 && input[inputPointer] == ' ')
                    stringBuilder.Append(input[inputPointer--]);
            }

            return stringBuilder.ToString();
        }

        protected override bool CompareActualAndExpectedOuputs(string expected, string actual)
        {
            return actual == expected;
        }

        protected override IReadOnlyDictionary<string, string> GetTests()
        {
            return new Dictionary<string, string>
            {
                { "AlgoExpert is the best!", "best! the is AlgoExpert" },
                { "test", "test" },
                { " ", " " },
                { "test     ", "     test" }
            };
        }
    }
}
