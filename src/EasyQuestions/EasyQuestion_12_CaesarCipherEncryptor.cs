using System.Text;

namespace CodingQuestions.EasyQuestions
{
    internal class EasyQuestion_12_CaesarCipherEncryptor_Input
    {
        public required string String { get; set; }

        public required int Key { get; set; }
    }

    /// <see href="https://www.algoexpert.io/questions/caesar-cipher-encryptor"/>
    /// Time: O(n)
    /// Space: O(n)
    internal class EasyQuestion_12_CaesarCipherEncryptor : CodingQuestion<EasyQuestion_12_CaesarCipherEncryptor_Input, string>
    {
        protected override string ExecuteSolution(EasyQuestion_12_CaesarCipherEncryptor_Input input)
        {
            const char start = 'a';
            const char end = 'z';

            var result = new StringBuilder(input.String.Length);
            foreach (var @char in input.String)
            {
                var inputCharCode = (int)@char;
                var resultCharCode = inputCharCode + input.Key;
                if (resultCharCode > end)
                {
                    var overflow = resultCharCode - end - 1;
                    var normalizedOverflow = overflow % (end - start + 1);
                    resultCharCode = start + normalizedOverflow;
                }

                result.Append((char)resultCharCode);
            }

            return result.ToString();
        }
        protected override bool CompareActualAndExpectedOuputs(string expected, string actual)
        {
            return expected.Equals(actual);
        }

        protected override IReadOnlyDictionary<EasyQuestion_12_CaesarCipherEncryptor_Input, string> GetTests()
        {
            return new Dictionary<EasyQuestion_12_CaesarCipherEncryptor_Input, string>()
            {
                { new EasyQuestion_12_CaesarCipherEncryptor_Input() { String = "xyz", Key = 2 }, "zab" }
            };
        }
    }
}
