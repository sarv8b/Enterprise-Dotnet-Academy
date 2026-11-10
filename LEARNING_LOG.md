# Learning Log — Enterprise .NET Developer Academy

> **Learner:** Sarvesh · **Log initialised:** 2026-11-03
> **Roadmap:** `ROADMAP.md` · **Project:** `PROJECT_SPEC.md` · **Standards:** `CODING_STANDARDS.md`

---

## 1. Current snapshot

| Item | Value |
|---|---|
| Current phase | Phase 1 — C# and .NET Fundamentals |
| Current topic | P1.1 C# types, classes, structs, records — IN PROGRESS (`P1.1-E1` done, `P1.1-E2` next). P1.6 **MASTERED** 2026-11-08 |
| Current project milestone | M0 — Repository foundation **COMPLETE** (2026-11-05); M1 not started (`src/WorkflowPlatform.Core` scaffolded in `P1.6-E2`) |
| Topics mastered | 1 / 54 (P1.6) |
| Exercises completed | 4 (`M0-E1`, `P1.6-E1b`, `P1.6-E2`, `P1.1-E1`) |
| Sessions completed | 4 |
| Last session | Session 4 — 2026-11-09 to 2026-11-10 — P1.1 concept intro + `P1.1-E1` value vs reference semantics |
| Next session | Session 5 — `P1.1-E2` Model the M1 domain types (see §9) |

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
5. Exercise IDs follow `P{phase}.{topic}-E{n}` (e.g. `P1.3-E2`). Standalone exercises live in `exercises/<exercise-id>-<short-name>/`. Project work lives in `src/` and `tests/`. Learning tests (throwaway types that prove a language behaviour) live in `tests/WorkflowPlatform.Learning.Tests`, so they inherit the `tests/` build layer (`BLD-11`); a test project under `exercises/` would not (changed 2026-11-09).

---

## 3. Topic tracker

### Phase 1 — C# and .NET Fundamentals

| ID | Topic | Status | Evidence (exercises / check) | Notes |
|---|---|---|---|---|
| P1.1 | C# types, classes, structs, records | IN PROGRESS | `P1.1-E1` completed (predictions + 12 learning tests). Part A: 5 wrong or unknown out of 13, including Q2 and the Q1 bonus at confidence H; all corrected and proven by tests or compiler codes. Q2 explanation accepted in own words. | Not `MASTERED`: still needs the class/struct/record design choice with own-words reasoning (`P1.1-E2`, Phase 1 exit criterion). Diagnostic S1 value vs reference gap resolved (§6.3). |
| P1.2 | OOP, interfaces, inheritance, polymorphism | NOT STARTED | — | Diagnostic S1: partial — named override/hiding, wrong on hiding behaviour |
| P1.3 | Generics, delegates, events, LINQ | NOT STARTED | — | Diagnostic S1: partial — `ToList()` snapshot right; deferred execution + captured variable wrong |
| P1.4 | Exception handling and resource management | NOT STARTED | — | Diagnostic S1: gap — missed `throw ex;` and missing error context |
| P1.5 | Collections and nullable reference types | NOT STARTED | — | Diagnostic S1: partial — knows NRT doesn't throw; thought non-nullable can't be null at runtime |
| P1.6 | .NET SDK, CLI, project files, NuGet | MASTERED | Implemented independently: `M0-E1` (hint level 0). Understanding check passed S3: `P1.6-E1b` (raw `-getProperty` output for both scenarios, rule stated in own words, `GetPathOfFileAbove` fixed after reproducing `MSB4011`). Own-words trade-off: stopping at the first `Directory.Build.props` gives isolation, but chaining is manual. Follow-up `P1.6-E2` completed (hint level 3 on request) | Mastered 2026-11-08. Phase 1 exit criterion "multi-project solution with shared build settings" met. Remaining revision items in §6.2. |

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

