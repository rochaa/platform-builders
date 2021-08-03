using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PBuilders.Domain.BynarySearchTree.Entity;
using PBuilders.WebAPI.Test.Config;
using Xunit;

namespace PBuilders.WebAPI.Test
{
    public class BynarySearchTreeControllerTest : IClassFixture<WebApplicationFactory<StartupWebAPITest>>
    {
        private readonly HttpClient _client;
        private readonly DatabaseTestsFixture _dataBaseFixture;

        public BynarySearchTreeControllerTest(WebApplicationFactory<StartupWebAPITest> fixture)
        {
            _dataBaseFixture = new DatabaseTestsFixture();
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task Must_Return_The_Specified_Node_WebAPI()
        {
            var valueTest = 2;
            var tree = new Tree();
            tree.InsertValues(1, 2, 3);
            _dataBaseFixture.CreateTree(tree);

            var response = await _client.GetAsync($"v1/bynary-search-tree/get-node-by-value/{valueTest}");
            var nodeValueResponse = JsonConvert.DeserializeObject<object>(await response.Content.ReadAsStringAsync());

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}