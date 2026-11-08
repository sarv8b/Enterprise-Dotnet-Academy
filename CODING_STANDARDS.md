# Coding Standards — C# and ASP.NET Core

> **Applies to:** everything in this repository (`src/`, `tests/`, `exercises/`)
> **Target:** .NET 10 (LTS) · C# 14 · **Created:** 2026-11-03
> **Related:** `ROADMAP.md` · `LEARNING_LOG.md` · `PROJECT_SPEC.md`

---

## 0. How to read this document

Every rule has an **ID** (e.g. `ASY-2`) and a **level**:

| Level | Meaning | In code review |
|---|---|---|
| **MUST** | Mandatory. Protects correctness, security, or data integrity, or reflects near-universal industry consensus. | A violation blocks the change. Fix before moving on. |
| **SHOULD** | Strong default. Deviate only with a stated reason (code comment or commit message). | Flagged; accepted if the reason is sound. |
| **CHOICE** | A legitimate design decision with real trade-offs. Reasonable teams choose differently. | Never flagged as a "mistake". Must be decided once (ADR in `docs/adr/`) and applied consistently. |

**"Applies from"** on each section shows the milestone (see `PROJECT_SPEC.md`) where the rules become enforceable. Earlier exercises are not penalised for concepts not yet taught, but the mentor may point them out as previews.

### Review conventions

- Every review finding cites the rule ID and level, e.g. *"`ASY-2` (MUST): `.Result` blocks a thread-pool thread…"*.
- Findings are ordered: MUST → SHOULD → CHOICE notes → optional polish.
- CHOICE items are discussed as trade-offs, never as errors, unless they contradict an accepted ADR.
- Reviews explain **why**, not only **what**, and do not rewrite whole exercise solutions (see `ROADMAP.md` §1.2).

---

## 1. Build and project configuration · Applies from M0

| ID | Level | Rule |
|---|---|---|
| BLD-1 | MUST | Target `net10.0` (current LTS, supported until Nov 2028). .NET 8 and .NET 9 reach end of support on 10 Nov 2026 — do not start new code on them. |
| BLD-2 | MUST | Pin the SDK with `global.json` (`rollForward: latestFeature`) so every machine and the CI pipeline build the same way. |
| BLD-3 | MUST | Nullable reference types enabled for every project (`<Nullable>enable</Nullable>`). |
| BLD-4 | MUST | The build has zero warnings. `TreatWarningsAsErrors` is `true` for all projects. |
| BLD-5 | SHOULD | Shared settings live in `Directory.Build.props` (target framework, nullable, warnings, analysis level, `EnforceCodeStyleInBuild`), not repeated in each `.csproj`. |
| BLD-6 | SHOULD | Central Package Management (`Directory.Packages.props`) — one version per package across the solution. |
| BLD-7 | SHOULD | `AnalysisLevel` set to `latest-recommended` (or stricter); new analyzer warnings are fixed, not suppressed. |
| BLD-8 | MUST | Never suppress a warning globally without a comment explaining why. Prefer targeted `#pragma` or `[SuppressMessage(..., Justification = "...")]`. |
| BLD-9 | CHOICE | Solution format: `.slnx` (newer, XML, merge-friendly) vs `.sln` (classic, universal tooling support). |
| BLD-10 | CHOICE | `ImplicitUsings` on (default, less noise) vs off (explicit dependencies per file). Default: on. |
| BLD-11 | MUST | Test projects live under `tests/` and their project name ends in `.Tests` (e.g. `WorkflowPlatform.Core.Tests`). `tests/Directory.Build.props` applies the test settings (`OutputType=Exe`, `IsPackable=false`, `xunit.runner.json`, global `using Xunit`, the `xunit.v3.mtp-v2` package) only to projects with this suffix. A project with any other name, such as `Core.Test` or `Core.Testing`, still builds but gets none of these settings, and nothing warns you. Non-test helpers under `tests/` (shared fixtures, test utilities) deliberately leave off the suffix so they stay plain libraries. |

---

