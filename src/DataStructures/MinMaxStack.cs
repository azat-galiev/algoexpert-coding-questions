namespace CodingQuestions.DataStructures
{
    // Time (all operations): O(1)
    // Space (stack itself): O(n) where n is the largest number of elements in the stack at one time
    // Space (all operations): O(1)
    internal class MinMaxStack
    {
        private Stack<int> stack = new Stack<int>();
        private Stack<int> minStack = new Stack<int>();
        private Stack<int> maxStack = new Stack<int>();

        public int Peek()
        {
            return stack.Peek();
        }

        public int Pop()
        {
            var value = stack.Pop();
            if (minStack.Peek() == value) minStack.Pop();
            if (maxStack.Peek() == value) maxStack.Pop();

            return value;
        }

        public void Push(int number)
        {
            stack.Push(number);
            if (minStack.Count == 0 || minStack.Peek() >= number) minStack.Push(number);
            if (maxStack.Count == 0 || maxStack.Peek() <= number) maxStack.Push(number);
        }

        public int GetMin()
        {
            return minStack.Peek();
        }

        public int GetMax()
        {
            return maxStack.Peek();
        }
    }
}
