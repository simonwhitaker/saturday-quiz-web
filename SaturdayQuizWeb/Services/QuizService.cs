using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SaturdayQuizWeb.Model;

namespace SaturdayQuizWeb.Services
{
    public class QuizService
    {
        private const string GuardianUrlBase = "https://www.theguardian.com/";
        
        // TODO: inject
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly HtmlService _htmlService = new HtmlService();
        private readonly QuizMetadataService _quizMetadataService = new QuizMetadataService();
        
        public async Task<Quiz> GetQuiz(string apiKey, string id = null)
        {
            QuizMetadata quizMetadata;
            
            if (id == null)
            {
                var quizMetadataList = await _quizMetadataService.GetQuizMetadata(apiKey, 1);
                quizMetadata = quizMetadataList.First();
            }
            else
            {
                quizMetadata = new QuizMetadata
                {
                    Id = id
                };
            }

            return await GetQuiz(quizMetadata);
        }

        public async Task<Quiz> GetQuiz(QuizMetadata quizMetadata)
        {
            var quizHtml = await _httpClient.GetStringAsync(GuardianUrlBase + quizMetadata.Id);
            var questions = _htmlService.FindQuestions(quizHtml);
            return new Quiz
            {
                Id = quizMetadata.Id,
                Date = quizMetadata.Date,
                Title = quizMetadata.Title,
                Questions = questions
            };
        }
    }
}