## 2. Naming and formatting · Applies from M0

| ID | Level | Rule |
|---|---|---|
| NAM-1 | MUST | Follow .NET naming conventions: `PascalCase` for types, methods, properties, events, constants, and public fields; `camelCase` for locals and parameters; `_camelCase` for private instance fields; `I` prefix for interfaces; `T` prefix for type parameters (`TKey`, `TResult`). |
| NAM-2 | MUST | `.editorconfig` is the source of truth for style; `dotnet format --verify-no-changes` passes. |
| NAM-3 | SHOULD | Methods returning `Task`/`ValueTask` end in `Async` (exception: ASP.NET Core endpoint handlers and test methods). |
| NAM-4 | SHOULD | One top-level type per file; file name matches type name; namespace matches folder path. |
| NAM-5 | SHOULD | File-scoped namespaces. |
| NAM-6 | SHOULD | Names use the domain language from `PROJECT_SPEC.md` §4 (`WorkflowInstance`, `Transition`, `AuditEntry`), not technical filler (`Manager`, `Helper`, `Data`, `Info`, `Processor2`). |
| NAM-7 | SHOULD | Booleans read as questions: `IsTerminal`, `HasOpenTasks`, `CanTransition`. |
| NAM-8 | CHOICE | `var`: recommended when the type is obvious from the right-hand side; explicit type when it aids reading. |
| NAM-9 | CHOICE | Expression-bodied members for genuine one-liners; block bodies otherwise. |

---

## 3. Type design and language features · Applies from M1

| ID | Level | Rule |
|---|---|---|
| LNG-1 | MUST | Do not silence nullable warnings with `!` (null-forgiving operator) unless you can prove non-null and leave a comment saying why. Fix the design instead. |
| LNG-2 | MUST | Domain objects protect their invariants: no public setters or mutable collections that let callers bypass business rules (`PROJECT_SPEC.md` §5). |
| LNG-3 | MUST | Store and compare timestamps in UTC (`DateTimeOffset` or UTC `DateTime`). Never `DateTime.Now` in business logic. |
| LNG-4 | SHOULD | Obtain the current time through an injected `TimeProvider` so time-dependent logic (escalation, due dates) is testable. |
| LNG-5 | SHOULD | Use `record` for immutable data (DTOs, messages, value objects), `class` for entities with identity and behaviour, `struct` only for small, immutable values where allocation matters. |
| LNG-6 | SHOULD | Classes are `sealed` unless designed for inheritance. |
| LNG-7 | SHOULD | Expose `IReadOnlyList<T>` / `IReadOnlyCollection<T>` from domain objects, not `List<T>`. |
| LNG-8 | SHOULD | Prefer composition over inheritance; inheritance only for genuine "is-a" with shared behaviour. |
| LNG-9 | SHOULD | No magic strings or numbers for domain concepts — use enums, constants, or value objects. |
| LNG-10 | SHOULD | Use `required` and `init` for objects that must be fully initialised at construction. |
| LNG-11 | SHOULD | Prefer pattern matching and `switch` expressions over long `if`/`else` chains when exhaustiveness matters. |
| LNG-12 | CHOICE | Primary constructors for classes with injected dependencies (concise) vs explicit `readonly` fields (parameters captured by primary constructors are mutable and not `readonly`). |
| LNG-13 | CHOICE | Collection expressions (`[]`, `[..items]`) vs explicit constructors. Default: collection expressions. |

---

## 4. Async and concurrency · Applies from M2

