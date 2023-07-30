using CodingQuestions.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/union-find"/>
    /// Actual implementation is in the <see cref="UnionFind"/> class.
    internal class MediumQuestion_16_UnionFind : CodingQuestion<MediumQuestion_16_UnionFind.Input, bool>
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
                            var unionFind = new UnionFind();
                            unionFind.CreateSet(5);
                            unionFind.CreateSet(10);
                            Assert.AreEqual(5, unionFind.Find(5));
                            Assert.AreEqual(10, unionFind.Find(10));
                            unionFind.Union(5, 10);
                            Assert.AreEqual(5, unionFind.Find(5));
                            Assert.AreEqual(5, unionFind.Find(10));
                            unionFind.CreateSet(20);
                            Assert.AreEqual(20, unionFind.Find(20));
                            unionFind.Union(20, 10);
                            Assert.AreEqual(5, unionFind.Find(5));
                            Assert.AreEqual(5, unionFind.Find(10));
                            Assert.AreEqual(5, unionFind.Find(20));
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
