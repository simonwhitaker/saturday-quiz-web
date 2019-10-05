using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaturdayQuizWeb.Model;
using SaturdayQuizWeb.Services;

namespace SaturdayQuizWeb.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        // GET /api/quiz
        [HttpGet]
        public async Task<ActionResult<Quiz>> GetById([FromQuery] string id = null)
        {
            return await _quizService.GetQuiz(id);
        }
    }
}