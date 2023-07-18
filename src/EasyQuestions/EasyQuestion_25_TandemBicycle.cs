using System.Collections;

namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/tandem-bicycle"/>
    /// Time: O(nlog(n))
    /// Space: O(1)
    internal class EasyQuestion_25_TandemBicycle : CodingQuestion<EasyQuestion_25_TandemBicycle.Input, int>
    {
        protected override int ExecuteSolution(Input input)
        {
            IComparer<int> comparer = input.Fastest ? new NegativeComparer() : Comparer<int>.Default;

            Array.Sort(input.RedShirtSpeeds);
            Array.Sort(input.BlueShirtSpeeds, comparer);

            var totalSpeed = 0;
            for (var i = 0; i < input.RedShirtSpeeds.Length; i++)
            {
                totalSpeed += Math.Max(input.RedShirtSpeeds[i], input.BlueShirtSpeeds[i]);
            }

            return totalSpeed;
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<Input, int> GetTests()
        {
            return new Dictionary<Input, int>
            {
                {
                    new Input()
                    {
                        Fastest = true,
                        RedShirtSpeeds = new int[] { 5, 5, 3, 9, 2 },
                        BlueShirtSpeeds = new int[] { 3, 6, 7, 2, 1 }
                    },
                    32
                }
            };
        }

        internal class NegativeComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y - x;
            }
        }

        internal class Input
        {
            public required int[] RedShirtSpeeds { get; set; }
            public required int[] BlueShirtSpeeds { get; set; }
            public bool Fastest { get; set; }
        }
    }
}
