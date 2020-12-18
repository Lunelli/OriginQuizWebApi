using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using OriginQuiz.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace OriginQuiz.Tests
{
    [Collection("Integration Tests")]
    public class MainControllerTests
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public MainControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetQuestions_ReturnsSuccessAndValidQuestions()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/quiz");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);

            var responseQuestions = JsonSerializer.Deserialize<List<Question>>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Assert.NotNull(responseQuestions);
            Assert.True(responseQuestions.Count > 0);
            Assert.All(responseQuestions, question => Assert.NotNull(question.id));
            Assert.All(responseQuestions, question => Assert.NotNull(question.correctOptionId));
            Assert.All(responseQuestions, question => Assert.True(question.options.Count > 0));
        }

        [Fact]
        public async Task PostAnswers_ReturnsSuccessAndValidResult()
        {
            // Arrange
            var client = _factory.CreateClient();

            List<Answer> answers = new List<Answer> { new Answer { questionId = "1", answerId = "c" }, new Answer { questionId = "4", answerId = "a" } };

            var requestContent = JsonSerializer.Serialize<List<Answer>>(
                answers,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Act
            var response = await client.PostAsync("/quiz", new StringContent(requestContent, Encoding.UTF8, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);

            var responseResult = JsonSerializer.Deserialize<Result>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Assert.NotNull(responseResult);
            Assert.IsType<String>(responseResult.statement);
            Assert.IsType<Double>(responseResult.hitPercentage);
            Assert.Equal(responseResult.hitPercentage, 20);
        }
    }
}