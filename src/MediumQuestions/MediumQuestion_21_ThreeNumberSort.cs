namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/three-number-sort"/>
    /// Time: O(n) where n is the number of elements in array (because we'll iterate over each element 3 times at most).
    /// Space: O(1)
    internal class MediumQuestion_21_ThreeNumberSort : CodingQuestion<Tuple<int[], int[]>, int[]>
    {
        protected override int[] ExecuteSolution(Tuple<int[], int[]> input)
        {
            var array = input.Item1;
            var order = input.Item2;

            // "Next" is a pointer to the next element in the array we're going to update.
            var next = 0;
            for (var i = 0; i < 3; i++)
            {
                // If the pointer to the next element to update is good according to the order,
                // we skip it, because it doesn't actually need an update.
                while (next < array.Length && array[next] == order[i])
                    next++;

                // Now, we iterate over the rest of array.
                for (var j = next + 1; j < array.Length; j++)
                {
                    // If some of the next elements is what we want to see instead of what we have
                    // at the "next" place, swap the values (of course, if they don't match).
                    if (array[j] == order[i] && array[next] != array[j])
                    {
                        array[j] = array[next];
                        array[next] = order[i];

                        next++;
                    }
                }
            }

            return array;
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

        protected override IReadOnlyDictionary<Tuple<int[], int[]>, int[]> GetTests()
        {
            return new Dictionary<Tuple<int[], int[]>, int[]>
            {
                {
                    new Tuple<int[], int[]>(
                        new[] {1, 0, 0, -1, -1, 0, 1, 1},
                        new[] {0, 1, -1}),
                    new int[] {0, 0, 0, 1, 1, 1, -1, -1}
                }
            };
        }
    }
}
