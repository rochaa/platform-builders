using PBuilders.Domain.Palindrome;
using Xunit;

namespace PBuilders.Domain.Test
{
    public class PalindromeServiceTest
    {
        [Fact]
        public void Must_Return_True_When_It_Is_A_Palindrome()
        {
            var wordPalindrome = "Deleveled";
        
            var result = PalindromeService.IsPalidrome(wordPalindrome);
        
            Assert.True(result);
        }

        [Fact]
        public void Must_Return_False_When_Not_A_Palindrome()
        {
            var wordPalindrome = "Builder";
        
            var result = PalindromeService.IsPalidrome(wordPalindrome);
        
            Assert.False(result);
        }
    }
}