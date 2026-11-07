# Graph Report - enterprise-dotnet-learning  (2026-11-07)

## Corpus Check
- Corpus is ~14,756 words - fits in a single context window. You may not need a graph.

## Summary
- 201 nodes · 325 edges · 14 communities (10 shown, 4 thin omitted)
- Extraction: 88% EXTRACTED · 12% INFERRED · 0% AMBIGUOUS · INFERRED: 40 edges (avg confidence: 0.86)
- Token cost: 93,875 input · 0 output

## Community Hubs (Navigation)
- Domain Model & Business Rules
- Learning Log & Struggles
- Persistence & Messaging
- Standards, Docs & Git
- Async, DI & Runtime
- Mentor Instructions & Roadmap
- Web API & Authorization
- Platform Vision & Architecture
- Testing & Quality
- Cloud & Security
- Build Configuration Rules
- Placeholder Test Code
- Test Project & Solution
- xUnit Runner Config

## God Nodes (most connected - your core abstractions)
1. `M1 In-memory console engine` - 14 edges
2. `Domain glossary (ubiquitous language)` - 13 edges
3. `CLAUDE.md (AI mentor instructions)` - 10 edges
4. `ADR 0001: Record architecture decisions` - 9 edges
5. `Phase 1: C# and .NET Fundamentals` - 9 edges
6. `Phase 3: ASP.NET Core Backend` - 9 edges
7. `Phase 4: Database and Persistence` - 9 edges
8. `Phase 5: Enterprise Architecture` - 9 edges
9. `Phase 6: Testing and Quality` - 9 edges
10. `Phase 7: Enterprise Infrastructure` - 9 edges

## Surprising Connections (you probably didn't know these)
- `ADR 0001: Record architecture decisions` --rationale_for--> `Rule levels MUST / SHOULD / CHOICE`  [EXTRACTED]
  docs/adr/0001-record-architecture-decisions.md → CODING_STANDARDS.md
- `ADR 0001: Record architecture decisions` --references--> `M5 Architecture refactor`  [EXTRACTED]
  docs/adr/0001-record-architecture-decisions.md → PROJECT_SPEC.md
- `ADR 0001: Record architecture decisions` --references--> `Design choices register`  [EXTRACTED]
  docs/adr/0001-record-architecture-decisions.md → CODING_STANDARDS.md
- `ADR 0001: Record architecture decisions` --implements--> `DOC-2 Every CHOICE recorded as ADR`  [EXTRACTED]
  docs/adr/0001-record-architecture-decisions.md → CODING_STANDARDS.md
- `ADR 0001: Record architecture decisions` --references--> `ADR template`  [EXTRACTED]
  docs/adr/0001-record-architecture-decisions.md → PROJECT_SPEC.md

## Import Cycles
- None detected.

## Hyperedges (group relationships)
- **Business-rule enforcement across spec, standards and tests** — project_spec_br_09, coding_standards_dat_5, coding_standards_tst_1, project_spec_m4, project_spec_m6 [INFERRED 0.85]
- **CHOICE decisions recorded via ADRs** — coding_standards_rule_levels, coding_standards_design_choices_register, coding_standards_doc_2, docs_adr_0001_record_architecture_decisions, project_spec_adr_template, project_spec_technology_decisions [EXTRACTED 1.00]
- **P1.6 mastery path** — roadmap_p1_6, learning_log_m0_e1_repository_foundation, learning_log_p1_6_e1b_msbuild_import_order, learning_log_p1_6_e2_layered_build_configuration, learning_log_struggle_directory_build_props_import, learning_log_struggle_property_evaluation_order, learning_log_session_3_plan [EXTRACTED 1.00]

## Communities (14 total, 4 thin omitted)

### Community 0 - "Domain Model & Business Rules"
Cohesion: 0.10
Nodes (17): Action, Audit Entry, Definition Version, Domain glossary (ubiquitous language), M1 In-memory console engine, M4 SQL Server persistence, M6 Quality and test hardening, M7 Distributed infrastructure (+9 more)

### Community 1 - "Learning Log & Struggles"
Cohesion: 0.13
Nodes (18): Session 1 calibration diagnostic, Current snapshot (Phase 1, P1.6 in progress, M0 complete), Exercise P1.6-E1b MSBuild import-order experiment, Exercise P1.6-E2 Layered build configuration, Session 3 plan: finish P1.6, Struggle: deferred execution + closures, Struggle: Directory.Build.props import rule, Struggle: NRT guarantees (+10 more)

