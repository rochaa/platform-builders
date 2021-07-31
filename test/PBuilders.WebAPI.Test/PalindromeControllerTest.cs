using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PBuilders.WebAPI.Models;
using Xunit;

namespace PBuilders.WebAPI.Test
{
    public class PalindromeControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public PalindromeControllerTest(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task Must_Return_True_When_It_Is_A_Palindrome_WebAPI()
        {
            var isPalindromeModelRequest = new IsPalindromeModelRequest("Deleveled");

            var response = await _client.PostAsJsonAsync("v1/palindrome/check", isPalindromeModelRequest);
            var isPalindromeModelResponse = JsonConvert.DeserializeObject<IsPalindromeModelResponse>(await response.Content.ReadAsStringAsync());    

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            isPalindromeModelResponse.IsPalidrome.Should().BeTrue();
        }

        [Fact]
        public async Task Must_Return_False_When_Not_A_Palindrome_WebAPI()
        {
            var isPalindromeModelRequest = new IsPalindromeModelRequest("Builder");

            var response = await _client.PostAsJsonAsync("v1/palindrome/check", isPalindromeModelRequest);
            var isPalindromeModelResponse = JsonConvert.DeserializeObject<IsPalindromeModelResponse>(await response.Content.ReadAsStringAsync());    

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            isPalindromeModelResponse.IsPalidrome.Should().BeFalse();
        }
    }
}