namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/minimum-passes-of-matrix"/>
    /// Time: O(w * h) where w and h are the width and the height of the matrix respectively.
    /// Space: O(w * h)
    /// <remarks>
    /// This is optimal solution. The solution that I initially came up with: <see cref="MediumQuestion_39_MinimumPassesOfMatrix_MySolution"/>
    /// </remarks>
    internal class MediumQuestion_39_MinimumPassesOfMatrix_BetterSolution : CodingQuestion<int[][], int>
    {
        protected override int ExecuteSolution(int[][] matrix)
        {
            // We'll be traversing through positive numbers to see if they can convert siblings.
            var currentPassQueue = new Queue<Tuple<int, int>>();
            var negativesCount = 0;
            for (var r = 0; r < matrix.Length; r++)
            {
                for (var c = 0; c < matrix[r].Length; c++)
                {
                    if (matrix[r][c] > 0)
                    {
                        var pos = new Tuple<int, int>(r, c);
                        currentPassQueue.Enqueue(pos);
                    }
                    else if (matrix[r][c] < 0)
                    {
                        negativesCount++;
                    }
                }
            }

            if (negativesCount == 0) return 0;

            var pass = 0;
            while (currentPassQueue.Count > 0)
            {
                // We have two queues: one for the current pass, and one for the next one.
                // A pass is done when current pass'es queue is empty.
                var nextPassQueue = new Queue<Tuple<int, int>>();
                while (currentPassQueue.TryDequeue(out var pos))
                {
                    var r = pos.Item1;
                    var c = pos.Item2;

                    // Try converting all the siblings to 4 sides.
                    Convert(matrix, nextPassQueue, ref negativesCount, r - 1, c);
                    Convert(matrix, nextPassQueue, ref negativesCount, r + 1, c);
                    Convert(matrix, nextPassQueue, ref negativesCount, r, c - 1);
                    Convert(matrix, nextPassQueue, ref negativesCount, r, c + 1);
                }

                currentPassQueue = nextPassQueue;

                // If we converted something during the pass, iterate pass'es number.
                if (nextPassQueue.Count > 0) pass++;
            }

            // If after all passes we still have some negatives, then it's not possible to convert them.
            return negativesCount == 0 ? pass : -1;
        }

        private void Convert(int[][] matrix, Queue<Tuple<int, int>> nextPassQueue, ref int negativesCount, int r, int c)
        {
            if (!IsConvertable(matrix, r, c)) return;

            matrix[r][c] *= -1;
            nextPassQueue.Enqueue(new Tuple<int, int>(r, c));
            negativesCount--;
        }

        private bool IsConvertable(int[][] matrix, int r, int c)
        {
            // Edge cases when this pair of row and column is outside of matrix'es range.
            if (r < 0 || c < 0) return false;
            if (r >= matrix.Length) return false;
            if (c >= matrix[r].Length) return false;

            // We can convert a number if it's negative, otherwise it doesn't make sense.
            return matrix[r][c] < 0;
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<int[][], int> GetTests()
        {
            return new Dictionary<int[][], int>
            {
                {
                    new int[][]
                    {
                        new int[] { 0, -1, -3, 2, 0 },
                        new int[] { 1, -2, -5, -1, -3 },
                        new int[] { 3, 0, 0, -4, -1 },
                    },
                    3
                }
            };
        }
    }
}
