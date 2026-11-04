# NuGet Package Upgrade — SixLabors.ImageSharp

## Strategy
Keep SixLabors.ImageSharp on the 4.x line and migrate PdfSharpCore adapter code to its current API.

## Preferences
- **Flow Mode**: Automatic
- **Scope**: Entire solution
- **Package**: SixLabors.ImageSharp
- **Target version**: 4.1.3
- **Target frameworks**: net6.0;net7.0;net8.0;net9.0; net5.0 remains removed
- **Breaking changes**: Adapt source code to ImageSharp 4.x APIs
- **Commit Strategy**: After Each Task

## Decisions
- Retain ImageSharp 4.1.3 despite the assessment's automatically recommended 3.2.0 because the user explicitly requested ImageSharp 4.x.

## Source Control
- **Source Branch**: master
- **Working Branch**: upgrade-nuget-sixlabors-imagesharp
- **Commit Strategy**: After Each Task
- **Branch Sync**: Disabled

## User Preferences
- Prefer newer, safer package versions even if compatibility with older target frameworks is removed.
