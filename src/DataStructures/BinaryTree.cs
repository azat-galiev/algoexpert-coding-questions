namespace CodingQuestions.DataStructures
{
    internal class BinaryTree : IEquatable<BinaryTree>
    {
        public int Value;
        public BinaryTree? Left;
        public BinaryTree? Right;

        public BinaryTree(int value)
        {
            Value = value;
        }

        public bool Equals(BinaryTree? other)
        {
            if (other == this) return true;
            if (other == null) return false;

            return other.Value == Value &&
                ((other.Left == null && Left == null) || (other.Left != null && Left != null && other.Left.Equals(Left))) &&
                ((other.Right == null && Right == null) || (other.Right != null && Right != null && other.Right.Equals(Right)));
        }
    }
}
