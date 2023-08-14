using CodingQuestions.DataStructures;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/validate-bst"/>
    /// Time: O(v) where v is the number of vertices.
    /// Space: O(d) where d is the maximum depth.
    internal class MediumQuestion_47_ValidateBST : CodingQuestion<BST, bool>
    {
        protected override bool ExecuteSolution(BST tree)
        {
            return IsValidBST(tree);
        }

        private static bool IsValidBST(
            BST tree,
            int minValue = int.MinValue,
            int maxValue = int.MaxValue)
        {
            if (tree.Value < minValue || tree.Value >= maxValue)
                return false;

            if (tree.Left != null && !IsValidBST(tree.Left, minValue, tree.Value)) return false;
            if (tree.Right != null && !IsValidBST(tree.Right, tree.Value, maxValue)) return false;

            return true;
        }

        protected override bool CompareActualAndExpectedOuputs(bool expected, bool actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<BST, bool> GetTests()
        {
            return new Dictionary<BST, bool>
            {
                { new BST(10).Insert(5).Insert(15).Insert(5).Insert(2).Insert(1).Insert(22).Insert(13).Insert(14), true },
            };
        }
    }
}
