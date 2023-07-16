namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/branch-sums"/>
    /// Time: O(n)
    /// Space: O(n)
    internal class EasyQuestion_21_BranchSums : CodingQuestion<EasyQuestion_21_BranchSums.BinaryTree, List<int>>
    {
        protected override List<int> ExecuteSolution(BinaryTree input)
        {
            var result = new List<int>();
            SearchDepthFirst(input, 0, result);
            return result;
        }

        private void SearchDepthFirst(BinaryTree input, int accumulatedSum, List<int> result)
        {
            if (input.left == null && input.right == null)
            {
                result.Add(accumulatedSum + input.value);
                return;
            }

            if (input.left != null)
            {
                SearchDepthFirst(input.left, accumulatedSum + input.value, result);
            }

            if (input.right != null)
            {
                SearchDepthFirst(input.right, accumulatedSum + input.value, result);
            }
        }

        protected override bool CompareActualAndExpectedOuputs(List<int> expected, List<int> actual)
        {
            if (expected.Count != actual.Count) return false;
            for (var i = 0; i < expected.Count; i++)
            {
                if (actual[i] != expected[i]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<BinaryTree, List<int>> GetTests()
        {
            var binaryTree = new BinaryTree(1);
            binaryTree.left = new BinaryTree(2);
            binaryTree.right = new BinaryTree(3);

            binaryTree.left.left = new BinaryTree(4);
            binaryTree.left.right = new BinaryTree(5);

            binaryTree.left.left.left = new BinaryTree(8);
            binaryTree.left.left.right = new BinaryTree(9);

            binaryTree.left.right.left = new BinaryTree(10);

            binaryTree.right.left = new BinaryTree(6);
            binaryTree.right.right = new BinaryTree(7);

            return new Dictionary<BinaryTree, List<int>>
            {
                { binaryTree, new List<int> { 15, 16, 18, 10, 11 } },
            };
        }

        // This is the class of the input root. Do not edit it.
        internal class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;

            public BinaryTree(int value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
            }
        }
    }
}
