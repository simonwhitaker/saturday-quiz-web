using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SaturdayQuizWeb.Model;
using SaturdayQuizWeb.Services;
using SaturdayQuizWeb.Utils;

namespace SaturdayQuizWeb.Controllers
{
    [Route("api/quiz-metadata")]
    [ApiController]
    public class QuizMetadataController : ControllerBase
    {
        private const int DefaultQuizCount = 10;
        
        // TODO: inject
        private readonly QuizMetadataService _service = new QuizMetadataService();
        private readonly ConfigVariables _configVariables;

        public QuizMetadataController(IConfiguration config)
        {
            _configVariables = new ConfigVariables(config);
        }

        [HttpGet]
        public async Task<ActionResult<List<QuizMetadata>>> GetQuizMetadata([FromQuery] int count = DefaultQuizCount)
        {
            return await _service.GetQuizMetadata(_configVariables.GuardianApiKey, count);
        }
    }
}