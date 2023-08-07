namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/river-sizes"/>
    /// Time: O(w * h) where w is the width of the matrix, h is the height of the matrix.
    /// Space: O(r) where r is the length of all rivers (the number of 1s in the matrix)
    internal class MediumQuestion_33_RiverSizes : CodingQuestion<int[,], List<int>>
    {
        protected override List<int> ExecuteSolution(int[,] matrix)
        {
            var seen = new HashSet<Tuple<int, int>>();
            var result = new List<int>();

            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 1 && !seen.Contains(new Tuple<int, int>(row, col)))
                    {
                        result.Add(GetRiverLength(matrix, seen, row, col));
                    }
                }
            }

            return result;
        }

        // Returns the length of the river at the given point. If it's not a river, returns 0.
        private int GetRiverLength(int[,] matrix, HashSet<Tuple<int, int>> seen, int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0)) return 0;
            if (col < 0 || col >= matrix.GetLength(1)) return 0;
            if (matrix[row, col] == 0) return 0;
            if (seen.Contains(new Tuple<int, int>(row, col))) return 0;

            seen.Add(new Tuple<int, int>(row, col));

            return 1 +
                GetRiverLength(matrix, seen, row + 1, col) +
                GetRiverLength(matrix, seen, row - 1, col) +
                GetRiverLength(matrix, seen, row, col + 1) +
                GetRiverLength(matrix, seen, row, col - 1);
        }

        protected override bool CompareActualAndExpectedOuputs(List<int> expected, List<int> actual)
        {
            if (expected.Count != actual.Count) return false;

            expected.Sort();
            actual.Sort();

            for (var i = 0; i < expected.Count; i++)
            {
                if (expected[i] != actual[i]) return false;
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
                        { 1, 0, 0, 1, 0 },
                        { 1, 0, 1, 0, 0 },
                        { 0, 0, 1, 0, 1 },
                        { 1, 0, 1, 0, 1 },
                        { 1, 0, 1, 1, 0 },
                    },
                    new List<int> { 1, 2, 2, 2, 5 }
                },
            };
        }
    }
}
