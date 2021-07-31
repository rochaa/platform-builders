namespace PBuilders.WebAPI.Models
{
    public class IsPalindromeModelRequest
    {
        public IsPalindromeModelRequest(string word)
        {
            Word = word;
        }

        public string Word { get; set; }
    }
}