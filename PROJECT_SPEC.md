# Project Specification — Workflow Automation Platform

> **Owner:** Sarvesh · **Spec version:** 1.0 · **Created:** 2026-11-03
> **Stack:** .NET 10 (LTS) · C# 14 · ASP.NET Core · Entity Framework Core · SQL Server
> **Related:** `ROADMAP.md` · `LEARNING_LOG.md` · `CODING_STANDARDS.md`

---

## 1. Purpose

The Workflow Automation Platform (WAP) is the **capstone learning project** of the academy. Every roadmap phase lands here as a milestone, so concepts are practised in one realistic, growing codebase instead of isolated textbook snippets.

The project deliberately **evolves gradually**:

```
Console app (in-memory) → Hosted async console → Web API → SQL Server persistence
→ Deliberate architecture → Hardened test suite → Distributed services → Cloud production
```

Each stage is a working product. Each change is motivated by a real limitation of the previous stage, never by "because enterprises do it".

### Learning-project rules

- The spec states **requirements and acceptance criteria**, not implementations. Designing classes, schemas, and contracts is part of the exercises.
- Exercises from `ROADMAP.md` may be done standalone in `exercises/` first, then applied to the project.
- Every design choice marked **CHOICE** in `CODING_STANDARDS.md` is decided in an ADR (`docs/adr/`) at the milestone where it first matters.

---

## 2. Product vision

Organisations run many repeatable, multi-step business processes: reporting and investigating incidents, approving expenses, onboarding employees. These processes are often run through email and spreadsheets, so work gets stuck, approvals are bypassed, and nobody can prove who did what.

WAP lets an organisation:

1. **Define** workflows as steps and allowed transitions.
2. **Run** instances of those workflows.
3. **Assign** human tasks (reviews, approvals) to people or roles.
4. **Automate** steps (send notifications, call webhooks, escalate overdue tasks).
5. **Audit** every action: who did what, when, and why.

---

## 3. Reference workflows

These three workflows are used throughout exercises and tests. They grow in complexity with the milestones.

### 3.1 Incident Management (primary, from M1)

```
Reported → Triage → Investigation → Corrective Action → Approval → Closed
              │                                            │
              └──→ Rejected (not an incident)              └──→ back to Corrective Action (changes requested)
```

- Anyone can report an incident; a safety officer triages it.
- Investigation and corrective action are assigned to named users.
- Approval must be done by someone other than the person who completed the corrective action.
- High-severity incidents notify a manager automatically (from M2).

### 3.2 Expense Approval (conditional routing, from M2/M3)

- Submitted → Manager Approval → (amount > ₹50,000 ? Finance Approval : skip) → Paid / Rejected.
- Introduces **conditions** on transitions.

### 3.3 Employee Onboarding (parallel work, from M5/M7)

- IT setup, HR paperwork, and facilities access happen **in parallel**; the workflow completes when all three are done.
- Introduces **parallel branches** and **join** semantics. Stretch goal; not required before M5.

---

## 4. Domain glossary (ubiquitous language)

| Term | Meaning |
|---|---|
| **Workflow Definition** | A named template describing steps and allowed transitions (e.g. "Incident Management") |
| **Definition Version** | An immutable, published snapshot of a definition. Editing creates a new version. |
| **Step** | A node in a definition. Kinds: *Start*, *Manual Task*, *Approval*, *Automated Action*, *Decision*, *End* |
| **Transition** | An allowed, named move from one step to another (e.g. `approve`, `request-changes`), optionally with a condition |
| **Workflow Instance** | One running execution of a definition version (e.g. "Incident #1042") |
| **Task** | A unit of human work created when an instance reaches a Manual Task or Approval step |
| **Assignee** | The user or role responsible for a task |
| **Action** | An automated operation run by an Automated Action step (notify, call webhook, escalate) |
| **Trigger** | What starts an instance: manual start, API call, schedule, or external event |
| **Audit Entry** | An immutable record of a state change: actor, action, from/to step, timestamp (UTC), comment |
| **Outcome** | Terminal state of an instance: *Completed*, *Rejected*, *Cancelled*, *Failed* |

Use these exact names in code, tests, API routes, and database objects.

---

## 5. Business rules (invariants)