| ID | Level | Rule |
|---|---|---|
| ASY-1 | MUST | No `async void` except event handlers. |
| ASY-2 | MUST | No sync-over-async: never `.Result`, `.Wait()`, or `.GetAwaiter().GetResult()` on unfinished tasks in application code. |
| ASY-3 | MUST | Async I/O methods accept a `CancellationToken` (last parameter, named `cancellationToken`) and pass it to every downstream call. |
| ASY-4 | MUST | No unobserved fire-and-forget (`_ = DoWorkAsync();`). Background work goes through a hosted service, queue, or channel that owns errors and shutdown. |
| ASY-5 | MUST | Shared mutable state is protected. No `lock` across `await` (use `SemaphoreSlim`), and prefer immutable data or `Channel<T>` over shared state. |
| ASY-6 | SHOULD | Keep `async`/`await` rather than returning tasks directly (eliding), except in trivial pass-through methods with no `using`/`try`. Eliding changes exception and disposal behaviour. |
| ASY-7 | SHOULD | `Task`/`Task<T>` by default; `ValueTask` only when measurement shows a benefit. |
| ASY-8 | SHOULD | Use `Task.WhenAll` for independent concurrent operations; bound concurrency for large fan-outs (e.g. `Parallel.ForEachAsync` with `MaxDegreeOfParallelism`). |
| ASY-9 | CHOICE | `ConfigureAwait(false)`: unnecessary in ASP.NET Core app code (no synchronization context); recommended in reusable general-purpose libraries. Default here: omit. |

---

## 5. Error handling · Applies from M1 (API parts from M3)

| ID | Level | Rule |
|---|---|---|
| ERR-1 | MUST | Never swallow exceptions (empty `catch`, or `catch` that only returns a default). |
| ERR-2 | MUST | Rethrow with `throw;`, never `throw ex;` (preserves the stack trace). Wrap only when adding context, and keep the inner exception. |
| ERR-3 | MUST | Catch `Exception` broadly only at process boundaries — global exception handler, background-worker loop, message consumer — and always log it. |
| ERR-4 | MUST | Validate arguments at public boundaries with guard helpers (`ArgumentNullException.ThrowIfNull`, `ArgumentException.ThrowIfNullOrWhiteSpace`, `ArgumentOutOfRangeException.ThrowIfNegative`). |
| ERR-5 | MUST | HTTP errors are returned as ProblemDetails (RFC 9457). Stack traces and internal details are never sent to clients outside Development. |
| ERR-6 | SHOULD | Business-rule violations use specific domain exceptions (e.g. an invalid-transition exception), not `Exception` or `InvalidOperationException` with a string message. |
| ERR-7 | SHOULD | Do not use exceptions for normal control flow in hot paths. |
| ERR-8 | CHOICE | Expected business failures as exceptions (simple, idiomatic, but hidden in signatures) vs a `Result<T>` type (explicit, composable, but more ceremony). Decided by ADR at M3. |

---

## 6. Resource management · Applies from M1

| ID | Level | Rule |
|---|---|---|
| RES-1 | MUST | Dispose what you create and own: `using` / `await using` for `IDisposable` / `IAsyncDisposable`. |
| RES-2 | MUST | Do not dispose objects owned by the DI container. |
| RES-3 | MUST | Never create `HttpClient` per request. Use `IHttpClientFactory` (named or typed clients). |
| RES-4 | SHOULD | Implement `IAsyncDisposable` when cleanup involves I/O. Implement finalizers only for unmanaged resources (rare). |

---

## 7. Dependency injection and configuration · Applies from M2

| ID | Level | Rule |
|---|---|---|
| DI-1 | MUST | Constructor injection. No service locator (`IServiceProvider.GetService`) in business code — only in the composition root or factories. |
| DI-2 | MUST | No captive dependencies (a singleton holding a scoped or transient-with-state service). Scope validation (`ValidateScopes`, `ValidateOnBuild`) is enabled in Development and tests. |
| DI-3 | MUST | `DbContext` is scoped. Singletons and background services create a scope or use `IDbContextFactory<T>`. |
| DI-4 | MUST | No secrets in `appsettings*.json` or source control. Locally: user secrets or environment variables. Deployed: Key Vault / secret manager with managed identity. |
| DI-5 | SHOULD | Strongly typed settings via the Options pattern, validated with `ValidateDataAnnotations()`/custom validation and `ValidateOnStart()`. |
| DI-6 | SHOULD | Register services per feature/module through extension methods (`services.AddExecutionModule()`), keeping `Program.cs` readable. |
| DI-7 | CHOICE | Interfaces only where there is a real seam (multiple implementations, external boundary, test substitution) vs an interface for every class. Default: real seams only — an interface with one implementation and no test double is noise. |

