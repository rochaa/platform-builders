namespace PBuilders.WebAPI.Models
{
    public class IsPalindromeModelResponse
    {
        public IsPalindromeModelResponse(string word, bool isPalidrome)
        {
            Word = word;
            IsPalidrome = isPalidrome;
        }

        public string Word { get; set; }
        public bool IsPalidrome { get; set; }
    }
}