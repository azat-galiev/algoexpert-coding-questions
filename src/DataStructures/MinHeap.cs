namespace CodingQuestions.DataStructures
{
    /// <see href="https://www.algoexpert.io/questions/min-heap-construction"/>
    internal class MinHeap
    {
        /// <summary>
        /// Left public for testing purposes.
        /// </summary>
        public readonly List<int> heap = new();

        public MinHeap(List<int> list)
        {
            heap = list;
            InitializeHeap();
        }

        // Time: O(log(n)) where n is the size of the heap
        // Space: O(1)
        public void SiftDown(int currentIdx, int endIdx)
        {
            // Loop down while we have at least one child.
            var childOneIdx = currentIdx * 2 + 1;
            while (childOneIdx <= endIdx)
            {
                // Do we have the second child?
                var childTwoIdx = currentIdx * 2 + 2;
                if (childTwoIdx > endIdx) childTwoIdx = -1;

                // If we have the second child, and it's smaller than the first one,
                // go this route, otherwise go towards the first child.
                var idxToSwap = childOneIdx;
                if (childTwoIdx != -1 && heap[childTwoIdx] < heap[childOneIdx])
                    idxToSwap = childTwoIdx;

                // The current element should be lower, so we continue.
                if (heap[idxToSwap] < heap[currentIdx])
                {
                    Swap(idxToSwap, currentIdx, heap);

                    currentIdx = idxToSwap;
                    childOneIdx = currentIdx * 2 + 1;
                }
                // We reached the proper position.
                else
                {
                    break;
                }
            }
        }

        // Time: O(log(n)) where n is the size of the heap
        // Space: O(1)
        public void SiftUp(int currentIdx)
        {
            // In order to sift an element up, we compare it against the parent, 
            // and if it's smaller (i.e., parent should be lower than the current element), 
            // we swap them, and continue until some parent is smaller than the current element.
            var parentIdx = (currentIdx - 1) / 2;
            while (currentIdx > 0 && heap[currentIdx] < heap[parentIdx])
            {
                Swap(currentIdx, parentIdx, heap);
                currentIdx = parentIdx;
                parentIdx = (currentIdx - 1) / 2;
            }
        }

        // Time: O(1)
        // Space: O(1)
        public int Peek()
        {
            return heap[0];
        }

        // Time: O(log(n)) where n is the size of the heap
        // Space: O(1)
        public int Remove()
        {
            var removed = heap[0];

            // We don't need the first element anymore, so we swap it with the very last element 
            // (because it's pretty easy to remove the last element) and remove it.
            Swap(0, heap.Count - 1, heap);
            heap.RemoveAt(heap.Count - 1);

            // Sift the previously-last element down until it lands a proper position.
            SiftDown(0, heap.Count - 1);

            return removed;
        }

        // Time: O(log(n)) where n is the size of the heap
        // Space: O(1)
        public void Insert(int value)
        {
            // We add the new value to the end of the array (i.e., at the next free position of our BT),
            // and then sift it up until it lands a correct position.
            heap.Add(value);
            SiftUp(heap.Count - 1);
        }

        // Time: O(n) where n is the size of the array
        // Space: O(1)
        private void InitializeHeap()
        {
            var firstParentIdx = (heap.Count - 1) / 2;
            for (var currentIdx = firstParentIdx; currentIdx >= 0; currentIdx--)
                SiftDown(currentIdx, heap.Count - 1);
        }

        // Time: O(1)
        // Space: O(1)
        private static void Swap(int idx1, int idx2, List<int> heap)
        {
            (heap[idx2], heap[idx1]) = (heap[idx1], heap[idx2]);
        }
    }
}
