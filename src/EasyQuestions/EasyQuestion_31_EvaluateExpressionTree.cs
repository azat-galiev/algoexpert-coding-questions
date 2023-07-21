namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/evaluate-expression-tree"/>
    /// Time: O(n) where n is the total number of nodes
    /// Space: O(h) where h is the longest branch in the tree
    internal class EasyQuestion_31_EvaluateExpressionTree : CodingQuestion<EasyQuestion_31_EvaluateExpressionTree.BinaryTree, int>
    {
        protected override int ExecuteSolution(BinaryTree tree)
        {
            return EvaluateNode(tree);
        }

        private int EvaluateNode(BinaryTree tree)
        {
            if (tree.Left == null || tree.Right == null)
            {
                return tree.Value;
            }

            var left = EvaluateNode(tree.Left);
            var right = EvaluateNode(tree.Right);

            switch (tree.Value)
            {
                case -1:
                    return left + right;
                case -2:
                    return left - right;
                case -3:
                    return left / right;
                case -4:
                    return left * right;
                default:
                    throw new InvalidOperationException();
            }
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<BinaryTree, int> GetTests()
        {
            var root = new BinaryTree(-1);
            root.Left = new BinaryTree(-2);
            root.Right = new BinaryTree(-3);

            root.Left.Left = new BinaryTree(-4);
            root.Left.Right = new BinaryTree(2);

            root.Left.Left.Left = new BinaryTree(2);
            root.Left.Left.Right = new BinaryTree(3);

            root.Right.Left = new BinaryTree(8);
            root.Right.Right = new BinaryTree(3);

            return new Dictionary<BinaryTree, int>
            {
                { root, 6 },
            };
        }

        internal class BinaryTree
        {
            public int Value;
            public BinaryTree? Left;
            public BinaryTree? Right;

            public BinaryTree(int value)
            {
                Value = value;
            }
        }
    }
}
