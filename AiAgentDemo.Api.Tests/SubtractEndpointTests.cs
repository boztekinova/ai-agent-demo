using System.Net;
using System.Net.Http.Json;
using System.Text;
using AiAgentDemo.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AiAgentDemo.Api.Tests
{
    public class SubtractEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public SubtractEndpointTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task PostSubtract_WithValidDoubles_ReturnsCorrectDifference()
        {
            var request = new SubtractRequest
            {
                NumberOne = 10.5,
                NumberTwo = 4.25
            };

            var response = await _httpClient.PostAsJsonAsync("/api/subtract", request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var subtractResponse = await response.Content.ReadFromJsonAsync<SubtractResponse>();
            Assert.NotNull(subtractResponse);
            Assert.Equal(6.25, subtractResponse.Result);
        }

        [Fact]
        public async Task PostSubtract_WithNegativeValues_ReturnsCorrectDifference()
        {
            var request = new SubtractRequest
            {
                NumberOne = -3.5,
                NumberTwo = 2.0
            };

            var response = await _httpClient.PostAsJsonAsync("/api/subtract", request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var subtractResponse = await response.Content.ReadFromJsonAsync<SubtractResponse>();
            Assert.NotNull(subtractResponse);
            Assert.Equal(-5.5, subtractResponse.Result);
        }

        [Fact]
        public async Task PostSubtract_WhenNumberOneIsMissing_ReturnsBadRequest()
        {
            var jsonContent = new StringContent(
                """{"numberTwo":4.5}""",
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/api/subtract", jsonContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostSubtract_WhenNumberTwoIsMissing_ReturnsBadRequest()
        {
            var jsonContent = new StringContent(
                """{"numberOne":4.5}""",
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/api/subtract", jsonContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostSubtract_WhenNumberOneIsNull_ReturnsBadRequest()
        {
            var jsonContent = new StringContent(
                """{"numberOne":null,"numberTwo":4.5}""",
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/api/subtract", jsonContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostSubtract_WhenNumberTwoIsNull_ReturnsBadRequest()
        {
            var jsonContent = new StringContent(
                """{"numberOne":4.5,"numberTwo":null}""",
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/api/subtract", jsonContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostSubtract_WhenValuesAreNotNumbers_ReturnsBadRequest()
        {
            var jsonContent = new StringContent(
                """{"numberOne":"abc","numberTwo":2.0}""",
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/api/subtract", jsonContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostSubtract_WhenBodyIsEmpty_ReturnsBadRequest()
        {
            var jsonContent = new StringContent(
                "{}",
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/api/subtract", jsonContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
