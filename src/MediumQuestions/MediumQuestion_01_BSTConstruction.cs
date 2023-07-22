using CodingQuestions.DataStructures;

namespace CodingQuestions.MediumQuestions
{
    internal class MediumQuestion_01_BSTConstruction : CodingQuestion<MediumQuestion_01_BSTConstruction.Input, BST>
    {
        protected override BST ExecuteSolution(Input input)
        {
            /// Actual implementation is in the <see cref="BST"/> class.
            return input.Action(input.BST);
        }

        protected override bool CompareActualAndExpectedOuputs(BST expected, BST actual)
        {
            return expected.Equals(actual);
        }

        protected override IReadOnlyDictionary<Input, BST> GetTests()
        {
            var initialBST = new BST(10);
            initialBST.Left = new BST(5);
            initialBST.Left.Left = new BST(2);
            initialBST.Left.Left.Left = new BST(1);
            initialBST.Left.Right = new BST(5);
            initialBST.Right = new BST(15);
            initialBST.Right.Left = new BST(13);
            initialBST.Right.Left.Right = new BST(14);
            initialBST.Right.Right = new BST(22);

            var expectedBST = new BST(12);
            expectedBST.Left = new BST(5);
            expectedBST.Left.Left = new BST(2);
            expectedBST.Left.Left.Left = new BST(1);
            expectedBST.Left.Right = new BST(5);
            expectedBST.Right = new BST(15);
            expectedBST.Right.Left = new BST(13);
            expectedBST.Right.Left.Right = new BST(14);
            expectedBST.Right.Right = new BST(22);

            return new Dictionary<Input, BST>
            {
                {
                    new Input
                    {
                        BST = initialBST,
                        Action = bst => bst.Insert(12).Remove(10)
                    },
                    expectedBST
                }
            };
        }

        internal class Input
        {
            public required BST BST { get; set; }

            public required Func<BST, BST> Action { get; set; }
        }
    }
}
