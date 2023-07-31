using CodingQuestions.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/min-max-stack-construction"/>
    /// Actual implementation is in the <see cref="MinMaxStack"/> class.
    internal class MediumQuestion_19_MinMaxStackConstruction : CodingQuestion<MediumQuestion_19_MinMaxStackConstruction.Input, bool>
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
                            var minMaxStack = new MinMaxStack();

                            minMaxStack.Push(5);
                            Assert.AreEqual(5, minMaxStack.GetMin());
                            Assert.AreEqual(5, minMaxStack.GetMax());
                            Assert.AreEqual(5, minMaxStack.Peek());

                            minMaxStack.Push(7);
                            Assert.AreEqual(5, minMaxStack.GetMin());
                            Assert.AreEqual(7, minMaxStack.GetMax());
                            Assert.AreEqual(7, minMaxStack.Peek());

                            minMaxStack.Push(2);
                            Assert.AreEqual(2, minMaxStack.GetMin());
                            Assert.AreEqual(7, minMaxStack.GetMax());
                            Assert.AreEqual(2, minMaxStack.Peek());

                            Assert.AreEqual(2, minMaxStack.Pop());
                            Assert.AreEqual(7, minMaxStack.Pop());

                            Assert.AreEqual(5, minMaxStack.GetMin());
                            Assert.AreEqual(5, minMaxStack.GetMax());
                            Assert.AreEqual(5, minMaxStack.Peek());
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
