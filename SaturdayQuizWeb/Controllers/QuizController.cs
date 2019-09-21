using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SaturdayQuizWeb.Model;
using SaturdayQuizWeb.Services;
using SaturdayQuizWeb.Utils;

namespace SaturdayQuizWeb.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        // TODO: inject
        private readonly QuizService _quizService = new QuizService();
        private readonly ConfigVariables _configVariables;

        public QuizController(IConfiguration config)
        {
            _configVariables = new ConfigVariables(config);
        }

        // GET /api/quiz
        [HttpGet]
        public async Task<ActionResult<Quiz>> GetById([FromQuery] string id = null)
        {
            return await _quizService.GetQuiz(_configVariables.GuardianApiKey, id);
        }
    }
}