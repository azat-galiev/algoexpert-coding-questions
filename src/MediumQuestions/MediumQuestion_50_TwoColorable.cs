namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/two-colorable"/>
    /// Time: O(v + e) where v is the number of vertices, e is the number of edges.
    /// Space: O(v)
    internal class MediumQuestion_50_TwoColorable : CodingQuestion<int[][], bool>
    {
        protected override bool ExecuteSolution(int[][] vertices)
        {
            // We'll store color of every vertex in an array.
            // If value is null, then the color isn't yet defined.
            // True/False mean two different colors.
            var colors = new bool?[vertices.Length];

            // Pick either color for the first vertex.
            colors[0] = true;

            // Now let's loop over edges to validate their neighbors if they have colors,
            // or assign them an opposite color otherwise.
            for (var i = 0; i < vertices.Length; i++)
            {
                var currentVertexColor = colors[i];

                // Loop over neighbors.
                foreach (var edge in vertices[i])
                {
                    // Neighbor doesn't have a color - assign the opposite.
                    if (colors[edge] == null)
                        colors[edge] = !currentVertexColor;
                    // Neightbor does have a color, and it's invalid.
                    else if (colors[edge] == currentVertexColor)
                        return false;
                }
            }

            // We looped over all of the vertices, and none of them are conflicting.
            return true;
        }

        protected override bool CompareActualAndExpectedOuputs(bool expected, bool actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<int[][], bool> GetTests()
        {
            return new Dictionary<int[][], bool>
            {
                {
                    new int[][]
                    {
                        new int[] { 1, 2 },
                        new int[] { 0, 2 },
                        new int[] { 0, 1 },
                    },
                    false
                },
                {
                    new int[][]
                    {
                        new int[] { 1, 3 },
                        new int[] { 0, 2 },
                        new int[] { 1, 3 },
                        new int[] { 0, 2 },
                    },
                    true
                }
            };
        }
    }
}
