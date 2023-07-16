namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/remove-duplicates-from-linked-list"/>
    /// Time: O(n)
    /// Space: O(1)
    internal class EasyQuestion_20_RemoveDuplicatesFromLL : CodingQuestion<LinkedList<int>, LinkedList<int>>
    {
        protected override LinkedList<int> ExecuteSolution(LinkedList<int> input)
        {
            var previousElement = input.First;
            var currentElement = previousElement.Next;
            while (currentElement != null)
            {
                if (currentElement.Value == previousElement.Value)
                {
                    input.Remove(currentElement);
                    currentElement = previousElement.Next;
                }
                else
                {
                    previousElement = currentElement;
                    currentElement = currentElement.Next;
                }
            }

            return input;
        }

        protected override bool CompareActualAndExpectedOuputs(LinkedList<int> expected, LinkedList<int> actual)
        {
            if (expected.Count != actual.Count) return false;

            var currentExpected = expected.First;
            var currentActual = actual.First;
            while (currentExpected != null && currentActual != null)
            {
                if (currentExpected.Value != currentActual.Value) return false;
                
                currentExpected = currentExpected.Next;
                currentActual = currentActual.Next;
            }

            return true;
        }

        protected override IReadOnlyDictionary<LinkedList<int>, LinkedList<int>> GetTests()
        {
            return new Dictionary<LinkedList<int>, LinkedList<int>>
            {
                { new LinkedList<int>(new int[] { 1, 1, 3, 4, 4, 4, 5, 6, 6 }), new LinkedList<int>(new int[] { 1, 3, 4, 5, 6 }) }
            };
        }
    }
}
