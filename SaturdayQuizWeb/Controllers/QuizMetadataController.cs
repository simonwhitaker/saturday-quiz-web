using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SaturdayQuizWeb.Model;
using SaturdayQuizWeb.Services;

namespace SaturdayQuizWeb.Controllers
{
    [Route("api/quiz-metadata")]
    [ApiController]
    public class QuizMetadataController : ControllerBase
    {
        private const int DefaultQuizCount = 10;
        
        private IConfiguration Configuration { get; }
        
        // TODO: inject
        private readonly QuizMetadataService _service = new QuizMetadataService();

        public QuizMetadataController(IConfiguration config)
        {
            Configuration = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<QuizMetadata>>> GetQuizMetadata([FromQuery] int count = DefaultQuizCount)
        {
            return await _service.GetQuizMetadata(Configuration["GuardianApiKey"], count);
        }
    }
}