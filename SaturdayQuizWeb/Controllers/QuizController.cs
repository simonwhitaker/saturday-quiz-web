using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SaturdayQuizWeb.Model;
using SaturdayQuizWeb.Services;

namespace SaturdayQuizWeb.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        // TODO: inject
        private readonly QuizService _quizService = new QuizService();
        
        private IConfiguration Configuration { get; }

        public QuizController(IConfiguration config)
        {
            Configuration = config;
        }

        // GET /api/quiz
        [HttpGet]
        public async Task<ActionResult<Quiz>> GetById([FromQuery] string id = null)
        {
            return await _quizService.GetQuiz(Configuration["GuardianApiKey"], id);
        }
    }
}