namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/sum-of-linked-lists"/>
    /// Time: O(n) where n is the length of the longest linked list
    /// Space: O(n)
    internal class MediumQuestion_17_SumOfLinkedLists : CodingQuestion<MediumQuestion_17_SumOfLinkedLists.Input, LinkedList<byte>>
    {
        protected override LinkedList<byte> ExecuteSolution(Input input)
        {
            var result = new LinkedList<byte>();

            // We keep 3 pointers: for two operands, and the resulting LL.
            LinkedListNode<byte>? resultPointer = null;
            var pointer1 = input.First.First;
            var pointer2 = input.Second.First;

            byte carry = 0;
            do
            {
                byte value1 = pointer1?.Value ?? 0;
                byte value2 = pointer2?.Value ?? 0;
                byte currentResult = (byte)(value1 + value2 + carry);
                carry = 0;

                if (currentResult > 9)
                {
                    carry = 1;
                    currentResult %= 10;
                }

                if (resultPointer == null)
                {
                    result.AddFirst(currentResult);
                    resultPointer = result.First;
                }
                else
                {
                    result.AddAfter(resultPointer, currentResult);
                    resultPointer = resultPointer.Next;
                }

                pointer1 = pointer1?.Next;
                pointer2 = pointer2?.Next;
            }
            while (pointer1 != null || pointer2 != null || carry != 0);

            return result;
        }

        protected override bool CompareActualAndExpectedOuputs(LinkedList<byte> expected, LinkedList<byte> actual)
        {
            var pointer1 = expected.First;
            var pointer2 = actual.First;
            while (pointer1 != null || pointer2 != null)
            {
                if (pointer1 == null || pointer2 == null) return false;
                if (pointer1.Value != pointer2.Value) return false;

                pointer1 = pointer1.Next;
                pointer2 = pointer2.Next;
            }

            return true;
        }

        protected override IReadOnlyDictionary<Input, LinkedList<byte>> GetTests()
        {
            return new Dictionary<Input, LinkedList<byte>>
            {
                {
                    new Input
                    {
                        First = new LinkedList<byte>(new byte[] { 2, 4, 7, 1 }),
                        Second = new LinkedList<byte>(new byte[] { 9, 4, 5 }),
                    },
                    new LinkedList<byte>(new byte[] { 1, 9, 2, 2 })
                }
            };
        }

        internal class Input
        {
            public required LinkedList<byte> First { get; set; }
            public required LinkedList<byte> Second { get; set; }
        }
    }
}
