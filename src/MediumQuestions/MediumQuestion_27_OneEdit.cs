namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/one-edit"/>
    /// Time: O(n) where n is the length of the shortest string.
    /// Space: O(1)
    internal class MediumQuestion_27_OneEdit : CodingQuestion<Tuple<string, string>, bool>
    {
        protected override bool ExecuteSolution(Tuple<string, string> input)
        {
            var stringOne = input.Item1;
            var stringTwo = input.Item2;

            // If strings have a difference in length more than 1 character,
            // it's pretty obvious that we can't make them equivelent by just
            // a single change.
            if (Math.Abs(stringOne.Length - stringTwo.Length) > 1)
                return false;

            var pointerOne = 0;
            var pointerTwo = 0;
            var madeChange = false;

            while (pointerOne < stringOne.Length && pointerTwo < stringTwo.Length)
            {
                // If characters are the same, just skipping, it's not interesting.
                if (stringOne[pointerOne] == stringTwo[pointerTwo])
                {
                    pointerOne++;
                    pointerTwo++;
                    continue;
                }

                // We already made a change, so it's impossible to make a second one.
                if (madeChange) return false;
                madeChange = true;

                // If the 1st string is longer, than the only thing we can do is skip
                // the current character there. That assuses either adding a character
                // in the shorter string, or removing a character in the longer string.
                if (stringOne.Length > stringTwo.Length)
                {
                    pointerOne++;
                }
                // The same case, but in the 2nd string.
                else if (stringOne.Length < stringTwo.Length)
                {
                    pointerTwo++;
                }
                // If both strings have the same length, then we need a replacement in
                // either of the string.
                else
                {
                    pointerOne++;
                    pointerTwo++;
                }
            }

            return true;
        }

        protected override bool CompareActualAndExpectedOuputs(bool expected, bool actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<Tuple<string, string>, bool> GetTests()
        {
            return new Dictionary<Tuple<string, string>, bool>
            {
                {
                    new Tuple<string, string>("hello", "hollo"),
                    true
                }
            };
        }
    }
}
