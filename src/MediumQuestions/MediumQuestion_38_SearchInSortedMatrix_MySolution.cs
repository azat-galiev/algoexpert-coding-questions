namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/search-in-sorted-matrix"/>
    /// Time: O(log(w) * h) where w is the width, h is the height for a matrix
    /// Space: O(1)
    /// <remarks>
    /// There's a better solution that runs in O(w + h) time with a single pointer 
    /// starting from the top-right corner, but I couldn't come up with this 
    /// solution until I checked the answer. <see cref="MediumQuestion_38_SearchInSortedMatrix_BetterSolution"/>
    /// </remarks>
    internal class MediumQuestion_38_SearchInSortedMatrix_MySolution : CodingQuestion<Tuple<int[,], int>, Tuple<int, int>>
    {
        protected override Tuple<int, int> ExecuteSolution(Tuple<int[,], int> input)
        {
            var matrix = input.Item1;
            var target = input.Item2;

            // We iterate over rows.
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                // We know that rows are sorted, so if the target is smaller than the first element,
                // or greater than the last element, it's definitely not in the row.
                if (target < matrix[row, 0] || target > matrix[row, matrix.GetLength(1) - 1])
                    continue;

                // If the row can potentionally contain the target value, we run binary serach over it.
                var column = RunBinarySearch(matrix, row, target);
                if (column != -1)
                {
                    return new Tuple<int, int>(row, column);
                }
            }

            return new Tuple<int, int>(-1, -1);
        }

        private static int RunBinarySearch(int[,] matrix, int row, int target)
        {
            var left = 0;
            var right = matrix.GetLength(1) - 1;
            while (left <= right)
            {
                var middle = (left + right) / 2;
                if (target > matrix[row, middle])
                    left = middle + 1;
                else if (target < matrix[row, middle])
                    right = middle - 1;
                else
                    return middle;
            }

            return -1;
        }

        protected override bool CompareActualAndExpectedOuputs(Tuple<int, int> expected, Tuple<int, int> actual)
        {
            return expected.Item1 == actual.Item1 && expected.Item2 == actual.Item2;
        }

        protected override IReadOnlyDictionary<Tuple<int[,], int>, Tuple<int, int>> GetTests()
        {
            return new Dictionary<Tuple<int[,], int>, Tuple<int, int>>
            {
                {
                    new Tuple<int[,], int>(
                        new int[,]
                        {
                            { 1, 4, 7, 12, 15, 1000 },
                            { 2, 5, 19, 31, 32, 1001 },
                            { 3, 8, 24, 33, 35, 1002 },
                            { 40, 41, 42, 44, 45, 1003 },
                            { 99, 100, 103, 106, 128, 1004 },
                        },
                        44
                    ),
                    new Tuple<int, int>(3, 3)
                }
            };
        }
    }
}
