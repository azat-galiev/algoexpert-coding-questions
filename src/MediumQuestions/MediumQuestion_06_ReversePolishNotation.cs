namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/reversePolishNotation"/>
    /// Time: O(n)
    /// Space: O(n)
    internal class MediumQuestion_06_ReversePolishNotation : CodingQuestion<string[], int>
    {
        protected override int ExecuteSolution(string[] tokens)
        {
            var stack = new Stack<int>();

            for (var i = 0; i < tokens.Length; i++)
            {
                switch (tokens[i])
                {
                    case "+":
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    case "-":
                        var subtrahend = stack.Pop();
                        stack.Push(stack.Pop() - subtrahend);
                        break;
                    case "*":
                        stack.Push(stack.Pop() * stack.Pop());
                        break;
                    case "/":
                        var divisor = stack.Pop();
                        stack.Push(stack.Pop() / divisor);
                        break;
                    default:
                        stack.Push(int.Parse(tokens[i]));
                        break;
                }
            }

            return stack.Pop();
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<string[], int> GetTests()
        {
            return new Dictionary<string[], int>
            {
                {
                    new string[] { "50", "3", "17", "+", "2", "-", "/" },
                    2
                }
            };
        }
    }
}
