namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/majority-element"/>
    /// Time: O(n) where n is the size of the array.
    /// Space: O(1)
    internal class MediumQuestion_53_MajorityElement : CodingQuestion<int[], int>
    {
        protected override int ExecuteSolution(int[] array)
        {
            var potentialAnswer = 0;
            var counter = 0;

            // Counter is the value by how much our potential answer is 
            // more often in the subarray seen so far. So, if the counter 
            // goes to 0, it means that our current answer is not a majority element
            // in the subarray we went through. So, the majority element for the whole
            // array should also be a majority element for the rest of the array.
            for (var i = 0; i < array.Length; i++)
            {
                if (counter == 0) potentialAnswer = array[i];

                if (array[i] != potentialAnswer) counter--;
                else counter++;
            }

            return potentialAnswer;
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<int[], int> GetTests()
        {
            return new Dictionary<int[], int>
            {
                { new int[] {  1, 2, 3, 2, 2, 1, 2 }, 2 },
            };
        }
    }
}
