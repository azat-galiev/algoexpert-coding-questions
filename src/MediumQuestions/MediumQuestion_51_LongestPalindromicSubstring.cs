using System.Text;

namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/longest-palindromic-substring"/>
    /// Time: O(n^2) where n is the length of the string.
    /// Space: O(n)
    internal class MediumQuestion_51_LongestPalindromicSubstring : CodingQuestion<string, string>
    {
        protected override string ExecuteSolution(string str)
        {
            // We store the currently longest palindrome as a pair of indices:
            // index of the start and the end of the palindrome.
            var longestPalindrome = new Tuple<int, int>(0, 0);

            // Iterate through all of the chars (i.e., potential centers of palindromes).
            for (var i = 0; i < str.Length; i++)
            {
                // Case 1. Center is at the given char.
                ProcessPotentialPalindrome(str, ref longestPalindrome, i - 1, i + 1);

                // Case 2. Center is between the current and the previous char.
                ProcessPotentialPalindrome(str, ref longestPalindrome, i - 1, i);
            }

            // Convert pair of indicies into the actual string.
            var result = new StringBuilder(GetPalindromeLength(longestPalindrome));
            for (var i = longestPalindrome.Item1; i <= longestPalindrome.Item2; i++)
                result.Append(str[i]);

            return result.ToString();
        }

        // Given the start and the end of a palindrome, expand it and save
        // if the final palindrome is longer than any previously found.
        private static void ProcessPotentialPalindrome(
            string str,
            ref Tuple<int, int> longestPalindrome,
            int start,
            int end)
        {
            // Expanding.
            while (start >= 0 && end < str.Length && str[start] == str[end])
            {
                start--;
                end++;
            }

            // Expanding will always go one step further, so we need to rewind.
            start++;
            end--;

            var currentPalindromeLength = end - start + 1;
            var largestPalindromeLength = GetPalindromeLength(longestPalindrome);
            if (currentPalindromeLength > largestPalindromeLength)
            {
                longestPalindrome = new Tuple<int, int>(start, end);
            }
        }

        private static int GetPalindromeLength(Tuple<int, int> palindrome)
        {
            return palindrome.Item2 - palindrome.Item1 + 1;
        }

        protected override bool CompareActualAndExpectedOuputs(string expected, string actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<string, string> GetTests()
        {
            return new Dictionary<string, string>
            {
                { "abaxyzzyxf", "xyzzyx" }
            };
        }
    }
}
