namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/best-seat"/>
    /// Time: O(n) where n is the number of seats
    /// Space: O(1)
    internal class MediumQuestion_29_BestSeat : CodingQuestion<int[], int>
    {
        protected override int ExecuteSolution(int[] seats)
        {
            var numFreeSeats = 0;
            var maxFreeSeats = 0;
            var lastGoodSeat = -1;

            for (var i = 0; i <= seats.Length; i++)
            {
                // If we went through the whole row, or a series of free seats is finished.
                if (i == seats.Length || seats[i] == 1)
                {
                    // If we found a better seat than before, or it's the first good one.
                    if (maxFreeSeats < numFreeSeats)
                    {
                        maxFreeSeats = numFreeSeats;

                        // We calculate the middle of the series of free seats.
                        lastGoodSeat = i - (maxFreeSeats / 2) - 1;
                    }

                    numFreeSeats = 0;
                }
                // We found a free seat, so incrementing the counter;
                else if (seats[i] == 0)
                {
                    numFreeSeats++;
                }
            }

            return lastGoodSeat;
        }

        protected override bool CompareActualAndExpectedOuputs(int expected, int actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<int[], int> GetTests()
        {
            return new Dictionary<int[], int>
            {
                {
                    new int[] {1, 0, 1, 0, 0, 0, 1},
                    4
                }
            };
        }
    }
}
