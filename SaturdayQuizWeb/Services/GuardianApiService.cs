using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using SaturdayQuizWeb.Model.Api;
using SaturdayQuizWeb.Utils;

namespace SaturdayQuizWeb.Services
{
    public interface IGuardianApiHttpService
    {
        Task<GuardianApiResponse> ListQuizzesAsync(int pageSize = 5);
    }
    
    /// <summary>
    /// A typed HTTP client: see https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-3.0#typed-clients
    /// </summary>
    public class GuardianApiHttpService : IGuardianApiHttpService
    {
        private const string UrlBase = "https://content.guardianapis.com/theguardian/";
        private const string ResourceFormat = "series/the-quiz-thomas-eaton?api-key={0}&page-size={1}";

        private readonly HttpClient _httpClient;
        private readonly IConfigVariables _configVariables;

        public GuardianApiHttpService(HttpClient httpClient, IConfigVariables configVariables)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(UrlBase);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
            _configVariables = configVariables;
        }

        public async Task<GuardianApiResponse> ListQuizzesAsync(int pageSize = 5)
        {
            GuardianApiResponse apiResponse = null;
            var response = await _httpClient.GetAsync(string.Format(
                ResourceFormat,
                _configVariables.GuardianApiKey,
                pageSize));
            if (response.IsSuccessStatusCode)
            {
                apiResponse = await response.Content.ReadAsAsync<GuardianApiResponse>();
            }
            return apiResponse;
        }
    }
}