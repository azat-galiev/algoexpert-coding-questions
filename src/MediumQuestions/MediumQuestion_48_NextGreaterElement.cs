namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/next-greater-element"/>
    /// Time: O(n) where n is the number of elements in the array
    /// Space: O(n)
    internal class MediumQuestion_48_NextGreaterElement : CodingQuestion<int[], int[]>
    {
        protected override int[] ExecuteSolution(int[] array)
        {
            var result = new int[array.Length];
            Array.Fill(result, -1);

            // We're going to iterate backwards two times, and store the next greater element on the stack.
            var stack = new Stack<int>();
            for (var i = array.Length * 2 - 1; i >= 0; i--)
            {
                var normalizedIndex = i % array.Length;
                while (stack.Count > 0)
                {
                    // So, if the value on the top of the stack is greater than the current element,
                    // we found an answer for it.
                    if (stack.Peek() > array[normalizedIndex])
                    {
                        result[normalizedIndex] = stack.Peek();
                        break;
                    }
                    // Otherwise, if current element is greater than the top of the stack,
                    // then it makes sense to replace it on the stack.
                    else
                    {
                        stack.Pop();
                    }
                }

                stack.Push(array[normalizedIndex]);
            }

            return result;
        }

        protected override bool CompareActualAndExpectedOuputs(int[] expected, int[] actual)
        {
            if (expected.Length != actual.Length) return false;
            for (var i = 0; i < expected.Length; i++)
            {
                if (expected[i] != actual[i]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<int[], int[]> GetTests()
        {
            return new Dictionary<int[], int[]>
            {
                {
                    new int[] { 2, 5, -3, -4, 6,  7, 2 },
                    new int[] { 5, 6,  6,  6, 7, -1, 5 }
                }
            };
        }
    }
}
