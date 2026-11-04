dotnet clean -c Debug

$repositoryUrl = "https://github.com/$env:GITHUB_REPOSITORY"

# Building for a specific framework.
dotnet build -c Debug /p:RepositoryUrl=$repositoryUrl