---

## 8. Logging and observability · Applies from M2 (OpenTelemetry from M7)

| ID | Level | Rule |
|---|---|---|
| LOG-1 | MUST | Structured message templates with named placeholders: `logger.LogInformation("Instance {InstanceId} moved to {StepName}", id, step)`. Never string interpolation or concatenation in log calls. |
| LOG-2 | MUST | Never log secrets, tokens, passwords, connection strings, or personal data. |
| LOG-3 | MUST | Log every exception you handle at a boundary, with the exception object as the first argument. |
| LOG-4 | SHOULD | Use levels deliberately: `Debug` for diagnostics, `Information` for business events, `Warning` for recoverable anomalies, `Error` for failed operations, `Critical` for app-wide failure. |
| LOG-5 | SHOULD | Include correlation identifiers (trace ID, instance ID) via scopes or OpenTelemetry context. |
| LOG-6 | SHOULD | Emit custom metrics for business signals from M7 (transitions per minute, overdue tasks, queue depth). |
| LOG-7 | CHOICE | `[LoggerMessage]` source-generated logging (faster, compile-time checked, more code) vs direct `Log*` calls. Default: source-generated in hot paths and libraries. |
| LOG-8 | CHOICE | Built-in logging + OpenTelemetry exporters vs Serilog. |

---

## 9. ASP.NET Core APIs · Applies from M3

| ID | Level | Rule |
|---|---|---|
| API-1 | MUST | Use HTTP methods and status codes correctly (see table below). |
| API-2 | MUST | Never expose EF Core entities or domain objects directly. Use request/response DTOs. |
| API-3 | MUST | Validate every request at the boundary; return all validation errors in one ProblemDetails response. |
| API-4 | MUST | Secure by default: a fallback authorization policy requires authenticated users; anonymous endpoints opt out explicitly. |
| API-5 | MUST | Enforce resource-level authorization (can **this** user act on **this** task/instance?). Role checks alone are not enough — broken object-level authorization is the top API security risk. |
| API-6 | MUST | HTTPS only; no sensitive data in URLs or query strings. |
| API-7 | SHOULD | Endpoints are thin: bind, authorise, delegate, map the result. No business logic in endpoint handlers or controllers. |
| API-8 | SHOULD | Collections are paginated with a maximum page size. |
| API-9 | SHOULD | Versioned from `v1`. |
| API-10 | SHOULD | The OpenAPI document is accurate: every success and error response is declared (`TypedResults`/`Produces`). |
| API-11 | SHOULD | Pass `CancellationToken` (request aborted) to handlers' downstream calls. |
| API-12 | SHOULD | From M7: commands that may be retried support idempotency (e.g. an `Idempotency-Key` header). |
| API-13 | CHOICE | Minimal APIs (less ceremony, endpoint-focused) vs Controllers (conventions, filters, familiar structure). ADR at M3. |
| API-14 | CHOICE | Built-in validation vs FluentValidation. ADR at M3. |
| API-15 | CHOICE | Manual mapping (explicit, no magic) vs a source-generated mapper vs a reflection-based mapper. Default: manual mapping. |

**Status code guide**

| Situation | Status |
|---|---|
| Read succeeded | `200 OK` |
| Resource created | `201 Created` + `Location` header |
| Command succeeded, nothing to return | `204 No Content` |
| Malformed request or failed validation | `400 Bad Request` (ProblemDetails with errors) |
| Not authenticated | `401 Unauthorized` |
| Authenticated but not allowed | `403 Forbidden` |
| Resource not found (or hidden for security) | `404 Not Found` |
| State conflict: invalid transition for current state, concurrency conflict | `409 Conflict` |
| Unexpected server failure | `500 Internal Server Error` (generic ProblemDetails) |

Using `422 Unprocessable Entity` for semantic validation failures instead of `400` is a CHOICE; record it in the validation ADR if adopted.

