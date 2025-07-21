using System;
using Microsoft.Extensions.Configuration;
using Octokit;

namespace CSGitHubAICodeReview
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: dotnet run <owner> <repo> <pr_number>");
                return;
            }

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
            var githubToken = config["GitHub:Token"];
            var openAIApiKey = config["OpenAI:ApiKey"];

            var owner = args[0];
            var repo = args[1];
            var prNumber = int.Parse(args[2]);

            var github = new GitHubClient(new ProductHeaderValue("AICodeReview"))
            {
                Credentials = new Credentials(githubToken)
            };

            var pr = github.PullRequest.Get(owner, repo, prNumber).Result;
            var files = github.PullRequest.Files(owner, repo, prNumber).Result;

            Console.WriteLine($"PR Title: {pr.Title}");
            foreach (var file in files)
            {
                Console.WriteLine($"Changed file: {file.FileName}");
                // You could call OpenAIService.AnalyzeDiff(file.Patch)
            }

            Console.WriteLine("Send PR file diffs to AI here for suggestions...");
        }
    }
}
