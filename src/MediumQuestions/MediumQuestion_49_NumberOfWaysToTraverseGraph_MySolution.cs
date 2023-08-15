namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/number-of-ways-to-traverse-graph"/>
    /// Time: O(w * h) where w is the width of the graph, h is the height of the graph
    /// Space: O(min(w, h))
    internal class MediumQuestion_49_NumberOfWaysToTraverseGraph_MySolution : CodingQuestion<Tuple<int, int>, int>
    {
        protected override int ExecuteSolution(Tuple<int, int> input)
        {
            var width = input.Item1;
            var height = input.Item2;

            // We'll use dynamic programming approach here.

            var smaller = Math.Min(width, height);
            var bigger = Math.Max(width, height);

            var evenLine = new int[smaller];
            var oddLine = new int[smaller];

            // If we have a 1-dimentional graph, every point might be
            // reached by using only a single way (all rights or all downs).
            Array.Fill(evenLine, 1);

            for (var i = 1; i < bigger; i++)
            {
                var currentLine = i % 2 == 0 ? evenLine : oddLine;
                var previousLine = i % 2 == 0 ? oddLine : evenLine;

                currentLine[0] = 1;
                for (var j = 1; j < currentLine.Length; j++)
                {
                    // The number of ways to reach every point equals to
                    // the number of ways to reach the point above it
                    // plus the number of ways to reach the point to the left.
                    currentLine[j] = currentLine[j - 1] + previousLine[j];
                }
            }

            var lastLine = (bigger - 1) % 2 == 0 ? evenLine : oddLine;
            return lastLine[lastLine.Length - 1];
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<Tuple<int, int>, int> GetTests()
        {
            return new Dictionary<Tuple<int, int>, int>
            {
                { new Tuple<int, int>(4, 3), 10 },
                { new Tuple<int, int>(9, 5), 495 },
            };
        }
    }
}
