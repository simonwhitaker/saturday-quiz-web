using System;
using System.Threading.Tasks;
using RestSharp;
using SaturdayQuizWeb.Model.Api;
using SaturdayQuizWeb.Utils;

namespace SaturdayQuizWeb.Services
{
    public interface IGuardianApiHttpService
    {
        Task<GuardianApiResponse> ListQuizzesAsync(int pageSize = 5);
        Task<GuardianApiResponse> GetQuizByDateAsync(DateTime date);
    }
    
    public class GuardianApiHttpService : IGuardianApiHttpService
    {
        private readonly IRestClient _restClient;
        private readonly IConfigVariables _configVariables;

        public GuardianApiHttpService(IRestClient restClient, IConfigVariables configVariables)
        {
            _restClient = restClient;
            _configVariables = configVariables;
        }

        public async Task<GuardianApiResponse> ListQuizzesAsync(int pageSize = 5)
        {
            var request = new RestRequest("series/the-quiz-thomas-eaton", DataFormat.Json)
                .AddQueryParameter("api-key", _configVariables.GuardianApiKey)
                .AddQueryParameter("page-size", pageSize.ToString());
            var response = await _restClient.ExecuteGetTaskAsync<GuardianApiResponse>(request);
            return response.IsSuccessful ? response.Data : null;
        }

        public async Task<GuardianApiResponse> GetQuizByDateAsync(DateTime date)
        {
            var dateString = date.ToString("yyyy-MM-dd");
            var request = new RestRequest("series/the-quiz-thomas-eaton", DataFormat.Json)
                .AddQueryParameter("api-key", _configVariables.GuardianApiKey)
                .AddQueryParameter("from-date", dateString)
                .AddQueryParameter("to-date", dateString);
            var response = await _restClient.ExecuteGetTaskAsync<GuardianApiResponse>(request);
            return response.IsSuccessful ? response.Data : null;
        }
    }
}