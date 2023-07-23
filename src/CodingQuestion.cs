namespace CodingQuestions
{
    internal interface ICodingQuestion
    {
        void Run();
    }

    internal abstract class CodingQuestion<TInput, TOutput> : ICodingQuestion
    {
        protected abstract TOutput ExecuteSolution(TInput input);

        protected abstract bool CompareActualAndExpectedOuputs(TOutput expected, TOutput actual);

        protected abstract IReadOnlyDictionary<TInput, TOutput> GetTests();

        public void Run()
        {
            Console.WriteLine();
            Console.WriteLine(GetType().Name);

            var i = 1;
            foreach (var test in GetTests())
            {
                var input = test.Key;
                var expectedOutput = test.Value;

                Console.Write($"\tTest Case #{i++}: ");

                var actualOutput = ExecuteSolution(input)!;
                if (CompareActualAndExpectedOuputs(expectedOutput, actualOutput))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Passed");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed");
                }

                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
