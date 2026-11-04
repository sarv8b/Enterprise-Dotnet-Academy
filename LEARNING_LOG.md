# Learning Log — Enterprise .NET Developer Academy

> **Learner:** Sarvesh · **Log initialised:** 2026-11-03
> **Roadmap:** `ROADMAP.md` · **Project:** `PROJECT_SPEC.md` · **Standards:** `CODING_STANDARDS.md`

---

## 1. Current snapshot

| Item | Value |
|---|---|
| Current phase | Phase 1 — C# and .NET Fundamentals |
| Current topic | Calibration diagnostic done; next: P1.6 (for M0), then P1.1 |
| Current project milestone | M0 — Repository foundation (not started) |
| Topics mastered | 0 / 54 |
| Exercises completed | 0 (calibration diagnostic is not an exercise) |
| Sessions completed | 1 |
| Last session | Session 1 — 2026-11-04 — calibration diagnostic (Part A only) |
| Next session | Session 2 — P1.6 intro + `M0-E1` Repository foundation (see §9) |

---

## 2. How this log is maintained

**Who updates it:** the mentor proposes updates at the end of every session; Sarvesh commits them.

**Status values (used in §3):**

| Status | Meaning |
|---|---|
| `NOT STARTED` | Not yet taught in this academy |
| `IN PROGRESS` | Concept introduced; exercises underway |
| `PRACTICED` | Implemented, but with significant hints, a revealed solution, or an incomplete understanding check |
| `MASTERED` | Explained in own words **and** implemented independently **and** understanding check passed |

**Rules**

