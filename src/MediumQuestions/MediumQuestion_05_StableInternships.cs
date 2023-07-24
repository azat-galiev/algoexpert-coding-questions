namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/stable-internships"/>
    /// Time: O(n^2) where n is the number of interns and teams (they are equal).
    /// We iterate over every intern, and try to match it with every team (in the worst case).
    /// Space: O(n^2) to store team preferences.
    /// <seealso href="https://en.wikipedia.org/wiki/Stable_marriage_problem"/>
    /// <seealso href="https://en.wikipedia.org/wiki/Gale%E2%80%93Shapley_algorithm"/>
    internal class MediumQuestion_05_StableInternships : CodingQuestion<MediumQuestion_05_StableInternships.Input, int[][]>
    {
        protected override int[][] ExecuteSolution(Input input)
        {
            // Interns that we haven't found a team for. The task is done when this stack is empty.
            var internsWithoutTeam = new Stack<int>();
            for (var i = 0; i < input.Interns.Length; i++) internsWithoutTeam.Push(i);

            // Team-to-Intern mapping. Intermediate result
            var pairs = new Dictionary<int, int>();

            // Pointers to the current team preference for every intern. Every intern tries 
            // every team starting from the most preferred one until they find a stable match.
            var currentInternPreference = new int[input.Interns.Length];

            // For every team, we have a mapping of Intern-to-Rank to compare interns in O(log(n)).
            var teamPreferences = new List<Dictionary<int, int>>(input.Teams.Length);
            for (var i = 0; i < input.Teams.Length; i++)
            {
                teamPreferences.Add(new Dictionary<int, int>());
                for (var j = 0; j < input.Interns.Length; j++)
                {
                    teamPreferences[i][input.Teams[i][j]] = j;
                }
            }

            // The main loop over interns without a match.
            while (internsWithoutTeam.Count > 0)
            {
                var currentIntern = internsWithoutTeam.Pop();
                var currentPreferredTeam = input.Interns[currentIntern][currentInternPreference[currentIntern]];
                currentInternPreference[currentIntern]++;

                // If the team doesn't have a match yet with another intern, we create a match right away.
                if (!pairs.ContainsKey(currentPreferredTeam))
                {
                    pairs[currentPreferredTeam] = currentIntern;
                    continue;
                }

                var previousIntern = pairs[currentPreferredTeam];

                // If previously matched intern is more preferred for the team,
                // we keep it and put current intern back onto the stack.
                if (teamPreferences[currentPreferredTeam][previousIntern] < teamPreferences[currentPreferredTeam][currentIntern])
                {
                    internsWithoutTeam.Push(currentIntern);
                }
                // Otherwise, we replace previously matched intern with the current one,
                // and put previous intern back onto the stack.
                else
                {
                    pairs[currentPreferredTeam] = currentIntern;
                    internsWithoutTeam.Push(previousIntern);
                }
            }

            // Convert our Team-to-Intern mapping into a list of pairs.
            var result = new int[input.Interns.Length][];
            var pairIdx = 0;
            foreach (KeyValuePair<int, int> pair in pairs)
            {
                result[pairIdx] = new int[2];
                result[pairIdx][0] = pair.Value;
                result[pairIdx][1] = pair.Key;
                pairIdx++;
            }

            return result;
        }

        protected override bool CompareActualAndExpectedOuputs(int[][] expected, int[][] actual)
        {
            if (expected.Length != actual.Length) return false;
            for (var i = 0; i < expected.Length; i++)
            {
                if (expected[i].Length != actual[i].Length) return false;
                for (var j = 0;  j < expected[i].Length; j++)
                {
                    if (expected[i][j] != actual[i][j]) return false;
                }
            }

            return true;
        }

        protected override IReadOnlyDictionary<Input, int[][]> GetTests()
        {
            return new Dictionary<Input, int[][]>
            {
                {
                    new Input
                    {
                        Interns = new int[][]
                        {
                            new int[] { 0, 1, 2 },
                            new int[] { 1, 0, 2 },
                            new int[] { 1, 2, 0 },
                        },
                        Teams = new int[][]
                        {
                            new int[] { 2, 1, 0 },
                            new int[] { 1, 2, 0 },
                            new int[] { 0, 2, 1 },
                        },
                    },
                    new int[][]
                    {
                        new int[] { 1, 1 },
                        new int[] { 2, 2 },
                        new int[] { 0, 0 },
                    }
                }
            };
        }

        internal class Input
        {
            public required int[][] Interns { get; set; }
            public required int[][] Teams { get; set; }
        }
    }
}
