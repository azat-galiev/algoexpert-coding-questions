namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/middle-node"/>
    /// Time: O(n)
    /// Space: O(1)
    internal class EasyQuestion_30_MiddleNode : CodingQuestion<EasyQuestion_30_MiddleNode.LinkedList, EasyQuestion_30_MiddleNode.LinkedList>
    {
        protected override LinkedList ExecuteSolution(LinkedList linkedList)
        {
            var length = 0;
            var pointer = linkedList;
            do
            {
                length++;
                pointer = pointer.Next;
            }
            while (pointer != null);

            var middleIndex = length / 2;
            var counter = 0;
            pointer = linkedList;
            while (counter++ != middleIndex) pointer = pointer.Next;

            return pointer;
        }

        protected override bool CompareActualAndExpectedOuputs(LinkedList expected, LinkedList actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<LinkedList, LinkedList> GetTests()
        {
            var middleNode = new LinkedList(3)
            {
                Next = new LinkedList(5)
            };

            var linkedList = new LinkedList(2)
            {
                Next = new LinkedList(7)
                {
                    Next = middleNode
                }
            };

            return new Dictionary<LinkedList, LinkedList> { { linkedList, middleNode } };
        }

        internal class LinkedList
        {
            public int Value;
            public LinkedList? Next;

            public LinkedList(int value)
            {
                Value = value;
            }
        }
    }
}