These rules hold in **every** milestone. Each must be covered by at least one automated test (see `CODING_STANDARDS.md` → TST-1).

| ID | Rule |
|---|---|
| BR-01 | A definition has exactly one *Start* step and at least one *End* step. |
| BR-02 | Every step except *End* steps has at least one outgoing transition; every step is reachable from *Start*. |
| BR-03 | A published definition version is immutable. Changes produce a new version. |
| BR-04 | A running instance stays on the definition version it started with. |
| BR-05 | An instance can move only along a transition defined from its current step. |
| BR-06 | Only the assignee of the current task (or an authorised administrator) may complete it. |
| BR-07 | Segregation of duties: the approver of an *Approval* step must not be the person who completed the step being approved. |
| BR-08 | Every state change creates an audit entry with actor, timestamp (UTC), from-step, to-step, and optional comment. Audit entries are never updated or deleted. |
| BR-09 | Two concurrent transitions on the same instance must not both succeed (from M4 enforced in the database). |
| BR-10 | Once an instance reaches a terminal outcome, no further transitions are allowed. |
| BR-11 | Automated actions may be retried; they must be idempotent (running twice must not produce two notifications or two webhook effects). Enforced from M7. |
| BR-12 | Overdue tasks (past their due time) are escalated according to the step's escalation setting (from M2). |

---

## 6. Milestones

Each milestone has: **roadmap phase**, **goal**, **scope**, **concepts practised**, **done when**, and **out of scope**. A milestone is complete only when every "Done when" item is met and committed.

### M0 — Repository foundation

- **Phase:** 1 (P1.6)
- **Goal:** A clean, reproducible repository that builds and tests from one command.
- **Scope:** Solution file; `src/` and `tests/` folders; pinned SDK; shared build properties; central package management; `.editorconfig`; `.gitignore`; `README.md`; `docs/adr/` with ADR template; empty test project that runs.
- **Concepts:** .NET CLI, SDK vs runtime, project files, NuGet, Git basics.
- **Done when:**
  - [ ] `dotnet build` and `dotnet test` pass from the root with zero warnings.
  - [ ] Nullable and warnings-as-errors apply to all projects from one place.
  - [ ] `docs/adr/0001-record-architecture-decisions.md` exists.
- **Out of scope:** Any domain code.

### M1 — In-memory console engine

- **Phase:** 1 (P1.1 – P1.5)
- **Goal:** Model the Incident Management workflow and run it end to end from a console app, with all state in memory.
- **Scope:**
  - Projects: `WorkflowPlatform.Core` (class library), `WorkflowPlatform.Console` (console app), `WorkflowPlatform.Core.Tests` (xUnit).
  - Define a workflow in code; validate it against BR-01/BR-02.
  - Start an instance; list available transitions; perform a transition; print the audit history.
  - Simple console menu (no external CLI libraries).
- **Concepts:** Records vs classes, encapsulating invariants, interfaces, generics, LINQ over in-memory collections, custom exceptions, nullable reference types, read-only collections.
- **Done when:**
  - [ ] Incident Management runs from *Reported* to *Closed* and to *Rejected* via the console.
  - [ ] BR-01, BR-02, BR-05, BR-07, BR-08, BR-10 are enforced and unit-tested.
  - [ ] Invalid operations raise meaningful domain exceptions, not generic ones.
  - [ ] Domain objects cannot be put into an invalid state from outside (no public setters that bypass rules).
- **Out of scope:** Persistence, async, DI container, logging framework.

### M2 — Hosted, async console engine

- **Phase:** 2 (P2.1 – P2.6)
- **Goal:** Turn the console into a properly composed application that executes automated steps asynchronously and concurrently.
- **Scope:**
  - Generic Host with DI, configuration (`appsettings.json` + environment variables), Options validation, structured logging.
  - Automated action steps (simulated *Send Notification* and *Call Webhook*) executed asynchronously with cancellation and timeouts.
  - A background processor that handles queued steps for many instances concurrently (e.g. `Channel<T>`), with graceful shutdown on Ctrl+C.
  - Escalation of overdue tasks (BR-12) using an injectable clock (`TimeProvider`).
  - Save/load state to a JSON file (async I/O, proper disposal).
  - Action discovery via a custom attribute and reflection; compare with a source-generator approach in discussion.
  - Add Expense Approval workflow with conditional routing.
