using System.Net;
using System.Net.Http.Json;
using System.Text;
using AiAgentDemo.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AiAgentDemo.Api.Tests
{
    public class SumEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public SumEndpointTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task PostSum_WithValidIntegers_ReturnsCorrectSum()
        {
            var request = new SumRequest
            {
                NumberOne = 5,
                NumberTwo = 7
            };

            var response = await _httpClient.PostAsJsonAsync("/api/sum", request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var sumResponse = await response.Content.ReadFromJsonAsync<SumResponse>();
            Assert.NotNull(sumResponse);
            Assert.Equal(12, sumResponse.Sum);
        }

        [Fact]
        public async Task PostSum_WithNegativeIntegers_ReturnsCorrectSum()
        {
            var request = new SumRequest
            {
                NumberOne = -3,
                NumberTwo = 10
            };

            var response = await _httpClient.PostAsJsonAsync("/api/sum", request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var sumResponse = await response.Content.ReadFromJsonAsync<SumResponse>();
            Assert.NotNull(sumResponse);
            Assert.Equal(7, sumResponse.Sum);
        }

        [Fact]
        public async Task PostSum_WhenNumberOneIsMissing_ReturnsBadRequest()
        {
            var jsonContent = new StringContent(
                """{"numberTwo":4}""",
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/api/sum", jsonContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostSum_WhenNumberTwoIsMissing_ReturnsBadRequest()
        {
            var jsonContent = new StringContent(
                """{"numberOne":4}""",
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/api/sum", jsonContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostSum_WhenNumberOneIsNull_ReturnsBadRequest()
        {
            var jsonContent = new StringContent(
                """{"numberOne":null,"numberTwo":4}""",
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/api/sum", jsonContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostSum_WhenNumberTwoIsNull_ReturnsBadRequest()
        {
            var jsonContent = new StringContent(
                """{"numberOne":4,"numberTwo":null}""",
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/api/sum", jsonContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostSum_WhenValuesAreNotIntegers_ReturnsBadRequest()
        {
            var jsonContent = new StringContent(
                """{"numberOne":"abc","numberTwo":2}""",
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/api/sum", jsonContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostSum_WhenBodyIsEmpty_ReturnsBadRequest()
        {
            var jsonContent = new StringContent(
                "{}",
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/api/sum", jsonContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
