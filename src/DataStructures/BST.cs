namespace CodingQuestions.DataStructures
{
    /// <summary>
    /// Binary Search Tree
    /// </summary>
    internal class BST : IEquatable<BST>
    {
        public int Value;
        public BST? Left;
        public BST? Right;

        public bool IsLeaf => Left == null && Right == null;
        public bool HasSingleChild => (Left != null && Right == null) || (Left == null && Right != null);

        public BST(int value)
        {
            Value = value;
        }

        // Time: O(log(n)) on average, O(n) in the worst case
        // Space: O(1)
        public BST Insert(int value)
        {
            var currentNode = this;
            while (true)
            {
                if (value >= currentNode.Value)
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = new BST(value);
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                    }
                }
                else
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = new BST(value);
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                    }
                }
            }

            return this;
        }

        // Time: O(log(n)) on average, O(n) in the worst case
        // Space: O(1)
        public bool Contains(int value)
        {
            var currentNode = this;
            while (currentNode != null)
            {
                if (currentNode.Value == value) return true;
                else if (value < currentNode.Value) currentNode = currentNode.Left;
                else if (value > currentNode.Value) currentNode = currentNode.Right;
            }

            return false;
        }

        // Time: O(log(n)) on average, O(n) in the worst case
        // Space: O(1)
        public BST Remove(int value)
        {
            Remove(value, null);
            return this;
        }

        private void Remove(int value, BST? parentNode)
        {
            var currentNode = this;
            while (currentNode != null)
            {
                if (value < currentNode.Value)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.Left;
                }
                else if (value > currentNode.Value)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.Right;
                }
                else
                {
                    // We have both subtrees, replacing the current node with the minumum value from the right subtree
                    if (currentNode.Left != null && currentNode.Right != null)
                    {
                        currentNode.Value = currentNode.Right.FindMinValue();
                        currentNode.Right.Remove(currentNode.Value, currentNode);
                    }
                    // Removing root node without at least one subtree
                    else if (parentNode == null)
                    {
                        // Making left node a new root
                        if (currentNode.Left != null)
                        {
                            currentNode.Value = currentNode.Left.Value;
                            currentNode.Right = currentNode.Left.Right;
                            currentNode.Left = currentNode.Left.Left;
                        }
                        // Making right node a new root
                        else if (currentNode.Right != null)
                        {
                            currentNode.Value = currentNode.Right.Value;
                            currentNode.Left = currentNode.Right.Left;
                            currentNode.Right = currentNode.Right.Right;
                        }
                        // Removing single root node
                        else
                        {
                            // noop
                        }
                    }
                    else if (parentNode.Left == currentNode)
                    {
                        parentNode.Left = currentNode.Left ?? currentNode.Right;
                    }
                    else if (parentNode.Right == currentNode)
                    {
                        parentNode.Right = currentNode.Left ?? currentNode.Right;
                    }
                    break;
                }
            }
        }

        private int FindMinValue()
        {
            var currentNode = this;
            while (currentNode.Left != null) currentNode = currentNode.Left;

            return currentNode.Value;
        }

        public bool Equals(BST? other)
        {
            if (other == this) return true;
            if (other == null) return false;

            return other.Value == Value &&
                ((other.Left == null && Left == null) || (other.Left != null && Left != null && other.Left.Equals(Left))) &&
                ((other.Right == null && Right == null) || (other.Right != null && Right != null && other.Right.Equals(Right)));
        }
    }
}
