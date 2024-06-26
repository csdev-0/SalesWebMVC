﻿namespace SalesWebMVC.Controllers
{
    public class GitHubController(GitHubService gitHubService) : Controller
    {
        private readonly GitHubService _gitHubService = gitHubService;

        public async Task<IActionResult> Index(string? username = Configuration.GitHubDefaultUsername)
        {
            if (ModelState.IsValid == false) return BadRequest();

            try
            {
                var gitHubUser = await _gitHubService.GetGitHubUserAsync(username!);

                if (gitHubUser == null) return NotFound();

                return View(gitHubUser);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