- P1.6 .NET SDK, CLI, project files, NuGet — MASTERED on 2026-11-08 (evidence: `M0-E1` independent; `P1.6-E1b` check passed in Session 3; follow-up `P1.6-E2`)

<!-- Format: - P1.1 C# types, classes, structs, records — MASTERED on YYYY-MM-DD (evidence: P1.1-E2, check passed in Session N) -->

---

## 5. Exercises completed

Session 1's calibration diagnostic was a check, not an exercise, and is not listed here.

| Exercise ID | Title | Topic | Date | Hint level used | Solution revealed? | Review outcome | Follow-up |
|---|---|---|---|---|---|---|---|
| `M0-E1` | Repository foundation | P1.6 | 2026-11-05 | 0 (one requirement clarification on the ADR; no hints) | No | Passed after one revision round. First review: `README.md` empty (`DOC-1`), `dotnet format` failed (`NAM-2`), mixed CRLF/LF line endings. All fixed in `d1b6dfe`. Commits `e83473c`, `d1b6dfe`. | `P1.6-E1b`, then `P1.6-E2` |
| `P1.6-E1b` | Prove MSBuild import order (throwaway folder outside the repo) | P1.6 | 2026-11-07 | 1 (`GetPathOfFileAbove` start directory: nudge that the search includes the start folder, then reproduce-and-fix) | No | Passed. Raw output: (i) `TreatWarningsAsErrors=false`, `Nullable=disable`; (ii) `Nullable=enable`. Both disproved the S2 predictions. Rule stated correctly in own words. First answer to (a) was wrong (thought the search started above the current file); reproduced `MSB4011` and fixed it with `$(MSBuildThisFileDirectory)../`. Bonus: built the wrong (root) project, which exposed nested-project globbing. | `P1.6-E2` |
| `P1.6-E2` | Layered build configuration + empty `src/WorkflowPlatform.Core` | P1.6 | 2026-11-08 | 3 (explanations of per-setting reasons, items vs properties, the `.Tests` condition expression, and the two kinds of MSBuild warnings given at Sarvesh's request; Sarvesh implemented every change) | No | Passed after four review rounds. Fixed: lowercase `WorkflowPlatform.core` → `WorkflowPlatform.Core`; per-project `xunit.runner.json` time bomb → one shared file via `$(MSBuildThisFileDirectory)` + `Link` (Option C), `Exists` guard removed so it fails fast; duplicate `ImplicitUsings`; stale `obj/` after the rename (`MSB4011`); stray `.slnx` folder; `Class1.cs`; generated `graphify-out/` committed → untracked and ignored; test-only settings gated on `.Tests` and documented as `BLD-11`; `MSBuildTreatWarningsAsErrors` in root props and `-warnaserror` in the README. Both warning proofs run. Gates: build (`-warnaserror`) 0/0, test 1/1, format clean. Commits `b98c675`, `882efb3`, `9cd50e8`, fast-forwarded to `main`. | P1.1 (`P1.1-E1`) |
| `P1.1-E1` | Value vs reference semantics: predict, then prove with learning tests | P1.1 | 2026-11-10 | 2 for the predictions (hints pointing at the rule to apply, no answers revealed); 3 for test quality (specific pointers such as `Assert.Same`, splitting tests, the `Counter` property question). **Unconfirmed:** commits `ba8dca2` and `b987052` carry a `Co-Authored-By: Claude` trailer; asked whether another assistant session was used, not yet answered. | No | Passed after one revision round. Part A wrong or unknown: Q1 bonus (H), Q2 (H), Q4 line 1, Q6 `Cancel`; design answer too vague. All corrected: CS1612, `"Triage"`, `3`, CS1503, CS9035, CS8852; design → immutable collections. Test fixes: `TST-9` names, `TST-5` sections, one behaviour per test, `Assert.Same` on the shared list, missing Q4 cases added, `Counter` field → property (no pragma), stray runner.json removed. Independent: scoped CA1707 suppression in `tests/.editorconfig`. Gates: build (`-warnaserror`) 0/0, test 12/12, format clean. Branch `typesincsharp` (commits `3ec6420`, `ba8dca2`, `b987052`), **not merged yet**. | `P1.1-E2` |

**Hint levels:** 0 = none · 1 = nudge · 2 = direction · 3 = specific pointer · 4 = partial code · 5 = full solution (explicitly requested)

---

## 6. Concepts

### 6.1 Concepts I understand (verified in this academy)

Items are added only after an explanation check or independent implementation.

- [P1.6] SDK vs runtime: the SDK contains the runtime plus build tools; production needs only a runtime — diagnostic Q11a, Session 1 (2026-11-04), answered correctly at confidence H. (Refinement given: ASP.NET Core apps need the `aspnet` runtime image.)
- [P1.3] `ToList()` executes a query immediately and produces an independent snapshot — diagnostic Q4, Session 1 (2026-11-04).
- [P1.6] Centralising build settings in `Directory.Build.props` so no `.csproj` repeats them — implemented in `M0-E1` (2026-11-05).
- [P1.6] Central Package Management: `PackageVersion` in `Directory.Packages.props` declares the version; `PackageReference` in a `.csproj` uses the package without one — found and fixed own error in `M0-E1`, explained it correctly (2026-11-05).
- [P1.6] Pinning the SDK with `global.json` + `rollForward: latestFeature`: 10.0.300 accepted, 11.0.100 rejected — check (a), Session 2 (2026-11-05). Found the xUnit v3 / Microsoft.Testing.Platform setup independently.
- [P1.6] `Directory.Build.props` is found by walking **up** from the project folder, never into sibling folders — check (b), Session 2 (2026-11-05).
- [P1.6] MSBuild import order: `Directory.Build.props` → `.csproj` → `Directory.Build.targets`; only the first file of each kind is found walking up, then the search stops; the last assignment wins — proven by own experiment `P1.6-E1b` (2026-11-07).
- [P1.6] Chaining props files with `GetPathOfFileAbove('Directory.Build.props', '$(MSBuildThisFileDirectory)../')`, importing at the **top** so local values override the parent ("last assignment wins") — `P1.6-E1b` (2026-11-07), applied in `P1.6-E2`.
- [P1.6] Trade-off of stopping at the first props file: isolation from unrelated parent folders vs manual chaining — explained in own words (2026-11-07).
- [P1.6] Relative `Include` paths in an imported file resolve from **each project's** folder; use `$(MSBuildThisFileDirectory)` + `Link` for a shared file — `P1.6-E2` (2026-11-08).
- [P1.6] Fail fast over silent fallback: removed the `Exists` guard on the shared `xunit.runner.json` and explained why in own words — `P1.6-E2` (2026-11-08).
- [P1.6] Conditional settings by naming convention (`$(MSBuildProjectName.EndsWith('.Tests'))`), with the convention documented (`BLD-11`) because nothing warns when it is broken — `P1.6-E2` (2026-11-08).
- [P1.6] Evaluation-time vs build-time MSBuild warnings: `MSBuildTreatWarningsAsErrors` only applies after evaluation, so it misses `MSB4011`; the `-warnaserror` switch is set before evaluation and catches both — proven with two forced failures, summary accepted after one correction (2026-11-08).
- [P1.6] Repo hygiene: don't nest a project inside another project's folder (default `**/*.cs` globbing), clear `bin/`/`obj/` after a rename, don't commit generated output — seen and fixed in `P1.6-E1b`/`P1.6-E2` (2026-11-08).
- [P1.1] What assignment and parameter passing copy: a struct copies its data; a class copies the reference, so mutation through a parameter reaches the caller's object but reassigning the parameter does not — Q1/Q2 tests and own-words explanation, `P1.1-E1` (2026-11-10).
- [P1.1] A `List<T>` indexer returns a **copy** of a struct element, so `list[0].Value = 5` is rejected (CS1612) — `P1.1-E1` (2026-11-10).
- [P1.1] `==` on classes compares references; on records it compares member values, using each member's own equality (so a `List<T>` member compares by reference) — Q3/Q5 predicted correctly and tested (2026-11-10).
- [P1.1] `with` is a shallow copy: a new object that shares reference-type members; equal (`==`) is not the same as same (`ReferenceEquals`) — tested with `Assert.Same`/`ReferenceEquals`, `P1.1-E1` (2026-11-10).
- [P1.1] `required` + `init` (CS9035, CS8852) and strongly typed IDs as distinct types (CS1503) — `P1.1-E1` (2026-11-10).
- [P1.6] `global.json` `version` is a **minimum** under `latestFeature` (10.0.105 is rejected for 10.0.114) — Session 4 warm-up (2026-11-09).
- [Testing] `TST-9` names (`Method_Scenario_ExpectedResult`), `TST-5` Arrange/Act/Assert, one behaviour per test, assert the cause rather than the symptom; scoped analyzer overrides per folder with `.editorconfig` — `P1.1-E1` (2026-11-10).
- [GIT] Line-ending policy: `.gitattributes` (`* text=auto eol=lf`, binary exclusions) plus `end_of_line = lf` in `.editorconfig` — implemented independently in `d1b6dfe` (2026-11-05).
- [DOC] Writing an ADR with real alternatives, honest costs and working rules — `docs/adr/0001` (2026-11-05).

### 6.2 Concepts I struggle with

Each item stays here until a later exercise shows it is resolved. Items marked S1 come from the Session 1 calibration diagnostic (2026-11-04); S2 from Session 2 (2026-11-05); S3 from Session 3 (2026-11-07 to 2026-11-08); S4 from Session 4 (2026-11-09 to 2026-11-10).

- [Process] **Confidence calibration (S4)** — in `P1.1-E1` Part A both wrong answers that carried a label were marked **H** (Q1 bonus, Q2), and Q3/Q4 had no labels. High confidence is not yet a reliable signal on value/reference questions. Plan: keep labelling every prediction; review H-labelled misses at the start of each check.
- [P1.6] **Items accumulate, properties are replaced (S3)** — first answer to the `TestUtilities` question assumed a `.csproj` can "override" everything from a props file; items (`PackageReference`, `Using`) add to a list and need `Remove`. Explained by the mentor and applied via the `.Tests` condition, but not yet re-explained by Sarvesh. Plan: one prediction question when items next come up (M1 project references).
- [P1.6] **Justifying settings one by one (S3)** — moved test settings to `tests/Directory.Build.props` as a group ("all test projects may share them"), which let the duplicate `ImplicitUsings` and the runner.json problem through. Asked three times for a reason per setting; the final reasons were given by the mentor. Plan: in future config/design reviews, Sarvesh justifies each line before submitting.
- [Process] **Checking researched answers against evidence (S3)** — the first MSBuild-warnings answer was pasted text that repeated a claim (`TreatWarningsAsErrors` covers MSBuild warnings) that Sarvesh's own build output had just disproved; the follow-up summary also conflated the compiler property with the MSBuild one. Resolved for this concept after running the proofs, but the habit to build is: run the experiment first, then write the answer in own words.

- [P1.1] **Choosing class vs record vs struct** — right choices for entity/audit entry, but justified by overriding/interfaces rather than identity vs value semantics. Strongly typed IDs are now understood (`P1.1-E1`), but the choice itself has not been made and justified yet. Plan: `P1.1-E2` design table.
- [P1.1] **Real immutability and equality strategy (S4)** — first design answer was "make it readonly" (the property is already `init`; the list contents are the mutable part); revised to immutable collections. Not yet handled: defensive copy of the caller's list, and that `ImmutableArray<T>` alone does not give content-based record equality. Plan: `P1.1-E2`.
- [P1.2] **Method hiding (`new`)** — predicted `derived`; hidden methods bind to the variable's compile-time type, overrides to the runtime type. Plan: P1.2 prediction question.
- [P1.3] **Deferred execution + closures** — expected the query to use the original `minLength` and list; a deferred query reads the captured variable's current value and the current collection when enumerated. Plan: P1.3 prediction exercise (also a Phase 1 exit criterion).
- [P1.4] **Rethrowing and error context** — missed that `throw ex;` resets the stack trace (`ERR-2`), that the log message lost the exception, and that the `catch` added no value. Plan: P1.4 exercise.
- [P1.5] **NRT guarantees** — answered "no, it can't be null at runtime" (the explanation itself was correct). NRT is compile-time only; null still arrives via deserialisation, reflection, `!`, unannotated libraries. Also: `Deserialize<T>` returns `T?`. Plan: P1.5 exercise.
- [P1.5] **Read-only exposure** — did not know `IReadOnlyList<T>` can be cast back to `List<T>`; it is a compile-time contract, not runtime protection (`AsReadOnly()` wrapper if needed). Plan: P1.5 / M1 review.
- [P2.1] **`async void` and sync-over-async** — said "nothing happens" if an `async void` method throws (it crashes the process); `.Result`/`.Wait()` not identified as problems. Expected at this stage. Plan: P2.1.
- [P2.2] **Race conditions** — could not predict a lost-update race on `processed++` in `Parallel.ForEachAsync`. Expected at this stage. Plan: P2.2.
- [P2.5] **Captive dependencies and DI scope validation** — concept unknown; suggested "matching lifetimes" (right direction; correct rule: never depend on a shorter-lived service). Expected at this stage. Plan: P2.5.

<!-- Format: - [P2.1] Why ConfigureAwait(false) is irrelevant in ASP.NET Core app code — seen in P2.1-E1 (YYYY-MM-DD). Plan: prediction exercise. -->

### 6.3 Resolved struggles

- [P1.6] **SDK selection** (S1, Q11b) — had believed the `.csproj` picks the SDK. Resolved 2026-11-05: pinned the SDK with `global.json` in `M0-E1` and correctly predicted which SDK versions it accepts (check a). Remaining nuance (the version is a minimum) is tracked separately in §6.2.
- [P1.6] **`global.json` version is a minimum** (S2) — resolved 2026-11-09: Session 4 warm-up answered correctly (10.0.105 rejected because the pinned version is a minimum under `latestFeature`).
- [P1.1] **Value vs reference copy semantics** (S1, confidence M; resurfaced in S4 as Q2 at confidence H) — resolved 2026-11-10: corrected predictions proven by tests in `P1.1-E1` (struct copied out of a list, class mutated through a parameter but not reassigned), and explained in own words: the parameter holds a copy of the caller's reference.
- [P1.1] **Records, `with`, value equality** (S1, unknown) — resolved 2026-11-10: record vs class equality and Q5 predicted correctly; `with` shallow copy proven with `Assert.Same(v1.Steps, v2.Steps)` after the Q4 line-1 miss.
- [P1.6] **`Directory.Build.props` import rule** (S2, confidence H) — had predicted that the nested and the root props files both apply. Resolved 2026-11-07: own experiment `P1.6-E1b` showed `TreatWarningsAsErrors=false` (root file never imported); stated the first-found-then-stop rule in own words and chained the files correctly with `GetPathOfFileAbove` in `P1.6-E2`.
- [P1.6] **Property evaluation order** (S2, confidence H) — had predicted that the `.csproj` beats `Directory.Build.targets` ("nearest"). Resolved 2026-11-07: experiment (ii) showed `Nullable=enable` from `.targets`; explained "props → `.csproj` → targets, last assignment wins" and used it to place the `<Import>` at the top of `tests/Directory.Build.props`.

---

## 7. Upcoming topics (next up)

1. **P1.1** C# types, classes, structs, records — IN PROGRESS; `P1.1-E1` done, `P1.1-E2` next (Session 5)
2. **P1.2** OOP, interfaces, inheritance, polymorphism
3. **P1.3** Generics, delegates, events, LINQ
4. **P1.4** Exception handling and resource management
5. **P1.5** Collections and nullable reference types

P1.6 was mastered on 2026-11-08 (see §4).

Order confirmed after the Session 1 calibration diagnostic. No topic is fast-tracked: Phase 1 runs at full depth, with extra time on P1.1 (value vs reference semantics) because later topics depend on it.

---

## 8. Project milestones

| Milestone | Title | Roadmap phase | Status | Started | Completed | Notes |
|---|---|---|---|---|---|---|
| M0 | Repository foundation | 1 | COMPLETE | 2026-11-04 | 2026-11-05 | All three "Done when" criteria met and committed (`e83473c`, `d1b6dfe`). Build, test and `dotnet format` pass. |
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

### Session 5 — Finish P1.1

**Before starting:** answer the open `Co-Authored-By` question (§10, Session 4) and merge `typesincsharp` into `main`.

**Next exercise: `P1.1-E2` Model the M1 domain types (~50 minutes)** — brief already given in Session 4.
- Real project code in `src/WorkflowPlatform.Core`, tests in `tests/WorkflowPlatform.Core.Tests`, on a new branch. Names from `PROJECT_SPEC.md` §4.
- Types: `DefinitionId`, `InstanceId`, `StepKind`, `Step`, `Transition`, `WorkflowDefinition` (BR-03: immutable), `AuditEntry` (BR-08: never changed), `WorkflowInstance`. Shapes only; no validation or transition logic.
- Deliverables:
  - a design table: class, struct or record for each type, with one sentence of reasoning (identity vs value, mutability);
  - real immutability of the steps, including against the caller's original list;
  - a justified equality strategy for `WorkflowDefinition`: (a) override `Equals`/`GetHashCode`, (b) identity by ID + version, or (c) a structural-equality collection;
  - tests, one behaviour each;
  - gates.

**Then:** if `P1.1-E2` passes, P1.1 can be marked `MASTERED` and Session 6 starts **P1.2** OOP, interfaces, inheritance, polymorphism.

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

### Session 2 — 2026-11-04 to 2026-11-05
- **Topics covered:** P1.6 concept intro: SDK vs runtime and feature bands, SDK selection and `global.json`, `.csproj` anatomy, `Directory.Build.props`/`.targets`, Central Package Management, `.slnx`. ADR purpose and structure (clarification on ADR 0001).
- **Exercises:** `M0-E1` Repository foundation — **completed**, hint level 0. First submission (`e83473c`) failed two acceptance checks; the revision (`d1b6dfe`) passed all of them. Milestone **M0 complete**.
- **Understanding check:**
  - Post-exercise questions: (a) mostly right (no confidence label given); (b) right conclusion, incomplete; (c) right location, wrong reasoning.
  - Re-check: (i) and (ii) both **wrong at confidence H**.
  - `P1.6-E1b` experiment assigned; the reply answered a different scenario (`.props` vs `.csproj`) instead of sending the experiment output. **Not passed yet.**
- **Mistakes and corrections:**
  - `PackageReference` with a version in `Directory.Packages.props` → corrected to `PackageVersion` (self-fixed).
  - `README.md` left empty (`DOC-1`, MUST) → full README written.
  - `dotnet format --verify-no-changes` failed (`FINALNEWLINE`) → fixed by making files match the template's `insert_final_newline = false`. That is a valid CHOICE, but the question of whether it was deliberate is still unanswered; `true` is the common convention.
  - Mixed CRLF/LF line endings → `.gitattributes` + `end_of_line = lf`.
  - Template test name `UnitTest1.Test1` → `SampleTest.PlaceholderTest` (acceptable as a placeholder).
  - Commit messages not in Conventional Commits format (`GIT-5`) and describing mechanics rather than intent (`GIT-3`), e.g. `Chores : fixing config values` → should be `chore: add README and enforce LF line endings`. Apply from the next commit.
  - MSBuild import order: see §6.2 (two confident misconceptions).
- **Best practices introduced:** reproducible builds through SDK pinning; one place for shared build settings; one version per package; `dotnet msbuild -getProperty` to debug effective build values; line-ending normalisation; ADRs are immutable once accepted (superseded, not edited).
- **Status changes:** P1.6 `NOT STARTED` → `IN PROGRESS`. M0 `NOT STARTED` → `COMPLETE`. SDK-selection struggle moved to §6.3.
- **Open items carried over:** whether `insert_final_newline = false` is a deliberate policy; optional stretch ADR `0002-solution-file-format.md`; optional polish (move `ImplicitUsings` to `Directory.Build.props`, check whether `TestingPlatformDotnetTestSupport` is redundant).
- **Next exercise:** `P1.6-E1b` MSBuild import-order experiment, then `P1.6-E2` layered build configuration (see §9).

### Session 3 — 2026-11-07 to 2026-11-08
- **Topics covered:** P1.6 concept refresher; MSBuild import order and the "last assignment wins" rule; chaining props files with `GetPathOfFileAbove`; properties vs items; conditional settings and naming conventions; relative paths in imported files; evaluation-time vs build-time MSBuild warnings (`MSBuildTreatWarningsAsErrors` vs `-warnaserror`).
- **Exercises:**
  - `P1.6-E1b` — **completed**, hint level 1.
  - `P1.6-E2` — **completed**, hint level 3 (explanations given on request; all implementation by Sarvesh). Fast-forwarded to `main`.
- **Understanding check:**
  - `P1.6-E1b` experiment: both S2 misconceptions disproved by Sarvesh's own output; rule stated correctly in own words.
  - `GetPathOfFileAbove` start directory: first answer wrong, fixed after reproducing `MSB4011`.
  - Import placement (top, so local values win): correct, with a good explanation.
  - Trade-off of stopping at the first props file: correct (isolation vs manual chaining).
  - `Exists` guard: correctly identified the silent fallback and chose fail-fast.
  - MSBuild warnings: first answer incorrect (pasted text); second summary conflated the compiler property with the MSBuild one; third summary (evaluation timing) **accepted**.
- **Mistakes and corrections:**
  - Predicted both props files apply / `.csproj` beats `.targets` → disproved by experiment (moved to §6.3).
  - `GetPathOfFileAbove` searched from the current folder (found itself, `MSB4011`) → start from `$(MSBuildThisFileDirectory)../`.
  - Ran `dotnet build` in a folder whose root project globbed nested projects (CS8802, duplicate attributes) → never nest projects; build the intended project.
  - Lowercase project name `WorkflowPlatform.core` → renamed to PascalCase; stale `obj/` caused `MSB4011` → cleared `bin/`/`obj/`.
  - Per-project `xunit.runner.json` include (would fail with `MSB3030` in a new test project, reproduced) → one shared file via `$(MSBuildThisFileDirectory)` + `Link`; `Exists` guard removed.
  - Duplicate `ImplicitUsings` in root and tests props → one layer only.
  - Test settings applied to every project under `tests/` → gated on `$(MSBuildProjectName.EndsWith('.Tests'))`; first version checked `'Tests'` without the dot, which contradicted `BLD-11` → fixed.
  - Thought `TreatWarningsAsErrors` covers MSBuild warnings (the mentor made the same mistake in E1b and corrected it) → `MSBuildTreatWarningsAsErrors` in root props + `-warnaserror` in CI/README; both proven with forced failures.
  - Generated `graphify-out/` committed on `main` in a mixed, non-Conventional commit (`4ec24b8`) → untracked + `.gitignore`; later work done on branch `build/layered-config` with Conventional Commits.
  - Answers given at group level instead of per setting; one researched answer pasted without checking it against evidence → see §6.2.
- **Best practices introduced:** prove build behaviour with `-getProperty` instead of guessing; chain props files explicitly; fail fast over silent fallback; document any naming convention the build depends on (`BLD-11`); clear `bin/`/`obj/` after renames; keep generated output out of git; branch + Conventional Commits; `-warnaserror` in CI.
- **Status changes:** P1.6 `IN PROGRESS` → `MASTERED`. Two P1.6 struggles moved to §6.3. Phase 1 exit criterion "multi-project solution with shared build settings" met.
- **Open items carried over:**
  - `global.json` minimum-version check.
  - `insert_final_newline = false` decision.
  - Optional ADR `0002-solution-file-format.md`.
  - Polish: the redundant `'$(MSBuildProjectName)' != ''` guard in `tests/Directory.Build.props`, and the leading space in commit `9cd50e8`'s message (don't rewrite history).
  - `LEARNING_LOG.md` changes from this session are uncommitted.
