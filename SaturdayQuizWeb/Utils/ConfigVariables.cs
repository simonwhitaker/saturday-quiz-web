using System;
using Microsoft.Extensions.Configuration;

namespace SaturdayQuizWeb.Utils
{
    public class ConfigVariables
    {
        private static class Keys
        {
            public const string GuardianApiKey = "GuardianApiKey";
        }
        
        private readonly IConfiguration _configuration;

        public ConfigVariables(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GuardianApiKey => _configuration[Keys.GuardianApiKey] ?? Environment.GetEnvironmentVariable(Keys.GuardianApiKey);
    }
}