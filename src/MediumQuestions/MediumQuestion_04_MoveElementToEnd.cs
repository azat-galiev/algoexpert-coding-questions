namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/move-element-to-end"/>
    /// Time: O(n)
    /// Space: O(1)
    internal class MediumQuestion_04_MoveElementToEnd : CodingQuestion<MediumQuestion_04_MoveElementToEnd.Input, List<int>>
    {
        protected override List<int> ExecuteSolution(Input input)
        {
            var left = 0;
            var right = input.Array.Count - 1;
            while (left < right)
            {
                if (input.Array[left] == input.ToMove)
                {
                    while (right > 0 && input.Array[right] == input.ToMove) right--;
                    if (left >= right) break;

                    input.Array[left] = input.Array[right];
                    input.Array[right] = input.ToMove;
                }

                left++;
            }

            return input.Array;
        }

        protected override bool CompareActualAndExpectedOuputs(List<int> expected, List<int> actual)
        {
            if (expected.Count != actual.Count) return false;
            for (int i = 0; i < expected.Count; i++)
            {
                if (actual[i] != expected[i]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<Input, List<int>> GetTests()
        {
            return new Dictionary<Input, List<int>>
            {
                {
                    new Input
                    {
                        Array = new List<int> { 2, 1, 2, 2, 2, 3, 4, 2 },
                        ToMove = 2,
                    },
                    new List<int> { 4, 1, 3, 2, 2, 2, 2, 2 }
                }
            };
        }

        internal class Input
        {
            public required List<int> Array { get; set; }
            public int ToMove { get; set; }
        }
    }
}