1. A topic moves to `MASTERED` only with evidence: the exercise ID(s) implemented independently and the understanding check passed. No exceptions.
2. Prior professional experience does **not** count until it is demonstrated here. A calibration diagnostic may fast-track a topic, but it still needs one independent exercise.
3. If a solution was revealed (at Sarvesh's request), the exercise is logged as `solution revealed` and the topic cannot reach `MASTERED` from that exercise alone; a follow-up exercise is required.
4. Struggles stay listed in §6 until a later exercise shows they are resolved; then move them to "Resolved" with the date and evidence.
5. Exercise IDs follow `P{phase}.{topic}-E{n}` (e.g. `P1.3-E2`). Standalone exercises live in `exercises/<exercise-id>-<short-name>/`. Project work lives in `src/` and `tests/`.

---

## 3. Topic tracker

### Phase 1 — C# and .NET Fundamentals

| ID | Topic | Status | Evidence (exercises / check) | Notes |
|---|---|---|---|---|
| P1.1 | C# types, classes, structs, records | NOT STARTED | — | Diagnostic S1: gap — value vs reference copy (wrong at confidence M); records/`with` unknown. **Teach at full depth.** |
| P1.2 | OOP, interfaces, inheritance, polymorphism | NOT STARTED | — | Diagnostic S1: partial — named override/hiding, wrong on hiding behaviour |
| P1.3 | Generics, delegates, events, LINQ | NOT STARTED | — | Diagnostic S1: partial — `ToList()` snapshot right; deferred execution + captured variable wrong |
| P1.4 | Exception handling and resource management | NOT STARTED | — | Diagnostic S1: gap — missed `throw ex;` and missing error context |
| P1.5 | Collections and nullable reference types | NOT STARTED | — | Diagnostic S1: partial — knows NRT doesn't throw; thought non-nullable can't be null at runtime |
| P1.6 | .NET SDK, CLI, project files, NuGet | NOT STARTED | — | Diagnostic S1: SDK vs runtime correct; SDK selection / TFM vs SDK wrong |

### Phase 2 — Advanced C# and Runtime

| ID | Topic | Status | Evidence | Notes |
|---|---|---|---|---|
| P2.1 | Async/await, Task, cancellation tokens | NOT STARTED | — | |
| P2.2 | Threading, concurrency, synchronization | NOT STARTED | — | |
| P2.3 | Memory, garbage collection, IDisposable | NOT STARTED | — | |
| P2.4 | Reflection, attributes, expression trees | NOT STARTED | — | |
| P2.5 | Dependency injection and configuration | NOT STARTED | — | |
| P2.6 | Logging and application settings | NOT STARTED | — | |

### Phase 3 — ASP.NET Core Backend

| ID | Topic | Status | Evidence | Notes |
|---|---|---|---|---|
| P3.1 | HTTP, REST, status codes | NOT STARTED | — | |
| P3.2 | Minimal APIs and Controllers | NOT STARTED | — | |
| P3.3 | Middleware and request pipeline | NOT STARTED | — | |
| P3.4 | Routing, model binding, validation | NOT STARTED | — | |
| P3.5 | Authentication and authorization | NOT STARTED | — | |
| P3.6 | Filters, exception handling, API versioning | NOT STARTED | — | |
| P3.7 | OpenAPI and Swagger | NOT STARTED | — | |

### Phase 4 — Database and Persistence

| ID | Topic | Status | Evidence | Notes |
|---|---|---|---|---|
| P4.1 | SQL Server, joins, indexes, transactions | NOT STARTED | — | |
| P4.2 | Entity Framework Core | NOT STARTED | — | |
| P4.3 | Code-first migrations | NOT STARTED | — | |
| P4.4 | LINQ to Entities | NOT STARTED | — | |
| P4.5 | Repository patterns and their trade-offs | NOT STARTED | — | |
| P4.6 | Query optimization and N+1 problems | NOT STARTED | — | |
| P4.7 | Dapper and raw SQL | NOT STARTED | — | |

### Phase 5 — Enterprise Architecture

| ID | Topic | Status | Evidence | Notes |
|---|---|---|---|---|
| P5.1 | SOLID principles | NOT STARTED | — | |
| P5.2 | Design patterns | NOT STARTED | — | |
| P5.3 | Clean Architecture | NOT STARTED | — | |
| P5.4 | Domain-Driven Design fundamentals | NOT STARTED | — | |
| P5.5 | CQRS and MediatR | NOT STARTED | — | |
| P5.6 | Modular monoliths | NOT STARTED | — | |
| P5.7 | Microservices and distributed systems | NOT STARTED | — | |

### Phase 6 — Testing and Quality

| ID | Topic | Status | Evidence | Notes |
|---|---|---|---|---|
| P6.1 | xUnit | NOT STARTED | — | |
| P6.2 | Unit testing and integration testing | NOT STARTED | — | |
| P6.3 | Mocking with NSubstitute or Moq | NOT STARTED | — | |
| P6.4 | WebApplicationFactory | NOT STARTED | — | |
| P6.5 | Testcontainers | NOT STARTED | — | |
| P6.6 | Code coverage and static analysis | NOT STARTED | — | |
| P6.7 | Refactoring and maintainability | NOT STARTED | — | |

### Phase 7 — Enterprise Infrastructure

| ID | Topic | Status | Evidence | Notes |
|---|---|---|---|---|
| P7.1 | Docker and Docker Compose | NOT STARTED | — | |
| P7.2 | Redis caching | NOT STARTED | — | |
| P7.3 | Background workers | NOT STARTED | — | |
| P7.4 | Message brokers and RabbitMQ | NOT STARTED | — | |
| P7.5 | Kafka fundamentals | NOT STARTED | — | |
| P7.6 | Resilience and retries | NOT STARTED | — | |
| P7.7 | Observability with OpenTelemetry | NOT STARTED | — | |

### Phase 8 — Cloud and Production Engineering

| ID | Topic | Status | Evidence | Notes |
|---|---|---|---|---|
| P8.1 | Azure or AWS deployment | NOT STARTED | — | |
| P8.2 | CI/CD with GitHub Actions | NOT STARTED | — | |
| P8.3 | Secrets management | NOT STARTED | — | |
| P8.4 | Infrastructure as Code | NOT STARTED | — | |
| P8.5 | Application monitoring | NOT STARTED | — | |
| P8.6 | Security and performance | NOT STARTED | — | |
| P8.7 | System design and scalability | NOT STARTED | — | |

---

## 4. Topics completed

_None yet._

<!-- Format: - P1.1 C# types, classes, structs, records — MASTERED on YYYY-MM-DD (evidence: P1.1-E2, check passed in Session N) -->

---

## 5. Exercises completed

_No exercises completed in this repository yet._ (Session 1's calibration diagnostic was a check, not an exercise; it does not count toward mastery.)

| Exercise ID | Title | Topic | Date | Hint level used | Solution revealed? | Review outcome | Follow-up |
|---|---|---|---|---|---|---|---|
| — | — | — | — | — | — | — | — |

**Hint levels:** 0 = none · 1 = nudge · 2 = direction · 3 = specific pointer · 4 = partial code · 5 = full solution (explicitly requested)

---

## 6. Concepts

### 6.1 Concepts I understand (verified in this academy)

Items are added only after an explanation check or independent implementation.

- [P1.6] SDK vs runtime: the SDK contains the runtime plus build tools; production needs only a runtime — diagnostic Q11a, Session 1 (2026-11-04), answered correctly at confidence H. (Refinement given: ASP.NET Core apps need the `aspnet` runtime image.)
- [P1.3] `ToList()` executes a query immediately and produces an independent snapshot — diagnostic Q4, Session 1 (2026-11-04).

### 6.2 Concepts I struggle with

Found in the Session 1 calibration diagnostic (2026-11-04). Correct answers were explained in the review; each item stays here until a later exercise shows it is resolved.

- [P1.1] **Value vs reference copy semantics** — predicted `2 1` instead of `1 2` for struct vs class assignment, at confidence M (confident misconception — top priority). Correction: assigning a struct copies the data; assigning a class copies the reference. Plan: P1.1 prediction drills + exercise.
- [P1.1] **Records, `with`, value equality** — concept unknown. Correction: records compare by value; `with` makes a new object via a shallow copy; a `List<T>` property compares by reference and is shared between copies. Plan: P1.1 exercise.
- [P1.1] **Choosing class vs record vs struct** — right choices for entity/audit entry, but justified by overriding/interfaces rather than identity vs value semantics; strongly typed IDs (`readonly record struct`) unknown. Plan: P1.1 design question.
- [P1.2] **Method hiding (`new`)** — predicted `derived`; hidden methods bind to the variable's compile-time type, overrides to the runtime type. Plan: P1.2 prediction question.
- [P1.3] **Deferred execution + closures** — expected the query to use the original `minLength` and list; a deferred query reads the captured variable's current value and the current collection when enumerated. Plan: P1.3 prediction exercise (also a Phase 1 exit criterion).
- [P1.4] **Rethrowing and error context** — missed that `throw ex;` resets the stack trace (`ERR-2`), that the log message lost the exception, and that the `catch` added no value. Plan: P1.4 exercise.
- [P1.5] **NRT guarantees** — answered "no, it can't be null at runtime" (the explanation itself was correct). NRT is compile-time only; null still arrives via deserialisation, reflection, `!`, unannotated libraries. Also: `Deserialize<T>` returns `T?`. Plan: P1.5 exercise.
- [P1.5] **Read-only exposure** — did not know `IReadOnlyList<T>` can be cast back to `List<T>`; it is a compile-time contract, not runtime protection (`AsReadOnly()` wrapper if needed). Plan: P1.5 / M1 review.
- [P1.6] **SDK selection** — believed the `.csproj` picks the SDK; without `global.json` the latest installed SDK is used, and `TargetFramework` sets the target framework, not the SDK. Plan: M0-E1.
- [P2.1] **`async void` and sync-over-async** — said "nothing happens" if an `async void` method throws (it crashes the process); `.Result`/`.Wait()` not identified as problems. Expected at this stage. Plan: P2.1.
- [P2.2] **Race conditions** — could not predict a lost-update race on `processed++` in `Parallel.ForEachAsync`. Expected at this stage. Plan: P2.2.
- [P2.5] **Captive dependencies and DI scope validation** — concept unknown; suggested "matching lifetimes" (right direction; correct rule: never depend on a shorter-lived service). Expected at this stage. Plan: P2.5.

<!-- Format: - [P2.1] Why ConfigureAwait(false) is irrelevant in ASP.NET Core app code — seen in P2.1-E1 (YYYY-MM-DD). Plan: prediction exercise. -->

### 6.3 Resolved struggles

_None yet._

---

## 7. Upcoming topics (next up)

1. **P1.6** .NET SDK, CLI, project files, NuGet — needed first to complete milestone M0
2. **P1.1** C# types, classes, structs, records
3. **P1.2** OOP, interfaces, inheritance, polymorphism
4. **P1.3** Generics, delegates, events, LINQ
5. **P1.4** Exception handling and resource management
6. **P1.5** Collections and nullable reference types

Order confirmed after the Session 1 calibration diagnostic. No topic is fast-tracked: Phase 1 runs at full depth, with extra time on P1.1 (value vs reference semantics) because later topics depend on it.

---

## 8. Project milestones

| Milestone | Title | Roadmap phase | Status | Started | Completed | Notes |
|---|---|---|---|---|---|---|
| M0 | Repository foundation | 1 | NOT STARTED | — | — | |
| M1 | In-memory console engine | 1 | NOT STARTED | — | — | |
| M2 | Hosted, async console engine | 2 | NOT STARTED | — | — | |
| M3 | Web API | 3 | NOT STARTED | — | — | |
| M4 | SQL Server persistence | 4 | NOT STARTED | — | — | |
| M5 | Architecture refactor | 5 | NOT STARTED | — | — | |
| M6 | Quality and test hardening | 6 | NOT STARTED | — | — | |
| M7 | Distributed infrastructure | 7 | NOT STARTED | — | — | |
| M8 | Production deployment | 8 | NOT STARTED | — | — | |

A milestone is complete only when every "Done when" criterion in `PROJECT_SPEC.md` is met and committed.

---

## 9. Next session plan

### Session 2 — P1.6 and repository foundation

**Part A — Concept intro: P1.6 (~15 minutes)**
SDK vs runtime, how the SDK is selected, `global.json`, `.csproj` anatomy, `Directory.Build.props`, Central Package Management. Revisits the Session 1 struggle on SDK selection.

**Part B — Next exercise: `M0-E1` Repository foundation (~45 minutes)**
Set up the repository skeleton defined in `PROJECT_SPEC.md` → M0, following `CODING_STANDARDS.md` → Build and project configuration. You implement it; ask for hints when stuck.

Note: the repository is currently on a `master` branch with no commits; the first commit must land on `main`.

Acceptance checks:
- [ ] `dotnet build` and `dotnet test` succeed from the repository root with zero warnings.
- [ ] The SDK version is pinned, and nullable reference types plus warnings-as-errors apply to every project without being repeated in each `.csproj`.
- [ ] Package versions are managed centrally.
- [ ] `.gitignore`, `.editorconfig`, and a `README.md` with run instructions exist.
- [ ] The first commit is on `main` with a meaningful message.

Be ready to explain: what `global.json` controls, and what happens when `Directory.Build.props` exists in a parent folder.

---

## 10. Session history

### Session 1 — 2026-11-04
- **Topics covered:** Calibration diagnostic (11 questions) across Phase 1 (P1.1–P1.6) and early Phase 2 (P2.1, P2.2, P2.5). Reviewed and explained every answer.
- **Exercises:** None. Part A (diagnostic) completed; Part B (`M0-E1`) not started.
- **Understanding check:** Predict-the-output, spot-the-bug, and explain/trade-off questions. Correct: Q11a (SDK vs runtime). Partly correct: Q3, Q4, Q6b, Q7a/b, Q10c. Incorrect or unknown: Q1, Q2, Q5, Q6a, Q7c, Q8, Q9, Q10a/b, Q11b.
- **Self-assessment:** Confidence labels mostly reliable (most wrong answers were marked L; the H answer was correct). Exception: Q1 was wrong at confidence M.
- **Mistakes and corrections:** See §6.2. Most important: struct vs class copy semantics were reversed.
- **Best practices introduced (preview):** `throw;` not `throw ex;` (`ERR-2`); NRT is compile-time only; no `async void` (`ASY-1`) or sync-over-async (`ASY-2`); DI scope validation (`DI-2`); strongly typed IDs.
- **Status changes:** None. No topic started or completed; diagnostic results recorded as notes in §3.
- **Next exercise:** `M0-E1` Repository foundation, after a P1.6 concept intro (see §9).

<!--
### Session N — YYYY-MM-DD
- **Topics covered:**
- **Exercises:** (ID, outcome, hint level)
- **Understanding check:** (question type, result)
- **Mistakes and corrections:**
- **Best practices introduced:**
- **Status changes:**
- **Next exercise:**
-->
