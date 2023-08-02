using CodingQuestions.DataStructures;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/min-height-bst"/>
    /// Time: O(n) where n is the total number of elements in the array
    /// Space: O(n)
    internal class MediumQuestion_23_MinHeightBST : CodingQuestion<int[], BST>
    {
        protected override BST ExecuteSolution(int[] array)
        {
            return CreateBSTFromRange(array, 0, array.Length - 1);
        }

        private BST CreateBSTFromRange(int[] array, int startIndex, int endIndex)
        {
            if (endIndex < startIndex) return null;

            var count = endIndex - startIndex + 1;
            var middleIndex = startIndex + (count / 2);
            var root = new BST(array[middleIndex]);

            var leftStartIndex = startIndex;
            var leftEndIndex = middleIndex - 1;
            root.Left = CreateBSTFromRange(array, leftStartIndex, leftEndIndex);

            var rightStartIndex = middleIndex + 1;
            var rightEndIndex = endIndex;
            root.Right = CreateBSTFromRange(array, rightStartIndex, rightEndIndex);

            return root;
        }

        protected override bool CompareActualAndExpectedOuputs(BST expected, BST actual)
        {
            return expected.Equals(actual);
        }

        protected override IReadOnlyDictionary<int[], BST> GetTests()
        {
            var root = new BST(10);
            root.Left = new BST(5);
            root.Right = new BST(15);

            root.Left.Left = new BST(2);
            root.Left.Right = new BST(7);

            root.Left.Left.Left = new BST(1);

            root.Right.Left = new BST(14);
            root.Right.Right = new BST(22);

            root.Right.Left.Left = new BST(13);

            return new Dictionary<int[], BST>
            {
                { new int[] { 1, 2, 5, 7, 10, 13, 14, 15, 22 }, root },
            };
        }
    }
}