- **Concepts:** async/await, cancellation, concurrency and synchronisation, disposal, reflection and attributes, DI lifetimes, configuration, logging.
- **Done when:**
  - [ ] 100 instances can be processed concurrently with no lost or duplicated transitions (proved by a test).
  - [ ] Ctrl+C stops processing gracefully without corrupting the state file.
  - [ ] Escalation is unit-tested with a fake clock (no `Thread.Sleep`/real waiting in tests).
  - [ ] DI scope validation is on and passes.
- **Out of scope:** HTTP, database.

### M3 — Web API

- **Phase:** 3 (P3.1 – P3.7)
- **Goal:** Expose the engine over a secure, documented HTTP API.
- **Scope:**
  - New project `WorkflowPlatform.Api` (ASP.NET Core). Storage remains in-memory/JSON behind an abstraction, so HTTP is learned without database noise.
  - Capabilities (final routes and contracts are designed by you as an exercise):

    | Capability | Who |
    |---|---|
    | Create, edit, publish, and list workflow definitions | Administrator |
    | Start a workflow instance | Requester |
    | View an instance, its current step, and its history | Participants, Administrator |
    | Perform a transition (with comment) | Current assignee |
    | List my open tasks (paged, filterable) | Any authenticated user |

  - Authentication with JWT bearer (local tokens via `dotnet user-jwts`); roles *Administrator*, *Requester*, *Approver*; resource-based authorization for BR-06/BR-07.
  - Validation, ProblemDetails for all errors, global exception handling, API versioning (`v1`), OpenAPI document with a UI.
- **Concepts:** HTTP semantics, Minimal APIs vs Controllers, middleware, routing, binding, validation, authn/authz, filters, versioning, OpenAPI.
- **Done when:**
  - [ ] Both reference workflows can be driven entirely through the API.
  - [ ] Every endpoint documents its success and error responses in OpenAPI.
  - [ ] Unauthorised users cannot act on tasks they are not assigned (tested).
  - [ ] ADRs exist for: Minimal APIs vs Controllers; validation approach; error-handling approach (exceptions vs results).
- **Out of scope:** Database, UI.

### M4 — SQL Server persistence

- **Phase:** 4 (P4.1 – P4.7)
- **Goal:** Replace in-memory/JSON storage with SQL Server via EF Core, safely and efficiently.
- **Scope:**
  - SQL Server for local development (Docker container or Developer edition — container use is kept minimal until Phase 7).
  - EF Core model, entity configurations, code-first migrations (reviewed and committed).
  - Optimistic concurrency on workflow instances (BR-09).
  - A transition and its audit entry are saved atomically.
  - Indexes designed for real queries (e.g. "my open tasks", "overdue tasks").
  - A reporting endpoint using Dapper (e.g. average time per step per definition over a date range).
  - An N+1 problem is deliberately reproduced, measured from logged SQL, and fixed.
- **Concepts:** SQL, indexes, transactions, EF Core, migrations, LINQ to Entities, repository trade-offs, query optimisation, Dapper.
- **Done when:**
  - [ ] Database can be created from scratch by applying migrations only.
  - [ ] Concurrent transition attempts on one instance produce exactly one success and one `409 Conflict`.
  - [ ] Read-only queries project to DTOs and do not track entities.
  - [ ] ADR exists for: repository abstraction vs direct `DbContext`.
- **Out of scope:** Caching, messaging, cloud database.

### M5 — Architecture refactor

- **Phase:** 5 (P5.1 – P5.7)
- **Goal:** Restructure the codebase deliberately, now that real pain points exist.
- **Scope:**
  - Identify current pain points first (coupling, testability, unclear boundaries) and write them down.
  - Evaluate Clean Architecture layering vs vertical slices vs a hybrid; decide in an ADR.
  - Model the workflow instance as an aggregate; introduce value objects and domain events where they earn their keep.
  - Separate commands and queries; decide on a mediator library vs a hand-rolled approach (check licensing).
  - Organise as a modular monolith: *Definitions*, *Execution*, *Notifications* modules with enforced boundaries.
  - Optional: Employee Onboarding with parallel branches.
