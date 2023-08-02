using CodingQuestions.DataStructures;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/height-balanced-binary-tree"/>
    /// Time: O(n) where n is the total number of nodes in the tree
    /// Space: O(d) where d is the depth of the longest branch in the tree
    internal class MediumQuestion_22_HeightBalancedBinaryTree : CodingQuestion<BinaryTree, bool>
    {
        protected override bool ExecuteSolution(BinaryTree tree)
        {
            return GetDepth(tree) != null;
        }

        // If the tree is not height balanced, it returns null,
        // otherwise, it returns the depth (height) of the tree.
        public int? GetDepth(BinaryTree? tree)
        {
            // Depth for the leaf node is 0.
            if (tree == null) return 0;

            // If either of subtrees are not height balanced, the whole tree isn't balanced.
            var leftDepth = GetDepth(tree.Left);
            if (leftDepth == null) return null;

            var rightDepth = GetDepth(tree.Right);
            if (rightDepth == null) return null;

            var difference = Math.Abs(leftDepth.Value - rightDepth.Value);
            if (difference > 1) return null;

            return Math.Max(leftDepth.Value, rightDepth.Value) + 1;
        }

        protected override bool CompareActualAndExpectedOuputs(bool expected, bool actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<BinaryTree, bool> GetTests()
        {
            var root = new BinaryTree(1);
            root.Left = new BinaryTree(2);
            root.Right = new BinaryTree(3);

            root.Left.Left = new BinaryTree(4);
            root.Left.Right = new BinaryTree(5);

            root.Right.Right = new BinaryTree(6);

            root.Left.Right.Left = new BinaryTree(7);
            root.Left.Right.Right = new BinaryTree(8);

            return new Dictionary<BinaryTree, bool>
            {
                { root, true }
            };
        }
    }
}
