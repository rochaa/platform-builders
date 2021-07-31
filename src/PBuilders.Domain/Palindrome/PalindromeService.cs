using System.Linq;

namespace PBuilders.Domain.Palindrome
{
    public class PalindromeService
    {
        public static bool IsPalidrome(string word)
        {
            var wordLower = word.ToLower();
            return wordLower.SequenceEqual(wordLower.Reverse());
        }
    }
}