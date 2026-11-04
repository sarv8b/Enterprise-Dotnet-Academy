# Enterprise .NET Developer Academy

A hands-on learning repository for becoming proficient in the enterprise .NET ecosystem.

Learning happens in two places:

- **Standalone exercises** that each focus on one concept.
- **The Workflow Automation Platform (WAP)**, a capstone project that grows in stages: an in-memory console app, then a Web API, then SQL Server persistence, then distributed services, and finally cloud production.

## Documentation

| File | Purpose |
|---|---|
| [ROADMAP.md](ROADMAP.md) | Curriculum: 8 phases, topic IDs (e.g. `P1.6`), and the teaching loop |
| [LEARNING_LOG.md](LEARNING_LOG.md) | Progress: topic status, exercises, mistakes, and the next session plan |
| [PROJECT_SPEC.md](PROJECT_SPEC.md) | Capstone requirements, domain glossary, and milestones `M0`–`M8` |
| [CODING_STANDARDS.md](CODING_STANDARDS.md) | Rules with IDs and levels (MUST / SHOULD / CHOICE) used in code reviews |
| [docs/adr/](docs/adr/) | Architecture Decision Records: one file per design decision |
| [CLAUDE.md](CLAUDE.md) | Instructions for the AI mentor |

## Prerequisites

- [.NET SDK 10.0.114](https://dotnet.microsoft.com/download/dotnet/10.0) or a later 10.0 feature band. The version is pinned in [global.json](global.json) with `rollForward: latestFeature`.
- Git.
- Optional: an editor with C# support (VS Code with C# Dev Kit, Visual Studio, or JetBrains Rider).

Check your SDK:

```bash
dotnet --version   # run from the repository root; it should print 10.0.x
```

## Getting started

Run all commands from the repository root.

```bash
# Restore and build. Warnings are errors, so the build must be clean.
dotnet build

# Run the tests (xUnit v3 on Microsoft.Testing.Platform)
dotnet test

# Check code style against .editorconfig (exits non-zero if anything would change)
dotnet format --verify-no-changes
```

## Repository layout

```
.
├── src/                          # Production code for the Workflow Automation Platform
├── tests/
│   └── WorkflowPlatform.Core.Tests/   # xUnit v3 test project
├── exercises/                    # Standalone exercises: <exercise-id>-<short-name>/ (created as needed)
├── docs/
│   ├── adr/                      # Architecture Decision Records
│   └── diagrams/
├── WorkflowPlatform.slnx         # Solution file (XML .slnx format)
├── global.json                   # Pins the .NET SDK and selects the test runner
├── Directory.Build.props         # Build settings shared by every project
├── Directory.Packages.props      # Central Package Management: one version per NuGet package
└── .editorconfig                 # Code style rules, enforced at build time
```

## Build configuration

Every project gets these settings from [Directory.Build.props](Directory.Build.props), so they are not repeated in each `.csproj`:

- Target framework `net10.0`
- Nullable reference types enabled
- `TreatWarningsAsErrors` set to `true`
- `AnalysisLevel` set to `latest-recommended`, with code style enforced during the build

Package versions are declared once in [Directory.Packages.props](Directory.Packages.props). In a `.csproj`, reference a package **without** a version:

```xml
<PackageReference Include="xunit.v3.mtp-v2" />
```

## Adding a project

```bash
# Production code
dotnet new classlib -o src/WorkflowPlatform.<Name>
dotnet sln WorkflowPlatform.slnx add src/WorkflowPlatform.<Name>

# Tests (one-time setup: dotnet new install xunit.v3.templates)
dotnet new xunit3 -o tests/WorkflowPlatform.<Name>.Tests
dotnet sln WorkflowPlatform.slnx add tests/WorkflowPlatform.<Name>.Tests
```

After you generate a project from a template, delete any `<TargetFramework>`, `<Nullable>`, and package `Version` attributes it adds. Those settings come from the shared props files.

## Workflow

1. Check the **Next session plan** in [LEARNING_LOG.md](LEARNING_LOG.md).
2. Do the exercise on a branch. Name exercises `P{phase}.{topic}-E{n}` (e.g. `P1.3-E2`).
3. Keep `dotnet build`, `dotnet test`, and `dotnet format --verify-no-changes` passing.
4. Ask for a review. Findings cite rule IDs from [CODING_STANDARDS.md](CODING_STANDARDS.md).
5. Record design decisions as ADRs in `docs/adr/`, and record progress in `LEARNING_LOG.md`.
6. Commit with a meaningful message and merge to `main`.

## Current status

Phase 1 (C# and .NET Fundamentals), milestone **M0: Repository foundation**. See [LEARNING_LOG.md](LEARNING_LOG.md) for details.
