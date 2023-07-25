using CodingQuestions.DataStructures;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/reconstruct-bst"/>
    /// Time: O(n)
    /// Space: O(n)
    internal class MediumQuestion_07_ReconstructBST : CodingQuestion<List<int>, BST>
    {
        protected override BST ExecuteSolution(List<int> values)
        {
            return ProcessRange(values, 0, values.Count);
        }

        private BST ProcessRange(List<int> values, int indexFrom, int indexTo)
        {
            // We try to find the index of the node to the right by skipping
            // values smaller than the current one.
            int? rightIndex = null;
            for (var i = indexFrom + 1; i < indexTo; i++)
            {
                if (values[i] >= values[indexFrom])
                {
                    rightIndex = i;
                    break;
                }
            }

            // If we have the next node, and it's not the right node,
            // we treat it as the left node.
            int? leftIndex = null;
            if ((rightIndex == null && indexFrom + 1 < indexTo) || (rightIndex != null && rightIndex.Value - indexFrom > 1))
            {
                leftIndex = indexFrom + 1;
            }

            // If we found left node's index, call the function recursively
            // with all the numbers until the start of the right node, or the end.
            BST leftNode = null;
            if (leftIndex != null)
            {
                var leftLength = rightIndex == null ? indexTo : rightIndex.Value;
                leftNode = ProcessRange(values, leftIndex.Value, leftLength);
            }

            // If we found right node's index, we treat all the numbers
            // until the end as belonging to right subtree.
            BST rightNode = null;
            if (rightIndex != null)
            {
                rightNode = ProcessRange(values, rightIndex.Value, indexTo);
            }

            var node = new BST(values[indexFrom]);
            node.Left = leftNode;
            node.Right = rightNode;

            return node;
        }

        protected override bool CompareActualAndExpectedOuputs(BST expected, BST actual)
        {
            return expected.Equals(actual);
        }

        protected override IReadOnlyDictionary<List<int>, BST> GetTests()
        {
            var root = new BST(10);
            root.Left = new BST(4);
            root.Right = new BST(17);

            root.Left.Left = new BST(2);
            root.Left.Right = new BST(5);

            root.Left.Left.Left = new BST(1);

            root.Right.Right = new BST(19);
            root.Right.Right.Left = new BST(18);

            return new Dictionary<List<int>, BST>
            {
                {
                    new List<int> { 10, 4, 2, 1, 5, 17, 19, 18 },
                    root
                }
            };
        }
    }
}
