using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/best-digits"/>
    /// Time: O(n) where n is the number of digits
    /// Space: O(n)
    internal class MediumQuestion_20_BestDigits : CodingQuestion<Tuple<string, int>, string>
    {
        protected override string ExecuteSolution(Tuple<string, int> input)
        {
            var number = input.Item1;
            var digitsToRemove = input.Item2;
            var stack = new Stack<char>();

            for (var i = 0; i < number.Length; i++)
            {
                // While the current digit is bigger than the digits sitting on more significant places,
                // we remove them until we have more digits to remove.
                // So, if we have a number 119, 2 digits to remove, and we're currently at the last digit 9,
                // we really want to get rid of smaller 1s.
                while (digitsToRemove > 0 && stack.Count > 0 && stack.Peek() < number[i])
                {
                    stack.Pop();
                    digitsToRemove--;
                }

                stack.Push(number[i]);
            }

            // If we went through all the digits, but still have something to remove (e.g., if the number 
            // is 54321 and we need to remove 2 digits), then remove least significant digits (2 and 1).
            while (digitsToRemove > 0 && stack.Count > 0)
            {
                stack.Pop();
                digitsToRemove--;
            }

            var resultArray = stack.ToArray();
            Array.Reverse(resultArray);

            return string.Join("", resultArray);
        }

        protected override bool CompareActualAndExpectedOuputs(string expected, string actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<Tuple<string, int>, string> GetTests()
        {
            return new Dictionary<Tuple<string, int>, string>
            {
                {
                    new Tuple<string, int>("462839", 2),
                    "6839"
                }
            };
        }
    }
}
