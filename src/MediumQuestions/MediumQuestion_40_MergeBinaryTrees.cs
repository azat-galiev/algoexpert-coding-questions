using CodingQuestions.DataStructures;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/merge-binary-trees"/>
    /// Time: O(v) where v is the number of vertices in the smaller tree.
    /// Space: O(d) where d is the maximum depth in the smaller tree.
    internal class MediumQuestion_40_MergeBinaryTrees : CodingQuestion<Tuple<BinaryTree, BinaryTree>, BinaryTree>
    {
        protected override BinaryTree ExecuteSolution(Tuple<BinaryTree, BinaryTree> input)
        {
            return MergeTrees(input.Item1, input.Item2)!;
        }

        private BinaryTree? MergeTrees(BinaryTree? tree1, BinaryTree? tree2)
        {
            // We'll treat tree1 as "main" and update it instead of creating a new binary tree.

            if (tree1 == null) return tree2;

            tree1.Value += tree2?.Value ?? 0;

            tree1.Left = MergeTrees(tree1.Left, tree2?.Left);
            tree1.Right = MergeTrees(tree1.Right, tree2?.Right);

            return tree1;
        }

        protected override bool CompareActualAndExpectedOuputs(BinaryTree expected, BinaryTree actual)
        {
            return expected.Equals(actual);
        }

        protected override IReadOnlyDictionary<Tuple<BinaryTree, BinaryTree>, BinaryTree> GetTests()
        {
            var tree1 = new BinaryTree(1);
            tree1.Left = new BinaryTree(3);
            tree1.Right = new BinaryTree(2);
            tree1.Left.Left = new BinaryTree(7);
            tree1.Left.Right = new BinaryTree(4);

            var tree2 = new BinaryTree(1);
            tree2.Left = new BinaryTree(5);
            tree2.Right = new BinaryTree(9);
            tree2.Left.Left = new BinaryTree(2);
            tree2.Right.Left = new BinaryTree(7);
            tree2.Right.Right = new BinaryTree(6);

            var expectedTree = new BinaryTree(2);
            expectedTree.Left = new BinaryTree(8);
            expectedTree.Right = new BinaryTree(11);
            expectedTree.Left.Left = new BinaryTree(9);
            expectedTree.Left.Right = new BinaryTree(4);
            expectedTree.Right.Left = new BinaryTree(7);
            expectedTree.Right.Right = new BinaryTree(6);

            return new Dictionary<Tuple<BinaryTree, BinaryTree>, BinaryTree>
            {
                {
                    new Tuple<BinaryTree, BinaryTree>(tree1, tree2),
                    expectedTree
                }
            };
        }
    }
}
