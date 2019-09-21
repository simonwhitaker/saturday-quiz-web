using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using SaturdayQuizWeb.Services;

namespace SaturdayQuizWeb.Tests
{
    public class QuizMetadataServiceTest
    {
        private IConfiguration Configuration { get; }

        private readonly QuizMetadataService _service = new QuizMetadataService();

        public QuizMetadataServiceTest()
        {
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets<QuizMetadataServiceTest>()
                .Build();
        }

        [Test]
        [Ignore(Consts.IntegrationTest)]
        public void TestGetQuizMetadata()
        {
            var request = _service.GetQuizMetadata(Configuration["GuardianApiKey"], 7);
            request.Wait();
            Assert.AreEqual(7, request.Result.Count);
        }
    }
}
