namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/colliding-asteroids"/>
    /// Time: O(n) where n is the number of asteroids (while loop doesn't
    /// make it n^2, since we'll go through every asteroid 2 times at most)
    /// Space: O(n)
    internal class MediumQuestion_18_CollidingAsteroids : CodingQuestion<int[], int[]>
    {
        protected override int[] ExecuteSolution(int[] asteroids)
        {
            var result = new Stack<int>();

            foreach (var asteroid in asteroids)
            {
                // If asteroid is moving to the right, then if cannot collide
                // with another asteroids already on the stack. Just adding it.
                if (asteroid > 0)
                {
                    result.Push(asteroid);
                    continue;
                }

                // So, asteroid is moving to the left. We need to check another asteroids
                // to the left of the current one on the stack to find collisions.
                while (true)
                {
                    // We don't have any asteroids to the left, or they are moving away 
                    // from the current one.
                    if (result.Count == 0 || result.Peek() < 0)
                    {
                        result.Push(asteroid);
                        break;
                    }

                    var size = Math.Abs(asteroid);

                    // Asteroid to the left is bigger, collision destroys the current one.
                    // Then, just skipping it.
                    if (result.Peek() > size) break;

                    // Both asteroids are of the same size, so both are destroyed.
                    if (result.Peek() == size)
                    {
                        result.Pop();
                        break;
                    }

                    // Asteroid to the left is smaller than the current one, so we destroy it and go further,
                    // maybe there are more asteroids we're going to destroy.
                    result.Pop();
                }
            }

            var resultArray = result.ToArray();
            Array.Reverse(resultArray);

            return resultArray;
        }

        protected override bool CompareActualAndExpectedOuputs(int[] expected, int[] actual)
        {
            if (expected.Length != actual.Length) return false;
            for (var i = 0; i < expected.Length; i++)
            {
                if (expected[i] != actual[i]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<int[], int[]> GetTests()
        {
            return new Dictionary<int[], int[]>
            {
                {
                    new int[] { -3, 5, -8, 6, 7, -4, -7 },
                    new int[] { -3, -8, 6 }
                }
            };
        }
    }
}
