using System.Text;

namespace CodingQuestions.EasyQuestions
{
    /// <see cref="https://www.algoexpert.io/questions/run-length-encoding"/>
    /// Time: O(n)
    /// Space: O(n)
    internal class EasyQuestion_13_RunLengthEncoding : CodingQuestion<string, string>
    {
        protected override string ExecuteSolution(string input)
        {
            var result = new StringBuilder();

            int counter = 0;
            char previousCharacter = input[0];
            foreach (var @char in input)
            {
                if (@char == previousCharacter)
                {
                    counter++;

                    if (counter == 9)
                    {
                        result.Append($"{counter}{@char}");
                        counter = 0;
                    }
                }
                else
                {
                    if (counter > 0)
                    {
                        result.Append($"{counter}{previousCharacter}");
                    }

                    counter = 1;
                }

                previousCharacter = @char;
            }

            if (counter > 0)
            {
                result.Append($"{counter}{previousCharacter}");
            }

            return result.ToString();
        }

        protected override IReadOnlyDictionary<string, string> GetTests()
        {
            return new Dictionary<string, string>
            {
                { "AAAAAAAAAAAAABBCCCCDD", "9A4A2B4C2D" }
            };
        }
    }
}