### Community 2 - "Persistence & Messaging"
Cohesion: 0.10
Nodes (17): Transactional outbox, P4.1 SQL Server, joins, indexes, transactions, P4.2 Entity Framework Core, P4.3 Code-first migrations, P4.4 LINQ to Entities, P4.5 Repository patterns and trade-offs, P4.6 Query optimization and N+1, P4.7 Dapper and raw SQL (+9 more)

### Community 3 - "Standards, Docs & Git"
Cohesion: 0.16
Nodes (7): Design choices register, ADR 0001: Record architecture decisions, Michael Nygard lightweight ADR format, Exercise M0-E1 Repository foundation, ADR template, M0 Repository foundation, Technology decisions table

### Community 4 - "Async, DI & Runtime"
Cohesion: 0.15
Nodes (10): Struggle: async void and sync-over-async, Struggle: captive dependencies, M2 Hosted, async console engine, P2.1 Async/await, Task, cancellation tokens, P2.2 Threading, concurrency, synchronization, P2.3 Memory, GC, IDisposable, P2.4 Reflection, attributes, expression trees, P2.5 Dependency injection and configuration (+2 more)

### Community 5 - "Mentor Instructions & Roadmap"
Cohesion: 0.17
Nodes (5): CLAUDE.md (AI mentor instructions), Technical Stack (.NET, ASP.NET Core, EF Core, SQL Server, xUnit, Docker, Redis, RabbitMQ, Kafka, OpenTelemetry, Azure/AWS, GitHub Actions), Documentation index, Getting started (dotnet build/test/format), Contributor workflow

### Community 6 - "Web API & Authorization"
Cohesion: 0.16
Nodes (10): Assignee, M3 Web API, P3.1 HTTP, REST, status codes, P3.2 Minimal APIs and Controllers, P3.3 Middleware and request pipeline, P3.4 Routing, model binding, validation, P3.5 Authentication and authorization, P3.6 Filters, exception handling, API versioning (+2 more)

### Community 7 - "Platform Vision & Architecture"
Cohesion: 0.15
Nodes (14): Employee Onboarding workflow, Expense Approval workflow, Incident Management workflow, M5 Architecture refactor, Modular monolith modules (Definitions, Execution, Notifications), Workflow Automation Platform (WAP), P5.1 SOLID principles, P5.2 Design patterns (+6 more)

### Community 8 - "Testing & Quality"
Cohesion: 0.18
Nodes (8): P6.1 xUnit, P6.2 Unit and integration testing, P6.3 Mocking with NSubstitute or Moq, P6.4 WebApplicationFactory, P6.5 Testcontainers, P6.6 Code coverage and static analysis, P6.7 Refactoring and maintainability, Phase 6: Testing and Quality

### Community 9 - "Cloud & Security"
Cohesion: 0.18
Nodes (9): M8 Production deployment, P8.1 Azure or AWS deployment, P8.2 CI/CD with GitHub Actions, P8.3 Secrets management, P8.4 Infrastructure as Code, P8.5 Application monitoring, P8.6 Security and performance, P8.7 System design and scalability (+1 more)

## Knowledge Gaps
- **47 isolated node(s):** `xunit.v3.mtp-v2`, `Microsoft.NET.Sdk`, `P1.2 OOP, interfaces, inheritance, polymorphism`, `P2.2 Threading, concurrency, synchronization`, `P2.4 Reflection, attributes, expression trees` (+42 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 68 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **4 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Phase 5: Enterprise Architecture` connect `Platform Vision & Architecture` to `Mentor Instructions & Roadmap`?**
  _High betweenness centrality (0.068) - this node is a cross-community bridge._
- **What connects `xunit.v3.mtp-v2`, `Microsoft.NET.Sdk`, `P1.2 OOP, interfaces, inheritance, polymorphism` to the rest of the system?**
  _47 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Domain Model & Business Rules` be split into smaller, more focused modules?**
  _Cohesion score 0.10080645161290322 - nodes in this community are weakly interconnected._
- **Why does `Phase 7: Enterprise Infrastructure` connect `Persistence & Messaging` to `Domain Model & Business Rules`, `Mentor Instructions & Roadmap`?**
  _High betweenness centrality (0.066) - this node is a cross-community bridge._
- **Should `Learning Log & Struggles` be split into smaller, more focused modules?**
  _Cohesion score 0.12666666666666668 - nodes in this community are weakly interconnected._
- **Why does `Domain glossary (ubiquitous language)` connect `Domain Model & Business Rules` to `Standards, Docs & Git`, `Web API & Authorization`?**
  _High betweenness centrality (0.065) - this node is a cross-community bridge._
- **Should `Persistence & Messaging` be split into smaller, more focused modules?**
  _Cohesion score 0.09523809523809523 - nodes in this community are weakly interconnected._