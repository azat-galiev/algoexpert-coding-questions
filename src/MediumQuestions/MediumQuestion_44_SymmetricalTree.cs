using CodingQuestions.DataStructures;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/symmetrical-tree"/>
    /// Time: O(v) where v is the number of vertices.
    /// Space: O(d) where d is the maximum depth of the tree.
    internal class MediumQuestion_44_SymmetricalTree : CodingQuestion<BinaryTree, bool>
    {
        protected override bool ExecuteSolution(BinaryTree tree)
        {
            return AreSubtreesMirrored(tree.Left, tree.Right);
        }

        private bool AreSubtreesMirrored(BinaryTree tree1, BinaryTree tree2)
        {
            if (tree1 == null && tree2 == null) return true;
            if (tree1 == null || tree2 == null) return false;

            return tree1.Value == tree2.Value &&
                AreSubtreesMirrored(tree1.Left, tree2.Right) &&
                AreSubtreesMirrored(tree1.Right, tree2.Left);
        }

        protected override bool CompareActualAndExpectedOuputs(bool expected, bool actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<BinaryTree, bool> GetTests()
        {
            var tree = new BinaryTree(1)
            {
                Left = new BinaryTree(2)
                {
                    Left = new BinaryTree(3)
                    {
                        Left = new BinaryTree(5),
                        Right = new BinaryTree(6),
                    },
                    Right = new BinaryTree(4),
                },
                Right = new BinaryTree(2)
                {
                    Left = new BinaryTree(4),
                    Right = new BinaryTree(3)
                    {
                        Left = new BinaryTree(6),
                        Right = new BinaryTree(5),
                    },
                },
            };
            return new Dictionary<BinaryTree, bool>
            {
                { tree, true },
            };
        }
    }
}
