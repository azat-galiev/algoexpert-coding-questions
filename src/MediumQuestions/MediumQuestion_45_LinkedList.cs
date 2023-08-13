using CodingQuestions.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/linked-list-construction"/>
    /// Actual implementation is in the <see cref="DoublyLinkedList"/> class.
    internal class MediumQuestion_45_LinkedList : CodingQuestion<MediumQuestion_45_LinkedList.Input, bool>
    {
        protected override bool ExecuteSolution(Input input)
        {
            try
            {
                input.Test();
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected override bool CompareActualAndExpectedOuputs(bool expected, bool actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<Input, bool> GetTests()
        {
            return new Dictionary<Input, bool>
            {
                {
                    new Input
                    {
                        Test = () =>
                        {
                            var doublyLinkedList = new DoublyLinkedList();
                            doublyLinkedList.SetHead(new DoublyLinkedList.Node(1));
                            doublyLinkedList.InsertAfter(doublyLinkedList.Tail, new DoublyLinkedList.Node(2));
                            doublyLinkedList.InsertAfter(doublyLinkedList.Tail, new DoublyLinkedList.Node(3));
                            doublyLinkedList.InsertAfter(doublyLinkedList.Tail, new DoublyLinkedList.Node(4));
                            doublyLinkedList.InsertAfter(doublyLinkedList.Tail, new DoublyLinkedList.Node(5));

                            var node4 = doublyLinkedList.Tail.Prev;
                            doublyLinkedList.SetHead(node4);
                            Assert.AreEqual(4, doublyLinkedList.Head.Value);
                            Assert.AreEqual(1, doublyLinkedList.Head.Next.Value);

                            doublyLinkedList.SetTail(new DoublyLinkedList.Node(6));
                            Assert.AreEqual(6, doublyLinkedList.Tail.Value);
                            Assert.AreEqual(5, doublyLinkedList.Tail.Prev.Value);

                            var node3 = doublyLinkedList.Head.Next.Next.Next;
                            doublyLinkedList.InsertBefore(doublyLinkedList.Tail, node3);
                            doublyLinkedList.InsertAfter(doublyLinkedList.Tail, new DoublyLinkedList.Node(3));

                            Assert.AreEqual(3, doublyLinkedList.Tail.Prev.Prev.Value);
                            Assert.AreEqual(6, doublyLinkedList.Tail.Prev.Value);
                            Assert.AreEqual(3, doublyLinkedList.Tail.Value);

                            doublyLinkedList.InsertAtPosition(1, new DoublyLinkedList.Node(3));

                            Assert.AreEqual(3, doublyLinkedList.Head.Value);
                            Assert.AreEqual(4, doublyLinkedList.Head.Next.Value);
                            Assert.AreEqual(1, doublyLinkedList.Head.Next.Next.Value);

                            doublyLinkedList.RemoveNodesWithValue(3);
                            Assert.AreEqual(4, doublyLinkedList.Head.Value);
                            Assert.AreEqual(1, doublyLinkedList.Head.Next.Value);
                            Assert.AreEqual(2, doublyLinkedList.Head.Next.Next.Value);
                            Assert.AreEqual(5, doublyLinkedList.Head.Next.Next.Next.Value);
                            Assert.AreEqual(6, doublyLinkedList.Head.Next.Next.Next.Next.Value);
                            Assert.IsNull(doublyLinkedList.Head.Next.Next.Next.Next.Next);

                            doublyLinkedList.Remove(doublyLinkedList.Head.Next.Next);
                            Assert.AreEqual(4, doublyLinkedList.Head.Value);
                            Assert.AreEqual(1, doublyLinkedList.Head.Next.Value);
                            Assert.AreEqual(5, doublyLinkedList.Head.Next.Next.Value);
                            Assert.AreEqual(6, doublyLinkedList.Head.Next.Next.Next.Value);
                            Assert.IsNull(doublyLinkedList.Head.Next.Next.Next.Next);

                            Assert.IsTrue(doublyLinkedList.ContainsNodeWithValue(5));
                        }
                    },
                    true
                }
            };
        }

        internal class Input
        {
            public required Action Test { get; set; }
        }
    }
}
