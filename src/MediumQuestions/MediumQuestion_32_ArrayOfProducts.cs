namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/array-of-products"/>
    /// Time: O(n) where n is the number of elements in the input array
    /// Space: O(n)
    internal class MediumQuestion_32_ArrayOfProducts : CodingQuestion<int[], int[]>
    {
        protected override int[] ExecuteSolution(int[] array)
        {
            var productToLeft = new int[array.Length];
            var productToRight = new int[array.Length];
            var result = new int[array.Length];

            // It's always 1 at the edges, because there are no other elements to the left or right of them.
            productToLeft[0] = 1;
            productToRight[productToRight.Length - 1] = 1;

            // Calculating the value of product to the left of every index.
            for (var i = 1; i < array.Length; i++)
                productToLeft[i] = productToLeft[i - 1] * array[i - 1];

            // Calculating the value of product to the right of every index.
            for (var i = array.Length - 2; i >= 0; i--)
                productToRight[i] = productToRight[i + 1] * array[i + 1];

            // Now, we calculate the final result.
            for (var i = 0; i < array.Length; i++)
                result[i] = productToLeft[i] * productToRight[i];

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
                    new int[] { 5, 1, 4, 2 },
                    new int[] { 8, 40, 10, 20 }
                }
            };
        }
    }
}
