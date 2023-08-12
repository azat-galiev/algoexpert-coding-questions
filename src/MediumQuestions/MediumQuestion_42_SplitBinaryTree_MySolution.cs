using CodingQuestions.DataStructures;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/split-binary-tree"/>
    /// Time: O(v) where v is the number of vertices.
    /// Space: O(v)
    internal class MediumQuestion_42_SplitBinaryTree_MySolution : CodingQuestion<BinaryTree, int>
    {
        protected override int ExecuteSolution(BinaryTree tree)
        {
            var sums = new Dictionary<BinaryTree, int>();
            CalculateSums(tree, sums);
            return FindSplitSum(tree, sums);
        }

        // Calculate the sum for all the nodes and store them in the hashtable
        // for further reference.
        // Time: O(v) where v is the number of vertices.
        // Space: O(v)
        private int CalculateSums(BinaryTree tree, Dictionary<BinaryTree, int> sums)
        {
            if (tree == null) return 0;
            var sum = tree.Value +
                CalculateSums(tree.Left, sums) +
                CalculateSums(tree.Right, sums);
            sums.Add(tree, sum);
            return sum;
        }

        // Time: O(v)
        // Space: O(d) where d is the maximum depth
        private int FindSplitSum(BinaryTree tree, Dictionary<BinaryTree, int> sums, int parent = 0)
        {
            // Edge-cases: if we don't have a tree, or it's a leaf node, there's nothing to split.
            if (tree == null) return 0;
            if (tree.Left == null && tree.Right == null) return 0;

            var leftSum = GetSum(tree.Left, sums);
            var rightSum = GetSum(tree.Right, sums);
            var sumWithLeft = parent + tree.Value + leftSum;
            var sumWithRight = parent + tree.Value + rightSum;

            if (leftSum != 0 && leftSum == sumWithRight) return leftSum;
            if (rightSum != 0 && rightSum == sumWithLeft) return rightSum;

            var leftResult = FindSplitSum(tree.Left, sums, sumWithRight);
            if (leftResult != 0) return leftResult;

            var rightResult = FindSplitSum(tree.Right, sums, sumWithLeft);
            if (rightResult != 0) return rightResult;

            return 0;
        }

        // Time: O(1)
        // Space: O(1)
        private int GetSum(BinaryTree tree, Dictionary<BinaryTree, int> sums)
        {
            if (tree == null) return 0;
            return sums[tree];
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