- **Next exercise:** `P1.1-E1` Value vs reference semantics, after the P1.1 concept intro (see §9).

### Session 4 — 2026-11-09 to 2026-11-10
- **Topics covered:** P1.1 concept intro: what assignment and parameter passing copy, reference vs value equality, `init`/`required`, records and `with` (shallow copy), `readonly record struct` for strongly typed IDs, choosing class/record/struct for domain objects.
- **Exercises:** `P1.1-E1` Value vs reference semantics — **completed**, hint level 2–3 (see §5; independence of the test-quality commits not yet confirmed).
- **Understanding check:**
  - Warm-up: `global.json` minimum version — correct.
  - Part A predictions: correct on Q1 output, Q3, Q4 lines 2–4, Q5, Q6 line 1 and Q7. Wrong or unknown on the Q1 bonus (H), Q2 (H), Q4 line 1 and Q6 `Cancel`. All revised correctly and proven by 12 tests and four compiler error codes.
  - Q2 explanation in own words — accepted.
  - Design question: "make it readonly" (too vague) → "immutable collections" (right direction). The equality catch is deferred to `P1.1-E2`.
- **Mistakes and corrections:**
  - Q2: thought reassigning a parameter changes the caller's object → the parameter holds a **copy** of the reference.
  - Q1 bonus: thought `counters[0].Value = 5` compiles → CS1612, because the indexer returns a copy.
  - Q4: thought `with` copies the list → it copies the reference, so the list is shared.
  - Tests: names not `TST-9`, no AAA sections, two behaviours in one test, a misleading name ("StructVsClass" for a record test), `Console.WriteLine` in tests, a symptom asserted instead of the cause → all fixed.
  - `public int _value` field (breaks `NAM-1`) hidden behind a CA1051 pragma → a property, no pragma.
  - Per-project `xunit.runner.json` left in the new project → removed (the shared file applies).
- **Best practices introduced:** `Assert.Same`/`NotSame` for identity questions; "equal is not the same as same"; document compile-time behaviour with the exact `CSxxxx` code; scope analyzer overrides per folder with `.editorconfig`; strongly typed IDs; `LNG-5` (no mutable structs outside teaching code).
- **Status changes:** P1.1 `NOT STARTED` → `IN PROGRESS`. Three struggles resolved (§6.3): `global.json` minimum, value vs reference copy, records/`with`.
- **Open items carried over:**
  - Did another assistant session co-author commits `ba8dca2`/`b987052`? This affects the logged hint level.
  - Merge `typesincsharp` into `main`.
  - Minor P1.6 polish (redundant `'$(MSBuildProjectName)' != ''` guard).
  - Optional ADR `0002`.
  - `insert_final_newline` resolved: it was not deliberate and was switched to `true` in `b9a07d2`.
- **Next exercise:** `P1.1-E2` Model the M1 domain types (see §9).

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
