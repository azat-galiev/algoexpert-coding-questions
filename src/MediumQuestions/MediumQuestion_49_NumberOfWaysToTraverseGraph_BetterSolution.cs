using System;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/number-of-ways-to-traverse-graph"/>
    /// Time: O(w + h) where w is the width of the graph, h is the height of the graph
    /// Space: O(1)
    internal class MediumQuestion_49_NumberOfWaysToTraverseGraph_BetterSolution : CodingQuestion<Tuple<int, int>, int>
    {
        protected override int ExecuteSolution(Tuple<int, int> input)
        {
            var width = input.Item1;
            var height = input.Item2;

            // Here, instead of Dynamic Programming, we use Math since it's a combinatorics problem.

            return Factorial(width + height - 2) / Factorial(width - 1) / Factorial(height - 1);
        }

        private static int Factorial(int num)
        {
            int result = 1;
            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }
            return result;
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
