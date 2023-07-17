namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/node-depths"/>
    /// Time: O(n)
    /// Space: O(log(n)) in the best case (if tree is balanced), O(n) in the worst case
    internal class EasyQuestion_22_NodeDepths : CodingQuestion<EasyQuestion_22_NodeDepths.BinaryTree, int>
    {
        protected override int ExecuteSolution(BinaryTree root)
        {
            var result = 0;
            SearchDepthFirst(root, 0, ref result);
            return result;
        }

        private void SearchDepthFirst(BinaryTree node, int currentDepth, ref int result)
        {
            result += currentDepth;

            if (node.left != null)
            {
                SearchDepthFirst(node.left, currentDepth + 1, ref result);
            }

            if (node.right != null)
            {
                SearchDepthFirst(node.right, currentDepth + 1, ref result);
            }
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<BinaryTree, int> GetTests()
        {
            var root = new BinaryTree(1);
            root.left = new BinaryTree(2);
            root.right = new BinaryTree(3);

            root.left.left = new BinaryTree(4);
            root.left.right = new BinaryTree(5);

            root.left.left.left = new BinaryTree(8);
            root.left.left.right = new BinaryTree(9);

            root.right.left = new BinaryTree(6);
            root.right.right = new BinaryTree(7);

            return new Dictionary<BinaryTree, int>
            {
                { root, 16 },
            };
        }

        internal class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;

            public BinaryTree(int value)
            {
                this.value = value;
                left = null;
                right = null;
            }
        }
    }
}
