using CodingQuestions.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/min-heap-construction"/>
    /// Actual implementation is in <see cref="MinHeap"/>
    internal class MediumQuestion_52_MinHeap : CodingQuestion<MediumQuestion_52_MinHeap.Input, bool>
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
                            var minHeap = new MinHeap(new List<int> { 48, 12, 24, 7, 8, -5, 24, 391, 24, 56, 2, 6, 8, 41 });
                            AssertListsAreEqual(new List<int> { -5, 2, 6, 7, 8, 8, 24, 391, 24, 56, 12, 24, 48, 41 }, minHeap.heap);

                            minHeap.Insert(76);
                            AssertListsAreEqual(new List<int> { -5, 2, 6, 7, 8, 8, 24, 391, 24, 56, 12, 24, 48, 41, 76 }, minHeap.heap);

                            Assert.AreEqual(-5, minHeap.Peek());
                            AssertListsAreEqual(new List<int> { -5, 2, 6, 7, 8, 8, 24, 391, 24, 56, 12, 24, 48, 41, 76 }, minHeap.heap);

                            Assert.AreEqual(-5, minHeap.Remove());
                            AssertListsAreEqual(new List<int> { 2, 7, 6, 24, 8, 8, 24, 391, 76, 56, 12, 24, 48, 41 }, minHeap.heap);

                            Assert.AreEqual(2, minHeap.Peek());
                            Assert.AreEqual(2, minHeap.Remove());
                            AssertListsAreEqual(new List<int> { 6, 7, 8, 24, 8, 24, 24, 391, 76, 56, 12, 41, 48 }, minHeap.heap);

                            Assert.AreEqual(6, minHeap.Peek());

                            minHeap.Insert(87);
                            AssertListsAreEqual(new List<int> { 6, 7, 8, 24, 8, 24, 24, 391, 76, 56, 12, 41, 48, 87 }, minHeap.heap);
                        }
                    },
                    true
                }
            };
        }

        private static void AssertListsAreEqual(List<int> expected, List<int> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);
            for (var i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        internal class Input
        {
            public required Action Test { get; set; }
        }
    }
}
