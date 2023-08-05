namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/balanced-brackets"/>
    /// Time: O(n) where n is the length of the string
    /// Space: O(n)
    internal class MediumQuestion_28_BalancedBrackets : CodingQuestion<string, bool>
    {
        protected override bool ExecuteSolution(string str)
        {
            // So, we'll keep track of all brackets we opened using a stack.
            var openedBrackets = new Stack<char>();
            for (var i = 0; i < str.Length; i++)
            {
                // If we see an opening bracket, just add it onto the stack.
                if (openingBrackets.ContainsKey(str[i]))
                {
                    openedBrackets.Push(str[i]);
                }
                // If we see a closing bracket...
                else if (closingBrackets.ContainsKey(str[i]))
                {
                    // ...but we haven't opened any brackets, then the string isn't balanced.
                    if (openedBrackets.Count == 0) return false;

                    var openedBracket = openedBrackets.Pop();
                    var expectedOpenedBracket = closingBrackets[str[i]];

                    // If one bracket is being closed, but last time we opened a different one,
                    // string is also not balanced.
                    if (openedBracket != expectedOpenedBracket) return false;
                }
            }

            // String is balanced only if all opened brackets were eventually closed.
            return openedBrackets.Count == 0;
        }

        private static readonly Dictionary<char, char> openingBrackets = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
        };

        private static readonly Dictionary<char, char> closingBrackets = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' },
        };

        protected override bool CompareActualAndExpectedOuputs(bool expected, bool actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<string, bool> GetTests()
        {
            return new Dictionary<string, bool>
            {
                { "([]hello)(){world}(())()()", true },
                { "(", false },
                { "]", false },
                { "(}", false },
            };
        }
    }
}