---

## 10. Data access with EF Core and SQL Server · Applies from M4

| ID | Level | Rule |
|---|---|---|
| DAT-1 | MUST | Parameterized SQL only. `FromSql`/`SqlQuery` with interpolation (parameterized) is fine; building SQL by string concatenation with input is forbidden. Same for Dapper. |
| DAT-2 | MUST | Migrations are generated, **reviewed**, and committed. Never edit a migration that has been applied to a shared environment — add a new one. |
| DAT-3 | MUST | Do not mix `EnsureCreated()` with migrations. |
| DAT-4 | MUST | Use async EF Core APIs in request paths and pass the `CancellationToken`. |
| DAT-5 | MUST | Workflow instances use an optimistic concurrency token (`rowversion`) — enforces BR-09. |
| DAT-6 | MUST | Multi-step state changes (transition + audit entry + outbox message) are saved in one transaction. |
| DAT-7 | SHOULD | Read-only queries use `AsNoTracking()` and project to DTOs with `Select`. |
| DAT-8 | SHOULD | Lazy loading stays off (it hides N+1 queries). Load related data explicitly. |
| DAT-9 | SHOULD | Entity configuration in `IEntityTypeConfiguration<T>` classes, keeping domain classes free of persistence attributes. |
| DAT-10 | SHOULD | Explicit string lengths, decimal precision, and indexes for foreign keys and frequent filters. |
| DAT-11 | SHOULD | Production schema changes are applied by a pipeline step (idempotent script or migration bundle), not by `Database.Migrate()` at app startup. |
| DAT-12 | SHOULD | Log generated SQL in Development and review it for new queries. |
| DAT-13 | CHOICE | Repository abstraction over EF Core vs using `DbContext` directly in handlers. ADR at M4. |
| DAT-14 | CHOICE | EF Core vs Dapper per query. Default: EF Core for writes and typical reads; Dapper for reporting or performance-critical reads. |

---

## 11. Testing · Applies from M1 (integration tests from M6)

| ID | Level | Rule |
|---|---|---|
| TST-1 | MUST | Every business rule (`PROJECT_SPEC.md` §5) has at least one test. Every bug fix comes with a regression test. |
| TST-2 | MUST | Tests are independent and deterministic: no reliance on execution order, real time (use `FakeTimeProvider`), random values without a seed, or shared mutable state. |
| TST-3 | MUST | No `Thread.Sleep`/`Task.Delay` waits to "make tests pass". |
| TST-4 | MUST | `main` never has failing or skipped-without-reason tests. |
| TST-5 | SHOULD | One behaviour per test, clear Arrange / Act / Assert sections. |
| TST-6 | SHOULD | Database integration tests run against real SQL Server (Testcontainers), not the EF Core InMemory provider, which does not behave like a relational database (no real transactions, constraints, or SQL translation). |
| TST-7 | SHOULD | Mock only at boundaries you do not own or cannot run cheaply (email, external HTTP). Do not mock `DbContext`, domain objects, or the code under test. |
| TST-8 | SHOULD | Coverage is a signal, not a goal. Track it for `Core`/domain code; review uncovered business logic rather than chasing a number. |
| TST-9 | CHOICE | Test naming convention: `Method_Scenario_ExpectedResult` vs `Should_..._When_...` vs sentence-style. Pick one per ADR; default `Method_Scenario_ExpectedResult`. |
| TST-10 | CHOICE | NSubstitute vs Moq. |
| TST-11 | CHOICE | Assertions: xUnit `Assert` vs an assertion library (Shouldly, AwesomeAssertions). Note that FluentAssertions v8+ uses a commercial licence. |

---

## 12. Security · Applies from M3

