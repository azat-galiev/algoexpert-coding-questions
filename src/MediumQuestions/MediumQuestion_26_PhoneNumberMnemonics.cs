namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/phone-number-mnemonics"/>
    /// Time: O((4^n) * n) where n is the number of digits in a given phone number
    /// Space: O(4^n)
    /// 4 to the power of n because every digit might be map to up to 4 mnemonics.
    /// Time is additionally multiplied by n because we have to copy strings all the time along the way.
    internal class MediumQuestion_26_PhoneNumberMnemonics : CodingQuestion<string, List<string>>
    {
        protected override List<string> ExecuteSolution(string phoneNumber)
        {
            // We use dynamic programming here by splitting the problem into smaller problems.
            // The simplest possible case is a mnemonic for an empty number, so we start with it.
            var mnemonics = new List<string> { "" };

            // With each next digit of the phone number, we're getting closer to the final problem.
            foreach (var digit in phoneNumber)
            {
                var newMnemonics = new List<string>();

                // Ok, we have a digit. We iterate through every mnemonic for that digit...
                foreach (var digitMnemonic in map[digit])
                {
                    // ...and append its every mnemonic to all subproblems we solved before.
                    foreach (var mnemonic in mnemonics)
                    {
                        newMnemonics.Add(mnemonic + digitMnemonic);
                    }
                }

                mnemonics = newMnemonics;
            }

            return mnemonics;
        }

        private static readonly IReadOnlyDictionary<char, IEnumerable<char>> map = new Dictionary<char, IEnumerable<char>>
        {
            { '0', new char[] { '0' } },
            { '1', new char[] { '1' } },
            { '2', new char[] { 'a', 'b', 'c' } },
            { '3', new char[] { 'd', 'e', 'f' } },
            { '4', new char[] { 'g', 'h', 'i' } },
            { '5', new char[] { 'j', 'k', 'l' } },
            { '6', new char[] { 'm', 'n', 'o' } },
            { '7', new char[] { 'p', 'q', 'r', 's' } },
            { '8', new char[] { 't', 'u', 'v' } },
            { '9', new char[] { 'w', 'x', 'y', 'z' } },
        };

        protected override bool CompareActualAndExpectedOuputs(List<string> expected, List<string> actual)
        {
            expected.Sort();
            actual.Sort();

            if (expected.Count != actual.Count) return false;
            for (var i = 0; i < actual.Count; i++)
            {
                if (actual[i] != expected[i]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<string, List<string>> GetTests()
        {
            return new Dictionary<string, List<string>>
            {
                {
                    "1905",
                    new List<string>
                    {
                        "1w0j", "1w0k", "1w0l",
                        "1x0j", "1x0k", "1x0l",
                        "1y0j", "1y0k", "1y0l",
                        "1z0j", "1z0k", "1z0l",
                    }
                }
            };
        }
    }
}
