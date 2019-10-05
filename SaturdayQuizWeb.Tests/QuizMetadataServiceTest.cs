using System.Net.Http;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using SaturdayQuizWeb.Api;
using SaturdayQuizWeb.Services;
using SaturdayQuizWeb.Utils;

namespace SaturdayQuizWeb.Tests
{
    public class QuizMetadataServiceTest
    {
        private readonly IQuizMetadataService _quizMetadataService;

        public QuizMetadataServiceTest()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<QuizMetadataServiceTest>()
                .Build();
            var configVariables = new ConfigVariables(configuration);
            var httpClientFactory = new HttpClientFactory();
            var guardianApi = new GuardianApi(httpClientFactory, configVariables);
            _quizMetadataService = new QuizMetadataService(guardianApi);
        }

        [Test]
        [Ignore(Consts.IntegrationTest)]
        public void TestGetQuizMetadata()
        {
            var request = _quizMetadataService.GetQuizMetadata(7);
            request.Wait();
            Assert.AreEqual(7, request.Result.Count);
        }
    }

    internal class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name) => new HttpClient();
    }
}
