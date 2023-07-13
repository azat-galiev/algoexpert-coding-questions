namespace CodingQuestions.EasyQuestions
{
    internal class EasyQuestion_15_GenerateDocument_Input
    {
        public required string Characters { get; set; }

        public required string Document { get; set; }
    }

    /// <see cref="https://www.algoexpert.io/questions/generate-document"/>
    /// Time: O(n) where n is the number of characters in Characters
    /// Space: O(n)
    internal class EasyQuestion_15_GenerateDocument : CodingQuestion<EasyQuestion_15_GenerateDocument_Input, bool>
    {
        protected override bool ExecuteSolution(EasyQuestion_15_GenerateDocument_Input input)
        {
            if (input.Document == "") return true;
            if (input.Document.Length > input.Characters.Length) return false;

            var hashtable = new Dictionary<char, int>();
            foreach (var @char in input.Characters)
            {
                if (!hashtable.ContainsKey(@char)) hashtable[@char] = 0;
                hashtable[@char]++;
            }

            foreach (var @char in input.Document)
            {
                if (!hashtable.ContainsKey(@char)) return false;
                if (hashtable[@char]-- == 0) return false;
            }

            return true;
        }

        protected override bool CompareActualAndExpectedOuputs(bool expected, bool actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<EasyQuestion_15_GenerateDocument_Input, bool> GetTests()
        {
            return new Dictionary<EasyQuestion_15_GenerateDocument_Input, bool>
            {
                { new EasyQuestion_15_GenerateDocument_Input { Characters = "Bste!hetsi ogEAxpelrt x ", Document = "AlgoExpert is the Best!" }, true },
            };
        }
    }
}
