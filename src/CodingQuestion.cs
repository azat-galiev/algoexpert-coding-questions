namespace CodingQuestions
{
    internal interface ICodingQuestion
    {
        void Run();
    }

    internal abstract class CodingQuestion<TInput, TOutput> : ICodingQuestion
    {
        protected abstract TOutput ExecuteSolution(TInput input);

        protected abstract IReadOnlyDictionary<TInput, TOutput> GetTests();

        public void Run()
        {
            var i = 1;
            foreach (var test in GetTests())
            {
                var input = test.Key;
                var expectedOutput = test.Value;

                Console.Write($"Test Case #{i++}: ");

                var actualOutput = ExecuteSolution(input)!;
                if (actualOutput.Equals(expectedOutput))
                {
                    Console.WriteLine("Passed");
                }
                else
                {
                    Console.WriteLine($"Failed. Expected: {expectedOutput}, Actual: {actualOutput}");
                }
            }
        }
    }
}
