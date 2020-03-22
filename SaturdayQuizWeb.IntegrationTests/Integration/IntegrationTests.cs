using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using RestSharp;
using SaturdayQuizWeb.Model;
using SaturdayQuizWeb.Services;
using SaturdayQuizWeb.Utils;

namespace SaturdayQuizWeb.IntegrationTests.Integration
{
    [TestFixture]
    public class IntegrationTests
    {
        private readonly IQuizMetadataService _quizMetadataService;
        private readonly IQuizService _quizService;

        public IntegrationTests()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<IntegrationTests>()
                .Build();
            var configVariables = new ConfigVariables(configuration);
            var guardianApiHttpService = new GuardianApiHttpService(
                new RestClient("https://content.guardianapis.com/theguardian/"),
                configVariables);
            _quizMetadataService = new QuizMetadataService(guardianApiHttpService);
            _quizService = new QuizService(
                new GuardianScraperHttpService(new HttpClient()),
                new HtmlService(),
                _quizMetadataService);
        }

        [TestCase(7)]
        public void TestGetQuizMetadata(int numberOfQuizzes)
        {
            var request = _quizMetadataService.GetQuizMetadataAsync(numberOfQuizzes);
            request.Wait();
            Assert.AreEqual(numberOfQuizzes, request.Result.Count);
        }
        
        [TestCase(50)]
        public async Task WhenLastNQuizzesAreLoaded_ThenAllAreSuccessful(int numberOfQuizzes)
        {
            // When
            var quizMetadataList = await _quizMetadataService.GetQuizMetadataAsync(numberOfQuizzes);
            var failedCount = 0;
            // Then
            for (var index = 0; index < numberOfQuizzes; index++)
            {
                var quizMetadata = quizMetadataList[index];
                try
                {
                    var quiz = await _quizService.GetQuizAsync(quizMetadata.Id);
                    Console.WriteLine($"Index {index} successful");
                    PrintQuiz(quiz);
                }
                catch (Exception e)
                {
                    failedCount++;
                    Console.WriteLine($"Index {index} failed: {e.Message} ({quizMetadata.Url})");
                }
            }
            
            Assert.AreEqual(0, failedCount);
        }

        private static void PrintQuiz(Quiz quiz)
        {
            foreach (var q in quiz.Questions)
            {
                Console.WriteLine($"{q.Number}. {q.Type} {q.QuestionText} / {q.AnswerText}");
            }
            Console.WriteLine();
        }
    }
}
