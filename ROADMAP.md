# Enterprise .NET Developer Academy — Roadmap

> **Learner:** Sarvesh · **Mentor:** Claude (senior .NET engineer / architect / instructor)
> **Created:** 2026-11-03 · **Target platform:** .NET 10 (LTS, supported until Nov 2028) · C# 14
> **Companion files:** `LEARNING_LOG.md` (progress) · `PROJECT_SPEC.md` (capstone project) · `CODING_STANDARDS.md` (rules)

---

## 1. How this roadmap works

This roadmap is **mastery-driven, not calendar-driven**. A topic is finished when it is demonstrated, not when time runs out.

### 1.1 The teaching loop (applied to every topic)

| Step | What happens | Who does it |
|---|---|---|
| 1 | Explain the concept in simple terms, from first principles | Mentor |
| 2 | Explain why enterprise developers use it (and when they don't) | Mentor |
| 3 | Show a small real-world example | Mentor |
| 4 | Give a guided exercise (20–60 minutes) | Mentor |
| 5 | Implement the solution independently | **Sarvesh** |
| 6 | Review the code | Mentor |
| 7 | Explain mistakes and suggest improvements | Mentor |
| 8 | Introduce relevant enterprise best practices | Mentor |
| 9 | Give a slightly harder follow-up exercise | Mentor → **Sarvesh** |
| 10 | Test understanding (predict, debug, explain) before moving on | Mentor → **Sarvesh** |

### 1.2 Ground rules

- **One small concept at a time.** No large code dumps.
- **Hints before solutions.** Hints escalate: nudge → direction → specific pointer → partial code → full solution (only when explicitly requested).
- **Assume experience, teach unfamiliar concepts from first principles.** ~5 years of professional C#/.NET/ASP.NET Core work is the baseline; familiarity does not equal mastery.
- **Trade-offs over dogma.** Every pattern and abstraction must justify its cost.
- **Realistic scenarios.** Exercises use the Workflow Automation Platform domain (see `PROJECT_SPEC.md`) wherever possible.

### 1.3 Definition of "complete"

A topic is marked **MASTERED** in `LEARNING_LOG.md` only when **all** of the following are true:

1. Sarvesh can **explain** the concept in his own words, including at least one trade-off.
2. Sarvesh has **implemented** at least one exercise on the topic **independently** (no full solution revealed).
3. Sarvesh has passed an **understanding check** (prediction, debugging, or design-decision question).

Prior professional experience is not counted until it is demonstrated in this repository.

### 1.4 Practices that run through every phase

These are formally taught in later phases but **practised from day one**:

- **Git** — every exercise and milestone is committed (see `CODING_STANDARDS.md` → Git).
- **Automated tests** — lightweight xUnit tests start in Phase 1; Phase 6 deepens and formalises testing.
- **Code review** — every submission is reviewed against `CODING_STANDARDS.md` with rule IDs.
- **Architecture Decision Records (ADRs)** — every design choice is recorded in `docs/adr/`.

---

## 2. Phase overview

| Phase | Focus | Topics | Project milestone(s) |
|---|---|---|---|
| 1 | C# and .NET Fundamentals | P1.1 – P1.6 | M0 Repository foundation · M1 In-memory console engine |
| 2 | Advanced C# and Runtime | P2.1 – P2.6 | M2 Hosted, async console engine |
| 3 | ASP.NET Core Backend | P3.1 – P3.7 | M3 Web API |
| 4 | Database and Persistence | P4.1 – P4.7 | M4 SQL Server persistence |
| 5 | Enterprise Architecture | P5.1 – P5.7 | M5 Architecture refactor |
| 6 | Testing and Quality | P6.1 – P6.7 | M6 Quality and test hardening |
| 7 | Enterprise Infrastructure | P7.1 – P7.7 | M7 Distributed infrastructure |
| 8 | Cloud and Production Engineering | P8.1 – P8.7 | M8 Production deployment |

Topic IDs (e.g. `P3.4`) are used in `LEARNING_LOG.md` and in exercise IDs (e.g. `P3.4-E1`).

---

## Phase 1: C# and .NET Fundamentals

**Goal:** Rebuild C# fundamentals on solid first principles so that later topics (async, EF Core, architecture) rest on correct mental models.
**Project:** M0 Repository foundation, M1 In-memory console engine.

| ID | Topic | Key concepts |
|---|---|---|
| P1.1 | C# types, classes, structs, records | Value vs reference semantics, stack/heap intuition, equality (reference vs value), immutability, `init`, `required`, `with` expressions |
| P1.2 | OOP, interfaces, inheritance, polymorphism | Encapsulation of invariants, virtual dispatch, abstract vs interface, composition over inheritance, `sealed` |
| P1.3 | Generics, delegates, events, LINQ | Type constraints, variance basics, `Func`/`Action`, closures, event pitfalls, deferred vs immediate execution, `IEnumerable<T>` |
| P1.4 | Exception handling and resource management | Exception hierarchy, when to catch, `throw;` vs `throw ex;`, `finally`, `using`/`using var`, custom domain exceptions |
| P1.5 | Collections and nullable reference types | `List`, `Dictionary`, `HashSet`, `Queue`, complexity trade-offs, read-only interfaces, NRT annotations and flow analysis |
| P1.6 | .NET SDK, CLI, project files, NuGet | `dotnet` CLI, SDK vs runtime, `global.json`, `.csproj` anatomy, `Directory.Build.props`, central package management, solution files |

**Exit criteria — Phase 1**
- [ ] Choose between `class`, `struct`, and `record` for a given domain object and justify the choice.
- [ ] Predict the output of a LINQ query that relies on deferred execution and a captured variable.
- [ ] Design a small type hierarchy and explain why composition might be better.
- [ ] Explain what nullable reference types do and do not guarantee at runtime.
- [ ] Set up a multi-project solution from the CLI with shared build settings.

---

## Phase 2: Advanced C# and Runtime

**Goal:** Understand how .NET actually executes code — asynchrony, threads, memory — and how real applications are composed (DI, configuration, logging).
**Project:** M2 Hosted, async console engine.

| ID | Topic | Key concepts |
|---|---|---|
| P2.1 | Async/await, Task, cancellation tokens | The async state machine, `Task` vs `ValueTask`, sync-over-async deadlocks, `async void`, cooperative cancellation, timeouts |
| P2.2 | Threading, concurrency, synchronization | Thread pool, race conditions, `lock`, `SemaphoreSlim`, `Interlocked`, concurrent collections, `Channel<T>`, `Parallel.ForEachAsync` |
| P2.3 | Memory, garbage collection, IDisposable | Generations, LOH, allocations, finalizers, `IDisposable`/`IAsyncDisposable`, the dispose pattern, intro to `Span<T>` |
| P2.4 | Reflection, attributes, expression trees | Runtime type inspection, custom attributes, expression trees (how EF reads your LINQ), source generators as the modern alternative |
| P2.5 | Dependency injection and configuration | Service lifetimes, captive dependencies, scope validation, keyed services, Generic Host, configuration providers and precedence |
| P2.6 | Logging and application settings | `ILogger<T>`, structured logging, levels, scopes, `[LoggerMessage]` source generation, Options pattern with validation, environments |

**Exit criteria — Phase 2**
- [ ] Explain what happens at each `await`, and why `.Result` can deadlock or starve the thread pool.
- [ ] Find and fix a race condition in a concurrent workflow-step processor.
- [ ] Diagnose a captive-dependency bug from a stack trace or DI validation error.
- [ ] Explain how EF Core can translate a lambda into SQL (expression trees vs delegates).
- [ ] Wire up configuration, Options validation, and structured logging in a Generic Host app.

---

## Phase 3: ASP.NET Core Backend

**Goal:** Build HTTP APIs that are correct, secure, and well-documented, and understand the request pipeline end to end.
**Project:** M3 Web API.

| ID | Topic | Key concepts |
|---|---|---|
| P3.1 | HTTP, REST, status codes | Methods, safety and idempotency, resource modelling, status-code semantics, headers, content negotiation |
| P3.2 | Minimal APIs and Controllers | Hosting model, route groups, `TypedResults`, controllers and `[ApiController]`, choosing between them |
| P3.3 | Middleware and request pipeline | Middleware ordering, short-circuiting, writing custom middleware, `HttpContext` |
| P3.4 | Routing, model binding, validation | Route templates and constraints, binding sources, built-in validation vs FluentValidation, validation error responses |
| P3.5 | Authentication and authorization | Authn vs authz, JWT bearer, claims, roles vs policies, resource-based authorization, `dotnet user-jwts` for local development |
| P3.6 | Filters, exception handling, API versioning | Endpoint/action filters, `IExceptionHandler`, ProblemDetails (RFC 9457), versioning strategies |
| P3.7 | OpenAPI and Swagger | Built-in OpenAPI document generation, Swagger UI / Scalar, documenting responses and errors accurately |

**Exit criteria — Phase 3**
- [ ] Design the HTTP contract for a workflow transition, including every error status code and why.
- [ ] Explain the middleware order in `Program.cs` and predict the effect of reordering.
- [ ] Implement a policy that allows only the assigned approver to approve a task.
- [ ] Return consistent ProblemDetails for validation, domain, concurrency, and unexpected errors.

---

## Phase 4: Database and Persistence

**Goal:** Persist the domain safely and efficiently in SQL Server, and know when EF Core is the right tool and when it is not.
**Project:** M4 SQL Server persistence.

| ID | Topic | Key concepts |
|---|---|---|
| P4.1 | SQL Server, joins, indexes, transactions | Join types, clustered vs non-clustered and covering indexes, execution plans, ACID, isolation levels, locking and deadlocks |
| P4.2 | Entity Framework Core | `DbContext`, change tracking, entity configuration, relationships, owned types/complex types, value conversions |
| P4.3 | Code-first migrations | Creating, reviewing, and reverting migrations, data migrations, idempotent scripts, migration bundles, deployment strategy |
| P4.4 | LINQ to Entities | Query translation, projections, client vs server evaluation, `IQueryable<T>` vs `IEnumerable<T>`, raw SQL in EF |
| P4.5 | Repository patterns and their trade-offs | What `DbContext` already provides, when a repository adds value, leaky abstractions, generic repository anti-patterns |
| P4.6 | Query optimization and N+1 problems | Detecting N+1, eager/explicit loading, split queries, `AsNoTracking`, compiled queries, logging generated SQL |
| P4.7 | Dapper and raw SQL | When to drop to SQL, parameterization, mapping, mixing Dapper and EF in one transaction |

**Exit criteria — Phase 4**
- [ ] Read an execution plan and justify an index for a real workflow query.
- [ ] Explain and demonstrate optimistic concurrency on a workflow instance.
- [ ] Spot and fix an N+1 query from logged SQL output.
- [ ] Argue for or against a repository layer in this project, with trade-offs.

---

## Phase 5: Enterprise Architecture

**Goal:** Structure a growing codebase deliberately, choosing patterns because of real forces, not fashion.
**Project:** M5 Architecture refactor.

| ID | Topic | Key concepts |
|---|---|---|
| P5.1 | SOLID principles | Each principle with a concrete violation and fix; where over-application hurts |
| P5.2 | Design patterns | Strategy, Factory, Decorator, Template Method, State, Specification — applied to workflow steps and actions |
| P5.3 | Clean Architecture | Dependency rule, layers, ports and adapters, cost of indirection, vertical slices as an alternative |
| P5.4 | Domain-Driven Design fundamentals | Ubiquitous language, entities, value objects, aggregates and invariants, domain events, bounded contexts |
| P5.5 | CQRS and MediatR | Separating reads and writes, read models, mediator pattern, pipeline behaviours, hand-rolled vs library (check licensing) |
| P5.6 | Modular monoliths | Module boundaries, module-to-module communication, enforcing boundaries with tests |
| P5.7 | Microservices and distributed systems | When (not) to split, data ownership, eventual consistency, fallacies of distributed computing |

**Exit criteria — Phase 5**
- [ ] Write an ADR choosing an architecture style for this project, with rejected alternatives.
- [ ] Identify the aggregate boundary for a workflow instance and defend it.
- [ ] Explain when CQRS adds value and when it is overhead.
- [ ] Explain why this project should (or should not) become microservices.

---

## Phase 6: Testing and Quality

**Goal:** Build a test suite that gives fast, trustworthy feedback, and keep the codebase maintainable as it grows.
**Project:** M6 Quality and test hardening.

| ID | Topic | Key concepts |
|---|---|---|
| P6.1 | xUnit | Facts, theories, fixtures, lifetimes, parallelisation, xUnit v3 |
| P6.2 | Unit testing and integration testing | Test pyramid/trophy, what to unit test, test doubles, testing domain invariants |
| P6.3 | Mocking with NSubstitute or Moq | Stubs vs mocks, over-mocking, what not to mock |
| P6.4 | WebApplicationFactory | In-memory API testing, overriding services, authentication in tests |
| P6.5 | Testcontainers | Real SQL Server in tests, container lifecycle, database reset strategies |
| P6.6 | Code coverage and static analysis | Coverage as a signal, Roslyn analyzers, `.editorconfig` severity, SonarQube/SonarCloud |
| P6.7 | Refactoring and maintainability | Code smells, safe refactoring under tests, cyclomatic complexity, technical debt |

**Exit criteria — Phase 6**
- [ ] Explain why the EF Core InMemory provider is a poor substitute for SQL Server in integration tests.
- [ ] Write an integration test that proves the concurrency rule on workflow transitions.
- [ ] Refactor a smelly class safely with tests guarding behaviour.

---

## Phase 7: Enterprise Infrastructure

**Goal:** Run the platform as multiple cooperating processes with caching, messaging, resilience, and observability.
**Project:** M7 Distributed infrastructure.

| ID | Topic | Key concepts |
|---|---|---|
| P7.1 | Docker and Docker Compose | Images, multi-stage builds, layers, non-root containers, Compose networks, volumes, health checks |
| P7.2 | Redis caching | Cache-aside, `IDistributedCache`, `HybridCache`, invalidation, stampede protection |
| P7.3 | Background workers | `BackgroundService`, Worker Service template, scoped services in workers, graceful shutdown |
| P7.4 | Message brokers and RabbitMQ | Exchanges, queues, acknowledgements, dead-lettering, idempotent consumers, transactional outbox |
| P7.5 | Kafka fundamentals | Topics, partitions, consumer groups, ordering, when Kafka vs RabbitMQ |
| P7.6 | Resilience and retries | Retries with backoff and jitter, timeouts, circuit breakers, `Microsoft.Extensions.Http.Resilience` (Polly v8) |
| P7.7 | Observability with OpenTelemetry | Traces, metrics, logs, context propagation across HTTP and messaging, Aspire dashboard / Jaeger |

**Exit criteria — Phase 7**
- [ ] Explain the dual-write problem and how the outbox pattern solves it.
- [ ] Make a message consumer idempotent and prove it with a test.
- [ ] Follow one workflow transition across API → broker → worker in a distributed trace.

---

## Phase 8: Cloud and Production Engineering

**Goal:** Ship the platform to the cloud through an automated pipeline and operate it with confidence.
**Project:** M8 Production deployment.

| ID | Topic | Key concepts |
|---|---|---|
| P8.1 | Azure or AWS deployment | Azure Container Apps / App Service + Azure SQL, or AWS ECS + RDS; managed identity; networking basics |
| P8.2 | CI/CD with GitHub Actions | Build/test/publish workflows, container registries, environments and approvals, OIDC to the cloud |
| P8.3 | Secrets management | User secrets, Key Vault / Secrets Manager, managed identity, secret rotation |
| P8.4 | Infrastructure as Code | Bicep or Terraform, environments, drift, state management |
| P8.5 | Application monitoring | Application Insights / Azure Monitor (or CloudWatch), dashboards, alerts, SLOs |
| P8.6 | Security and performance | OWASP API Security Top 10, dependency scanning, load testing (k6), BenchmarkDotNet, profiling |
| P8.7 | System design and scalability | Scaling stateless APIs, database scaling, multi-tenancy options, capacity estimation |

**Exit criteria — Phase 8**
- [ ] A push to `main` builds, tests, and deploys the platform to a cloud environment with no manual steps.
- [ ] No secrets in the repository or pipeline logs; the app authenticates to cloud resources with managed identity/OIDC.
- [ ] Present a system design for scaling the platform to many tenants, with trade-offs.

---

## 3. Optional electives (after or alongside Phase 8)

Only on request; these do not block roadmap completion.

- React admin UI for workflow design and task inboxes
- gRPC and SignalR (real-time task notifications)
- AI features with `Microsoft.Extensions.AI` (e.g. summarising incident reports)
- Advanced performance: `Span<T>`, pooling, Native AOT trade-offs
