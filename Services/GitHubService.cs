﻿using Newtonsoft.Json;

namespace SalesWebMVC.Services
{
    public class GitHubService
    {
        private readonly HttpClient _httpClient = new();

        public async Task<GitHubUser?> GetGitHubUserAsync(string username)
        {
            var url = $"https://api.github.com/users/{username}";
            _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

            var response = await _httpClient.GetStringAsync(url);
            var gitHubUser = JsonConvert.DeserializeObject<GitHubUser>(response);

            return gitHubUser;
        }
    }
}
