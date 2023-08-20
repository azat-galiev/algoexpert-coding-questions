using CodingQuestions.DataStructures;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/bst-traversal"/>
    /// Time: O(n) where n is the number of vertices.
    /// Space: O(n)
    internal class MediumQuestion_54_BSTTraversal : CodingQuestion<BST, Tuple<List<int>, List<int>, List<int>>>
    {
        protected override Tuple<List<int>, List<int>, List<int>> ExecuteSolution(BST input)
        {
            return new Tuple<List<int>, List<int>, List<int>>(
                InOrderTraverse(input, new List<int>()),
                PreOrderTraverse(input, new List<int>()),
                PostOrderTraverse(input, new List<int>()));
        }

        // Time: O(n) where n is the number of vertices.
        // Space: O(n)
        private static List<int> InOrderTraverse(BST tree, List<int> array)
        {
            if (tree != null)
            {
                InOrderTraverse(tree.Left, array);
                array.Add(tree.Value);
                InOrderTraverse(tree.Right, array);
            }

            return array;
        }

        // Time: O(n) where n is the number of vertices.
        // Space: O(n)
        private static List<int> PreOrderTraverse(BST tree, List<int> array)
        {
            if (tree != null)
            {
                array.Add(tree.Value);
                PreOrderTraverse(tree.Left, array);
                PreOrderTraverse(tree.Right, array);
            }

            return array;
        }

        // Time: O(n) where n is the number of vertices.
        // Space: O(n)
        private static List<int> PostOrderTraverse(BST tree, List<int> array)
        {
            if (tree != null)
            {
                PostOrderTraverse(tree.Left, array);
                PostOrderTraverse(tree.Right, array);
                array.Add(tree.Value);
            }

            return array;
        }

        protected override bool CompareActualAndExpectedOuputs(Tuple<List<int>, List<int>, List<int>> expected, Tuple<List<int>, List<int>, List<int>> actual)
        {
            return CompareArrays(expected.Item1, actual.Item1) &&
                CompareArrays(expected.Item2, actual.Item2) &&
                CompareArrays(expected.Item3, actual.Item3);
        }

        private static bool CompareArrays(List<int> expected, List<int> actual)
        {
            if (expected.Count != actual.Count) return false;
            for (var i = 0; i < expected.Count; i++)
            {
                if (expected[i] != actual[i]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<BST, Tuple<List<int>, List<int>, List<int>>> GetTests()
        {
            var root = new BST(10);
            root.Left = new BST(5);
            root.Left.Left = new BST(2);
            root.Left.Left.Left = new BST(1);
            root.Left.Right = new BST(5);
            root.Right = new BST(15);
            root.Right.Right = new BST(22);

            return new Dictionary<BST, Tuple<List<int>, List<int>, List<int>>>
            {
                {
                    root,
                    new Tuple<List<int>, List<int>, List<int>>(
                        new List<int> { 1, 2, 5, 5, 10, 15, 22 },
                        new List<int> { 10, 5, 2, 1, 5, 15, 22 },
                        new List<int> { 1, 2, 5, 5, 22, 15, 10 })
                }
            };
        }
    }
}
