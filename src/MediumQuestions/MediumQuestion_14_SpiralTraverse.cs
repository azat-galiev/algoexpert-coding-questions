namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/spiral-traverse"/>
    /// Time: O(n*m) where n is the number of rows, and m is the number of columns
    /// Space: O(n*m)
    internal class MediumQuestion_14_SpiralTraverse : CodingQuestion<int[,], List<int>>
    {
        protected override List<int> ExecuteSolution(int[,] array)
        {
            var result = new List<int>(array.Length);

            var shift = 0;
            while (result.Count < array.Length)
            {
                var firstCol = shift;
                var firstRow = shift;
                var lastCol = array.GetLength(1) - 1 - shift;
                var lastRow = array.GetLength(0) - 1 - shift;
                var columns = array.GetLength(1) - shift;
                var rows = array.GetLength(0) - shift;

                // Iterate over the top row.
                for (var col = firstCol; col < columns; col++)
                    result.Add(array[firstRow, col]);

                // Iterate over the right column.
                for (var row = firstRow + 1; row < rows; row++)
                    result.Add(array[row, lastCol]);

                // Iterate over the bottom row.
                if (lastRow != firstRow)
                {
                    for (var col = lastCol - 1; col >= firstCol; col--)
                        result.Add(array[lastRow, col]);
                }

                // Iterate over the left column.
                if (firstCol != lastCol)
                {
                    for (var row = lastRow - 1; row > firstRow; row--)
                        result.Add(array[row, firstCol]);
                }

                shift++;
            }

            return result;
        }

        protected override bool CompareActualAndExpectedOuputs(List<int> expected, List<int> actual)
        {
            if (expected.Count != actual.Count) return false;
            for (int i = 0; i < expected.Count; i++)
            {
                if (actual[i] != expected[i]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<int[,], List<int>> GetTests()
        {
            return new Dictionary<int[,], List<int>>
            {
                {
                    new int[,]
                    {
                        { 1, 2, 3, 4 },
                        { 12, 13, 14, 5 },
                        { 11, 16, 15, 6 },
                        { 10, 9, 8, 7 },
                    },
                    new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }
                }
            };
        }
    }
}
