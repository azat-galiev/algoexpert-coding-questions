namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/three-number-sum"/>
    /// Time: O(n^2)
    /// Space: O(n)
    internal class MediumQuestion_02_ThreeNumberSum : CodingQuestion<MediumQuestion_02_ThreeNumberSum.Input, List<int[]>>
    {
        protected override List<int[]> ExecuteSolution(Input input)
        {
            var result = new List<int[]>();

            Array.Sort(input.Array);
            for (var i = 0; i < input.Array.Length - 2; i++)
            {
                var left = i + 1;
                var right = input.Array.Length - 1;
                while (left < right)
                {
                    var currentSum = input.Array[i] + input.Array[left] + input.Array[right];
                    if (currentSum == input.TargetSum)
                    {
                        result.Add(new int[] { input.Array[i], input.Array[left], input.Array[right] });
                        right--;
                        left++;
                    }
                    else if (currentSum > input.TargetSum)
                    {
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }
            }

            return result;
        }

        protected override bool CompareActualAndExpectedOuputs(List<int[]> expected, List<int[]> actual)
        {
            if (expected.Count != actual.Count) return false;
            for (var i = 0; i < expected.Count; i++)
            {
                if (actual[i].Length != expected[i].Length) return false;
                for (var j = 0; j < expected[i].Length; j++)
                {
                    if (actual[i][j] != expected[i][j]) return false;
                }
            }

            return true;
        }

        protected override IReadOnlyDictionary<Input, List<int[]>> GetTests()
        {
            return new Dictionary<Input, List<int[]>>
            {
                {
                    new Input { Array = new int[] { 12, 3, 1, 2, -6, 5, -8, 6 }, TargetSum = 0 },
                    new List<int[]>
                    {
                        new int[] { -8, 2, 6 },
                        new int[] { -8, 3, 5 },
                        new int[] { -6, 1, 5 },
                    }
                }
            };
        }

        internal class Input
        {
            public required int[] Array { get; set; }
            public int TargetSum { get; set; }
        }
    }
}
