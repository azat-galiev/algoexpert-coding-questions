using CodingQuestions.DataStructures;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/split-binary-tree"/>
    /// Time: O(v) where v is the number of vertices.
    /// Space: O(d) where d is the maximum depth.
    internal class MediumQuestion_42_SplitBinaryTree_BetterSolution : CodingQuestion<BinaryTree, int>
    {
        protected override int ExecuteSolution(BinaryTree tree)
        {
            // That's pretty obvious: if the total sum is not even mathematically devidable, then it's not worth trying.
            var totalSum = CalculateSum(tree);
            if (totalSum % 2 != 0) return 0;

            var desiredSum = totalSum / 2;
            if (TrySubtree(tree, desiredSum).Item1)
            {
                return desiredSum;
            }

            return 0;
        }

        private int CalculateSum(BinaryTree tree)
        {
            if (tree == null) return 0;
            return tree.Value +
                CalculateSum(tree.Left) +
                CalculateSum(tree.Right);
        }

        private Tuple<bool, int> TrySubtree(BinaryTree tree, int desiredSum)
        {
            // Edge-cases: if we don't have a tree, there's nothing to split.
            if (tree == null) return new Tuple<bool, int>(false, 0);

            var leftResult = TrySubtree(tree.Left, desiredSum);
            var rightResult = TrySubtree(tree.Right, desiredSum);

            // If the current subtree has exactly the desired sum, it means that we can just disconnect it from the parent.
            var currentSum = tree.Value + leftResult.Item2 + rightResult.Item2;
            var canBeSplit = leftResult.Item1 || rightResult.Item1 || currentSum == desiredSum;

            return new Tuple<bool, int>(canBeSplit, currentSum);
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<BinaryTree, int> GetTests()
        {
            var tree = new BinaryTree(1);
            tree.Left = new BinaryTree(3);
            tree.Right = new BinaryTree(-2);
            tree.Left.Left = new BinaryTree(6);
            tree.Left.Right = new BinaryTree(-5);
            tree.Left.Left.Left = new BinaryTree(2);
            tree.Right.Left = new BinaryTree(5);
            tree.Right.Right = new BinaryTree(2);

            return new Dictionary<BinaryTree, int>
            {
                { tree, 6 },
            };
        }
    }
}