- **Concepts:** SOLID, design patterns, Clean Architecture, DDD, CQRS, modular monolith, microservice trade-offs.
- **Done when:**
  - [ ] All existing tests still pass after the refactor (behaviour preserved).
  - [ ] Module boundaries are enforced by an automated architecture test.
  - [ ] A short written analysis explains why the platform is **not** (yet) split into microservices, or what would change that.
- **Out of scope:** Actually splitting into separate deployable services.

### M6 — Quality and test hardening

- **Phase:** 6 (P6.1 – P6.7)
- **Goal:** A fast, trustworthy test suite and a codebase that stays healthy.
- **Scope:**
  - Review and improve existing unit tests (naming, structure, over-mocking).
  - API integration tests with `WebApplicationFactory`.
  - Database integration tests against real SQL Server via Testcontainers.
  - Coverage reporting; analyzers at agreed severity; static analysis (e.g. SonarCloud) optional.
  - Refactor the three most complex classes (by measured complexity) under test.
- **Concepts:** xUnit, unit vs integration testing, mocking, WebApplicationFactory, Testcontainers, coverage, static analysis, refactoring.
- **Done when:**
  - [ ] Every business rule in §5 has at least one test that would fail if the rule were removed.
  - [ ] The concurrency rule (BR-09) is proved by an integration test against real SQL Server.
  - [ ] Full test suite runs with one command; unit tests finish in seconds.
- **Out of scope:** CI pipeline (M8).

### M7 — Distributed infrastructure

- **Phase:** 7 (P7.1 – P7.7)
- **Goal:** Run the platform as cooperating processes with caching, messaging, resilience, and observability.
- **Scope:**
  - Dockerfiles (multi-stage, non-root) for API and a new `WorkflowPlatform.Worker`.
  - Docker Compose: API, Worker, SQL Server, Redis, RabbitMQ, observability backend.
  - Transactional outbox: domain events saved with the state change, then published to RabbitMQ.
  - Worker consumes events and runs automated actions; consumers are idempotent (BR-11); dead-letter handling.
  - Redis caching for published definition versions (safe because they are immutable — BR-03).
  - Resilience (retry with backoff, timeout, circuit breaker) around the webhook action.
  - OpenTelemetry traces, metrics, and logs across API → broker → worker.
  - Kafka: a comparison exercise (e.g. streaming audit entries), not a replacement for RabbitMQ.
- **Concepts:** Docker, Compose, Redis, background workers, messaging, outbox, idempotency, Kafka basics, resilience, observability.
- **Done when:**
  - [ ] `docker compose up` starts the whole platform from a clean machine.
  - [ ] Killing the worker mid-processing loses no events and duplicates no side effects.
  - [ ] One transition is visible as a single distributed trace across all services.
- **Out of scope:** Cloud deployment, Kubernetes.

### M8 — Production deployment

- **Phase:** 8 (P8.1 – P8.7)
- **Goal:** Ship to the cloud through an automated pipeline and operate it with confidence.
- **Scope:**
  - GitHub Actions: build, test (including Testcontainers), publish images, deploy to staging, manual approval for production.
  - Cloud: Azure (Container Apps + Azure SQL + Key Vault + Application Insights) by default; AWS equivalent allowed via ADR.
  - Secrets via managed identity / OIDC; no long-lived credentials in the pipeline.
  - Infrastructure as Code (Bicep or Terraform — ADR).
  - Dashboards and alerts for error rate, latency, queue depth, and overdue tasks.
  - Security review against OWASP API Security Top 10; dependency vulnerability scanning.
  - Load test of the transition endpoint; system design document for multi-tenant scale.
- **Concepts:** Cloud deployment, CI/CD, secrets, IaC, monitoring, security, performance, system design.
- **Done when:**
  - [ ] Merging to `main` deploys to staging automatically; production requires approval.
  - [ ] An environment can be recreated from IaC alone.
  - [ ] An alert fires in a test when the error rate crosses its threshold.
  - [ ] Cloud resources can be torn down with one command (cost control).
- **Out of scope:** Multi-region active-active (discussion only).

---

## 7. Architecture evolution

