using CodingQuestions.DataStructures;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/invert-binary-tree"/>
    /// Time: O(n) where n is the number of nodes
    /// Space: O(d) where d is the depth of the tree
    internal class MediumQuestion_13_InvertBinaryTree : CodingQuestion<BinaryTree, BinaryTree>
    {
        protected override BinaryTree ExecuteSolution(BinaryTree root)
        {
            return InvertNode(root);
        }

        private BinaryTree InvertNode(BinaryTree node)
        {
            var formerLeftNode = node.Left;
            node.Left = node.Right;
            node.Right = formerLeftNode;

            if (node.Left != null) InvertNode(node.Left);
            if (node.Right != null) InvertNode(node.Right);

            return node;
        }

        protected override bool CompareActualAndExpectedOuputs(BinaryTree expected, BinaryTree actual)
        {
            return expected.Equals(actual);
        }

        protected override IReadOnlyDictionary<BinaryTree, BinaryTree> GetTests()
        {
            var inputRoot = new BinaryTree(1);
            inputRoot.Left = new BinaryTree(2);
            inputRoot.Right = new BinaryTree(3);

            inputRoot.Left.Left = new BinaryTree(4);
            inputRoot.Left.Right = new BinaryTree(5);

            inputRoot.Right.Left = new BinaryTree(6);
            inputRoot.Right.Right = new BinaryTree(7);

            inputRoot.Left.Left.Left = new BinaryTree(8);
            inputRoot.Left.Left.Right = new BinaryTree(9);

            var outputRoot = new BinaryTree(1);
            outputRoot.Right = new BinaryTree(2);
            outputRoot.Left = new BinaryTree(3);

            outputRoot.Right.Right = new BinaryTree(4);
            outputRoot.Right.Left = new BinaryTree(5);

            outputRoot.Left.Right = new BinaryTree(6);
            outputRoot.Left.Left = new BinaryTree(7);

            outputRoot.Right.Right.Right = new BinaryTree(8);
            outputRoot.Right.Right.Left = new BinaryTree(9);

            return new Dictionary<BinaryTree, BinaryTree>
            {
                { inputRoot, outputRoot }
            };
        }
    }
}
