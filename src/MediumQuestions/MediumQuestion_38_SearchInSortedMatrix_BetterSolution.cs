namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/search-in-sorted-matrix"/>
    /// Time: O(w + h) where w is the width of a matrix, h is the height of the matrix.
    /// Space: O(1)
    internal class MediumQuestion_38_SearchInSortedMatrix_BetterSolution : CodingQuestion<Tuple<int[,], int>, Tuple<int, int>>
    {
        protected override Tuple<int, int> ExecuteSolution(Tuple<int[,], int> input)
        {
            var matrix = input.Item1;
            var target = input.Item2;

            // We start iterating from the top-right corner.
            // This makes sure that if the target is smaller than the current element, we can move left,
            // and if the target is greater than the current element, we can move down.
            var row = 0;
            var column = matrix.GetLength(1) - 1;
            while (row < matrix.GetLength(0) && column >= 0)
            {
                if (target < matrix[row, column])
                {
                    column--;
                }
                else if (target > matrix[row, column])
                {
                    row++;
                }
                else
                {
                    return new Tuple<int, int>(row, column);
                }
            }

            return new Tuple<int, int>(-1, -1);
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
