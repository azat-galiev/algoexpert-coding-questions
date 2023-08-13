namespace CodingQuestions.DataStructures
{
    /// <see href="https://www.algoexpert.io/questions/linked-list-construction"/>
    internal class DoublyLinkedList
    {
        public Node Head;
        public Node Tail;

        // Time: O(1)
        // Space: O(1)
        public void SetHead(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            InsertBefore(Head, node);
        }

        // Time: O(1)
        // Space: O(1)
        public void SetTail(Node node)
        {
            if (Tail == null)
            {
                SetHead(node);
                return;
            }

            InsertAfter(Tail, node);
        }

        // Time: O(1)
        // Space: O(1)
        public void InsertBefore(Node node, Node nodeToInsert)
        {
            Remove(nodeToInsert);

            nodeToInsert.Next = node;
            nodeToInsert.Prev = node.Prev;

            if (node.Prev == null)
                Head = nodeToInsert;
            else
                node.Prev.Next = nodeToInsert;

            node.Prev = nodeToInsert;
        }

        // Time: O(1)
        // Space: O(1)
        public void InsertAfter(Node node, Node nodeToInsert)
        {
            Remove(nodeToInsert);

            nodeToInsert.Next = node.Next;
            nodeToInsert.Prev = node;

            if (node.Next == null)
                Tail = nodeToInsert;
            else
                node.Next.Prev = nodeToInsert;

            node.Next = nodeToInsert;
        }

        // Time: O(n)
        // Space: O(1)
        public void InsertAtPosition(int position, Node nodeToInsert)
        {
            if (position == 1)
            {
                SetHead(nodeToInsert);
                return;
            }

            var i = 1;
            var node = Head;
            while (i++ < position && node != null)
                node = node.Next;

            if (node != null)
                InsertBefore(node, nodeToInsert);
            else
                SetTail(nodeToInsert);
        }

        // Time: O(n)
        // Space: O(1)
        public void RemoveNodesWithValue(int value)
        {
            var node = Head;
            while (node != null)
            {
                var next = node.Next;

                if (node.Value == value)
                    Remove(node);

                node = next;
            }
        }

        // Time: O(1)
        // Space: O(1)
        public void Remove(Node node)
        {
            if (node == null) return;

            if (node == Head)
                Head = node.Next;

            if (node == Tail)
                Tail = node.Prev;

            if (node.Prev != null)
                node.Prev.Next = node.Next;

            if (node.Next != null)
                node.Next.Prev = node.Prev;

            node.Prev = null;
            node.Next = null;
        }

        public bool ContainsNodeWithValue(int value)
        {
            var node = Head;
            while (node != null)
            {
                if (node.Value == value)
                    return true;

                node = node.Next;
            }

            return false;
        }

        internal class Node
        {
            public int Value;
            public Node Prev;
            public Node Next;

            internal Node(int value)
            {
                this.Value = value;
            }
        }
    }
}
