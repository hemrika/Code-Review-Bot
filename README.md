# C# GitHub AI Code Review Bot

A C# console app (scaffold) for a GitHub Pull Request bot that uses AI to review code.  
Integrate with OpenAI or Azure OpenAI for suggestions and comments.

## Features
- Fetches PR info from GitHub
- Sends PR diff to OpenAI for review (stub code)
- Ready to use as a GitHub Action with more work

## How to Use
1. Add your GitHub token and OpenAI API key to `appsettings.json`
2. Build & run: `dotnet run <owner> <repo> <pr_number>`
3. Extend logic for posting review comments!

## Requirements
- .NET 6 SDK
- [Octokit](https://github.com/octokit/octokit.net) NuGet package
- OpenAI API key (for AI suggestions)

## Note
For a full PR workflow, use as a GitHub Action with workflow file. This repo is a demo scaffold.