| ID | Level | Rule |
|---|---|---|
| SEC-1 | MUST | No secrets, keys, tokens, or connection strings with passwords in Git history. If one is committed, rotate it — deleting the commit is not enough. |
| SEC-2 | MUST | Keep NuGet vulnerability auditing enabled; vulnerable packages are upgraded before merging. |
| SEC-3 | MUST | Check the licence of every new third-party package. Several popular .NET libraries (e.g. MediatR, AutoMapper, MassTransit, FluentAssertions) moved to commercial licensing in 2024–2025; verify current terms before adopting. |
| SEC-4 | MUST | Authorization is checked on the server for every operation; never trust client-supplied user IDs or roles. |
| SEC-5 | SHOULD | Review new endpoints against the OWASP API Security Top 10. |
| SEC-6 | SHOULD | Least privilege for database users and cloud identities. |

---

## 13. Git and workflow · Applies from M0

| ID | Level | Rule |
|---|---|---|
| GIT-1 | MUST | `main` always builds and all tests pass. |
| GIT-2 | MUST | Never commit build output (`bin/`, `obj/`), IDE user files, or secrets. |
| GIT-3 | SHOULD | Small, focused commits with messages that explain intent ("Enforce segregation of duties on approval steps"), not mechanics ("fix", "changes"). |
| GIT-4 | SHOULD | One branch per exercise or milestone feature; self-review the diff against the checklist in §15 before merging. |
| GIT-5 | CHOICE | Commit message convention: Conventional Commits (`feat:`, `fix:`, `refactor:`) vs free-form. Default: Conventional Commits. |
| GIT-6 | CHOICE | Merge strategy: squash vs merge commits vs rebase. Default: squash for exercise branches. |

---

## 14. Documentation · Applies from M0

| ID | Level | Rule |
|---|---|---|
| DOC-1 | MUST | `README.md` always explains how to build, test, and run the current milestone. |
| DOC-2 | SHOULD | Every CHOICE decision is recorded as an ADR in `docs/adr/` (template in `PROJECT_SPEC.md` §12). |
| DOC-3 | SHOULD | Comments explain **why** (constraints, trade-offs, non-obvious decisions), not **what** the code already says. |
| DOC-4 | CHOICE | XML doc comments on all public APIs vs only on shared/library APIs. Default: shared library and API surface only. |

---

## 15. Pre-merge self-review checklist

- [ ] Builds with zero warnings; `dotnet format --verify-no-changes` passes.
- [ ] All tests pass; new behaviour and business rules have tests.
- [ ] No sync-over-async; cancellation tokens passed through I/O.
- [ ] No swallowed exceptions; boundary errors are logged and returned as ProblemDetails.
- [ ] Logs are structured and contain no secrets or personal data.
- [ ] No entities in API contracts; input validated; authorization checks the specific resource.
- [ ] New queries reviewed in SQL logs; no N+1; read paths untracked.
- [ ] No secrets committed; new packages licence-checked and vulnerability-free.
- [ ] Any new CHOICE decision has an ADR.
- [ ] `README.md` and `LEARNING_LOG.md` updated if relevant.

---

## 16. Design choices register

| Decision | Options | Current default | Decide at |
|---|---|---|---|
| Solution format | `.slnx` / `.sln` | `.slnx` | M0 |
| Endpoint style | Minimal APIs / Controllers | — | M3 (ADR) |
| Validation | Built-in / FluentValidation | — | M3 (ADR) |
| Expected failures | Exceptions / `Result<T>` | — | M3 (ADR) |
| Mapping | Manual / source-generated / reflection-based | Manual | M3 |
| Data access | Repository / direct `DbContext` | — | M4 (ADR) |
| Architecture style | Clean Architecture / vertical slices / hybrid | — | M5 (ADR) |
| Mediator | Library / hand-rolled / none | — | M5 (ADR) |
| Mocking | NSubstitute / Moq | — | First use (ADR) |
| Assertions | xUnit `Assert` / Shouldly / AwesomeAssertions | xUnit `Assert` | M1 |
| Logging | Built-in + OpenTelemetry / Serilog | Built-in | M2 |
| Messaging library | Raw client / framework | — | M7 (ADR) |
| Cloud | Azure / AWS | Azure | M8 (ADR) |
| IaC | Bicep / Terraform | — | M8 (ADR) |
