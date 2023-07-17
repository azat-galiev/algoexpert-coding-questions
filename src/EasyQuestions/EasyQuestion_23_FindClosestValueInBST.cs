namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/find-closest-value-in-bst"/>
    /// Time: O(log(n)) on average, O(n) in the worst case
    /// Space: O(1)
    internal class EasyQuestion_23_FindClosestValueInBST : CodingQuestion<EasyQuestion_23_FindClosestValueInBST.Input, int>
    {
        protected override int ExecuteSolution(Input input)
        {
            var currentNode = input.Tree;
            var closest = input.Tree.value;
            while (currentNode != null)
            {
                // if current closest value is further than the current node's value from the target, we update our closest
                if (Math.Abs(input.Target - closest) > Math.Abs(input.Target - currentNode.value))
                {
                    closest = currentNode.value;
                }

                if (input.Target < currentNode.value)
                {
                    currentNode = currentNode.left;
                }
                else if (input.Target > currentNode.value)
                {
                    currentNode = currentNode.right;
                }
                else
                {
                    break;
                }
            }

            return closest;
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<Input, int> GetTests()
        {
            var root = new BST(10);
            root.left = new BST(5);
            root.right = new BST(15);

            root.left.left = new BST(2);
            root.left.right = new BST(5);

            root.left.left.left = new BST(1);

            root.right.left = new BST(13);
            root.right.right = new BST(22);

            root.right.left.right = new BST(14);

            return new Dictionary<Input, int>
            {
                { new Input { Tree = root, Target = 12 }, 13 }
            };
        }

        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
            }
        }

        internal class Input
        {
            public BST Tree { get; set; }
            public int Target { get; set; }
        }
    }
}
