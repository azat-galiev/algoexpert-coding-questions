namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/smallest-difference"/>
    /// Time: O(nlog(n) + mlog(m))
    /// Space: O(1)
    internal class MediumQuestion_03_SmallestDifference : CodingQuestion<MediumQuestion_03_SmallestDifference.Input, int[]>
    {
        protected override int[] ExecuteSolution(Input input)
        {
            Array.Sort(input.ArrayOne);
            Array.Sort(input.ArrayTwo);

            var bestPair = new int[2];
            var bestDifference = int.MaxValue;

            var pointerOne = 0;
            var pointerTwo = 0;
            while (pointerOne < input.ArrayOne.Length && pointerTwo < input.ArrayTwo.Length)
            {
                var difference = Math.Abs(input.ArrayOne[pointerOne] - input.ArrayTwo[pointerTwo]);
                if (difference < bestDifference)
                {
                    bestDifference = difference;
                    bestPair[0] = input.ArrayOne[pointerOne];
                    bestPair[1] = input.ArrayTwo[pointerTwo];
                }

                if (difference == 0)
                {
                    break;
                }
                else if (input.ArrayOne[pointerOne] < input.ArrayTwo[pointerTwo])
                {
                    pointerOne++;
                }
                else
                {
                    pointerTwo++;
                }
            }

            return bestPair;
        }

        protected override bool CompareActualAndExpectedOuputs(int[] expected, int[] actual)
        {
            if (expected.Length != actual.Length) return false;
            for (var i = 0; i < expected.Length; i++)
            {
                if (actual[i] != expected[i]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<Input, int[]> GetTests()
        {
            return new Dictionary<Input, int[]>
            {
                {
                    new Input
                    {
                        ArrayOne = new int[] { -1, 5, 10, 20, 28, 3 },
                        ArrayTwo = new int[] { 26, 134, 135, 15, 17 },
                    },
                    new int[] { 28, 26 }
                }
            };
        }

        internal class Input
        {
            public required int[] ArrayOne { get; set; }
            public required int[] ArrayTwo { get; set; }
        }
    }
}