| Milestone | Shape |
|---|---|
| M1 | `Console` → `Core` (single library, in-memory) |
| M2 | Generic Host console → `Core` + background processor + JSON file store |
| M3 | `Api` → `Core` (in-memory/JSON store behind an abstraction) |
| M4 | `Api` → `Core` → EF Core → SQL Server (+ Dapper for reporting) |
| M5 | Modular monolith: `Api` → modules (*Definitions*, *Execution*, *Notifications*), structure per ADR |
| M7 | `Api` + `Worker` ↔ RabbitMQ; SQL Server; Redis; OpenTelemetry |
| M8 | Same, hosted in the cloud, deployed by CI/CD, provisioned by IaC |

Project names above are indicative; final structure from M5 onwards is decided by ADR.

---

## 8. Repository layout

```
/
├── ROADMAP.md
├── LEARNING_LOG.md
├── PROJECT_SPEC.md
├── CODING_STANDARDS.md
├── README.md                    # how to build, test, run (kept current every milestone)
├── global.json
├── Directory.Build.props
├── Directory.Packages.props
├── .editorconfig
├── .gitignore
├── WorkflowPlatform.slnx        # or .sln
├── docs/
│   ├── adr/                     # 0001-record-architecture-decisions.md, ...
│   └── diagrams/
├── exercises/                   # standalone roadmap exercises: P1.1-E1-value-vs-reference/, ...
├── src/
│   └── WorkflowPlatform.*       # grows per milestone
├── tests/
│   └── WorkflowPlatform.*.Tests
└── deploy/                      # from M7: docker-compose, from M8: IaC
```

---

## 9. Non-functional requirements (introduced progressively)

| NFR | Requirement | From |
|---|---|---|
| Correctness | All business rules in §5 enforced and tested | M1 |
| Auditability | Complete, immutable audit trail with UTC timestamps | M1 |
| Responsiveness | Long-running actions never block a request or the console UI | M2 |
| Configurability | No hard-coded environment-specific values | M2 |
| Security | Authenticated by default; least privilege; no secrets in source | M3 |
| Data integrity | Atomic state change + audit; optimistic concurrency | M4 |
| Performance | "My open tasks" p95 < 200 ms at 100k instances (local, measured) | M4 |
| Testability | Every external dependency replaceable in tests | M6 |
| Reliability | No lost events; idempotent side effects; graceful shutdown | M7 |
| Observability | Traces, metrics, structured logs with correlation | M7 |
| Operability | Automated deploy, alerts, reproducible environments | M8 |

---

## 10. Technology decisions

| Area | Decision | Status |
|---|---|---|
| Runtime | .NET 10 LTS, C# 14 | **Decided** |
| Backend | ASP.NET Core Web API | **Decided** |
| Database | SQL Server | **Decided** |
| ORM | EF Core (Dapper for selected read/reporting queries) | **Decided** |
| Test framework | xUnit (v3) | **Decided** |
| Source control | Git (GitHub) | **Decided** |
| Endpoint style | Minimal APIs vs Controllers | ADR at M3 |
| Validation | Built-in validation vs FluentValidation | ADR at M3 |
| Error handling | Exceptions vs Result types for expected failures | ADR at M3 |
| Data access | Repository abstraction vs direct `DbContext` | ADR at M4 |
| Architecture style | Clean Architecture vs vertical slices vs hybrid | ADR at M5 |
| Mediator | Library vs hand-rolled vs none | ADR at M5 |
| Mocking library | NSubstitute vs Moq | ADR at M6 (or earlier when first needed) |
| Messaging library | Raw client vs a framework (check licensing) | ADR at M7 |
| Cloud | Azure (default) vs AWS | ADR at M8 |
| IaC | Bicep vs Terraform | ADR at M8 |

---

## 11. Out of scope (whole project)

- Visual workflow designer and front-end UI (optional elective; see `ROADMAP.md` §3).
- BPMN 2.0 compliance or import/export.
- Real email/SMS delivery providers (simulated or a local test SMTP server is enough).
- Multi-region active-active deployment (design discussion only in M8).

---

## 12. ADR template

`docs/adr/NNNN-short-title.md`:

```markdown
# NNNN. Title

- Status: Proposed | Accepted | Superseded by NNNN
- Date: YYYY-MM-DD
- Milestone: Mx

## Context
What forces are at play? What problem are we solving?

## Options considered
1. Option A — pros / cons
2. Option B — pros / cons

## Decision
What we chose and why.

## Consequences
What becomes easier, what becomes harder, what we must watch.
```
