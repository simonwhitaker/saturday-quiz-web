using SaturdayQuizWeb.Api;
using SaturdayQuizWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaturdayQuizWeb.Services
{
    public class QuizMetadataService
    {
        private readonly GuardianApi _guardianApi = new GuardianApi();

        public async Task<List<QuizMetadata>> GetQuizMetadata(string apiKey, int count)
        {
            var response = await _guardianApi.ListQuizzes(apiKey, count);

            if (response == null)
            {
                throw new Exception("Something went wrong with the Guardian API call");
            }

            return response.Results
                .Select(item => new QuizMetadata
                {
                    Id = item.Id,
                    Title = item.WebTitle,
                    Date = item.WebPublicationDate,
                    Url = item.WebUrl
                })
                .ToList();
        }
    }
}
