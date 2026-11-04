# 0001. Record architecture decisions

- Status: Accepted
- Date: 2026-11-04
- Milestone: M0

## Context

The Workflow Automation Platform grows over nine milestones. It starts as an in-memory console app (M1) and ends as a cloud-deployed distributed system (M8). Many design questions along the way have more than one reasonable answer. `CODING_STANDARDS.md` marks these as **CHOICE** items, and §16 lists them: solution format, endpoint style, validation, expected-failure handling, data access abstraction, architecture style, mediator, mocking library, messaging library, cloud provider, IaC tool, and others.

Forces at play:

- **Early decisions constrain later milestones.** At M5 the codebase is deliberately refactored. To do that well we need to know why things were built as they are and which assumptions no longer hold.
- **Code shows *what*, never *why*.** It does not record the alternatives that were rejected. Without a record, the reasoning lives only in chat history and memory.
- **CHOICE items must be applied consistently.** Reviews never flag them as mistakes, but they must not contradict what was agreed. Reviewers need one place to check that.
- **This is a learning project.** Writing down options and trade-offs is a core senior-engineer skill, so the record is part of the practice, not overhead around it.
- **There is a single developer.** Any process must stay lightweight or it will not be followed.

## Options considered

1. **No formal record.** Rely on commit messages, code comments, and session notes.
   - Pros: no overhead.
   - Cons: rationale is scattered and hard to find. Rejected alternatives are lost. There is no way to tell whether a decision is still current. A commit message describes one change, not a decision that spans many changes.

2. **External wiki or document** (Confluence, Notion, Google Docs).
   - Pros: rich editing; easy to share with non-developers.
   - Cons: drifts away from the code. It is not versioned with the commit that implements the decision, and it is not reviewed in the same change. It adds another tool to maintain.

3. **Architecture Decision Records (ADRs) as Markdown files in the repository**, in the lightweight format popularised by Michael Nygard.
   - Pros: versioned alongside the code and reviewed in the same change. Plain text, diffable, and readable on GitHub. The append-only history shows how the thinking evolved.
   - Cons: needs discipline to write and to keep current. Each decision carries a small amount of ceremony. There is a risk of writing ADRs for trivial choices, which buries the important ones.

## Decision

We choose **option 3**. Architecturally significant decisions are recorded as ADRs in `docs/adr/`, using the template in `PROJECT_SPEC.md` §12.

Conventions:

- **File name:** `NNNN-short-title-in-kebab-case.md`. Numbers are four digits, sequential, and never reused.
- **When to write one:**
  - every **CHOICE** item in `CODING_STANDARDS.md`, at the milestone where it first matters (see §16);
  - any other decision that is expensive to reverse, affects more than one project or module, or would make a future reader ask "why was it done this way?".
- **When not to write one:** for anything already fixed by a MUST or SHOULD rule, and for local implementation details that can be changed in a single commit.
- **Status lifecycle:** `Proposed` while under discussion → `Accepted` when merged → `Superseded by NNNN` when replaced.
- **Immutability:** once accepted, an ADR's body is not rewritten. To change a decision, write a new ADR and set the old one's status to `Superseded by NNNN`. That status line (and typo fixes) are the only edits allowed to an accepted ADR.
- **Same change as the code:** an ADR is committed on the same branch as the code that implements it.
- **Honest options:** every ADR lists at least two real options, and states the cons of the chosen one.
- **Length:** aim for one page. If it needs more, the decision is probably several decisions.

## Consequences

**Easier**

- Code review: a CHOICE finding can be checked against an accepted ADR. A deviation is either a bug or a reason to write a new ADR.
- The M5 refactor: pain points can be traced to the decisions behind them and to the assumptions that turned out wrong.
- Explaining the project to others (reviewers, interviewers) using written trade-off reasoning instead of recollection.

**Harder**

- Each significant decision costs some writing time.
- Changing direction requires writing a superseding ADR rather than silently diverging.

**Watch for**

- Code that contradicts an accepted ADR without a superseding one. Treat this as a review finding (`DOC-2`).
- ADRs written for trivial choices, which dilute the important ones.
- ADRs left in `Proposed`. Accept or delete them before a milestone is marked complete.
