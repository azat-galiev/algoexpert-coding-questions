namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/minimum-passes-of-matrix"/>
    /// Time: O(w * h * p) where w and h are the width and the height of the matrix respectively,
    /// p is the required number of passes to convert the matrix.
    /// Space: O(w * h)
    /// <remarks>
    /// This is my initial solution. It's not the best solution, but it's the one I came up with.
    /// Better solution: <see cref="MediumQuestion_39_MinimumPassesOfMatrix_BetterSolution"/>
    /// </remarks>
    internal class MediumQuestion_39_MinimumPassesOfMatrix_MySolution : CodingQuestion<int[][], int>
    {
        protected override int ExecuteSolution(int[][] matrix)
        {
            // We still have some negatives after previous pass.
            var unconvertedLeft = true;
            // How many elements were converted during previous pass.
            var convertedOnPrevPass = 0;
            // Index of pass.
            var pass = 0;
            // A coordinate-to-pass map of converted elements.
            var converted = new Dictionary<Tuple<int, int>, int>();

            // The while loop iterates over passes. We continue iteration if there 
            // are some more unconverted elements, and it's the very first pass or
            // previous pass converted something. If previous pass hasn't converted anything,
            // then a new one won't convert it as well.
            while (unconvertedLeft && (pass == 0 || convertedOnPrevPass > 0))
            {
                unconvertedLeft = false;
                convertedOnPrevPass = 0;

                // Traverse rows.
                for (var r = 0; r < matrix.Length; r++)
                {
                    var row = matrix[r];
                    // Traverse columns.
                    for (var c = 0; c < row.Length; c++)
                    {
                        // If it's a non-negative element, we don't even need to convert it.
                        if (row[c] >= 0) continue;

                        // If we converted it on some previous pass, we also skip it.
                        if (converted.ContainsKey(new Tuple<int, int>(r, c))) continue;

                        if (CanConvert(matrix, converted, pass, r, c))
                        {
                            converted.Add(new Tuple<int, int>(r, c), pass);
                            convertedOnPrevPass++;
                        }
                        else
                        {
                            unconvertedLeft = true;
                        }
                    }
                }

                pass++;
            }

            if (unconvertedLeft) return -1;

            // If there are no negatives at all.
            if (pass == 1 && convertedOnPrevPass == 0) return 0;

            return pass;
        }

        private bool CanConvert(int[][] matrix, Dictionary<Tuple<int, int>, int> converted, int pass, int r, int c)
        {
            return
                IsPositive(matrix, converted, pass, r - 1, c) ||
                IsPositive(matrix, converted, pass, r + 1, c) ||
                IsPositive(matrix, converted, pass, r, c - 1) ||
                IsPositive(matrix, converted, pass, r, c + 1);
        }

        private bool IsPositive(int[][] matrix, Dictionary<Tuple<int, int>, int> converted, int pass, int r, int c)
        {
            // Element doesn't exist (outside of matrix range).
            if (r < 0 || c < 0) return false;
            if (r >= matrix.Length || c >= matrix[r].Length) return false;

            // Element is positive (zero cannot convert a negative).
            if (matrix[r][c] > 0) return true;

            var key = new Tuple<int, int>(r, c);

            // Element was converted, but only if on some previous pass.
            if (converted.ContainsKey(key) && converted[key] < pass) return true;

            return false;
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
