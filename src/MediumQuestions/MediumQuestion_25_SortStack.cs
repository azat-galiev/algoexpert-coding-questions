namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/sort-stack"/>
    /// Time: O(n^2) where n is the number of elements in the stack
    /// Space: O(n)
    internal class MediumQuestion_25_SortStack : CodingQuestion<List<int>, List<int>>
    {
        protected override List<int> ExecuteSolution(List<int> stack)
        {
            Sort(stack);
            return stack;
        }

        private void Sort(List<int> stack)
        {
            // Empty stack is sorted stack :D
            if (stack.Count == 0) return;

            // So, in order to sort a non-empty stack, we remove the top,
            // sort the remainder, and insert removed top back into the sorted stack,
            // which is simpler.
            var top = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);

            Sort(stack);
            Insert(stack, top);
        }

        private void Insert(List<int> stack, int valueToInsert)
        {
            // Here we have already sorted stack, or an empty one.
            // So, if we see an element that is smaller than the current one, 
            // then we can safely add our value after it.
            if (stack.Count == 0 || stack[stack.Count - 1] <= valueToInsert)
            {
                stack.Add(valueToInsert);
                return;
            }

            // The top of the sorted stack is bigger than the value to be added,
            // so we need to remove some more elements before inserting.
            // After that, we can insert removed top back to the stack.
            var top = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);

            Insert(stack, valueToInsert);
            Insert(stack, top);
        }

        protected override bool CompareActualAndExpectedOuputs(List<int> expected, List<int> actual)
        {
            if (expected.Count != actual.Count) return false;
            for (var i = 0 ; i < actual.Count; i++)
            {
                if (actual[i] != expected[i]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<List<int>, List<int>> GetTests()
        {
            return new Dictionary<List<int>, List<int>>
            {
                {
                    new List<int> { -5, 2, -2, 4, 3, 1 },
                    new List<int> { -5, -2, 1, 2, 3, 4 }
                }
            };
        }
    }
}
