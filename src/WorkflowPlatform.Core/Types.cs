namespace WorkflowPlatform.Core;
//WorkflowDefinition       │ id, name, version, steps, transitions
using System.Collections.Immutable;

public sealed class WorkflowDefinition
{
    public DefinitionId Id { get; }
    public string Name { get; }
    public int Version { get; }
    public IImmutableList<WorkflowStep> Steps { get; }
    public IImmutableList<Transition> Transitions { get; }

    public WorkflowDefinition(DefinitionId id, string name, int version, IEnumerable<WorkflowStep> steps, IEnumerable<Transition> transitions)
    {
        Id = id;
        Name = name;
        Version = version;
        Steps = steps.ToImmutableList();
        Transitions = transitions.ToImmutableList();
    }

    public override bool Equals(object? obj) => Equals(obj as WorkflowDefinition);
    public bool Equals(WorkflowDefinition? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return EqualityComparer<DefinitionId>.Default.Equals(Id, other.Id) &&
            Version == other.Version;
    }

    public override int GetHashCode() => HashCode.Combine(Id, Version);

    public static bool operator ==(WorkflowDefinition? left, WorkflowDefinition? right) => Equals(left, right);
    public static bool operator !=(WorkflowDefinition? left, WorkflowDefinition? right) => !Equals(left, right);

}

//Step                     │ name, kind
public sealed record WorkflowStep(string Name, StepKind Kind);

//StepKind                 │ Start, ManualTask, Approval, AutomatedAction, Decision, End
public enum StepKind
{
    Start,
    ManualTask,
    Approval,
    AutomatedAction,
    Decision,
    End
}

// Transition               │ name, from step, to step
public sealed record Transition(string Name, WorkflowStep FromStep, WorkflowStep ToStep);

//AuditEntry               │ actor, action, from step, to step, timestamp (UTC), optional comment
public record AuditEntry
{
    public string Actor { get; }
    public string Action { get; }
    public WorkflowStep FromStep { get; }
    public WorkflowStep ToStep { get; }
    public DateTimeOffset TimestampUtc { get; }
    public string? Comment { get; }

    public AuditEntry(string actor, string action, WorkflowStep fromStep, WorkflowStep toStep, DateTimeOffset timestampUtc, string? comment = null)
    {
        Actor = actor;
        Action = action;
        FromStep = fromStep;
        ToStep = toStep;
        TimestampUtc = timestampUtc.ToUniversalTime();
        Comment = comment;
    }
}

public readonly record struct DefinitionId(Guid Value)
{
    public static DefinitionId NewId() => new DefinitionId(Guid.NewGuid());
}

public readonly record struct InstanceId(Guid Value)
{
    public static InstanceId NewId() => new InstanceId(Guid.NewGuid());
}

//WorkflowInstance         │ id, the definition it runs, current step
public sealed class WorkflowInstance
{
    public InstanceId Id { get; }
    public WorkflowDefinition Definition { get; }
    public WorkflowStep CurrentStep { get; private set; }
    public IImmutableList<AuditEntry> AuditTrail { get; private set; }

    public WorkflowInstance(InstanceId id, WorkflowDefinition definition, WorkflowStep currentStep, IEnumerable<AuditEntry> auditTrail)
    {
        Id = id;
        Definition = definition;
        CurrentStep = currentStep;
        AuditTrail = auditTrail.ToImmutableList();
    }

    public void MoveToNextStep(WorkflowStep nextStep, string actor, string action, string? comment = null)
    {
        var auditEntry = new AuditEntry(actor, action, CurrentStep, nextStep, DateTimeOffset.UtcNow, comment);
        CurrentStep = nextStep;
        var list = AuditTrail.Add(auditEntry);
        AuditTrail = list;
    }

    public override bool Equals(object? obj) => Equals(obj as WorkflowInstance);

    public bool Equals(WorkflowInstance? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return EqualityComparer<InstanceId>.Default.Equals(Id, other.Id);
    }

    public override int GetHashCode() => EqualityComparer<InstanceId>.Default.GetHashCode(Id);

    public static bool operator ==(WorkflowInstance? left, WorkflowInstance? right) => Equals(left, right);
    public static bool operator !=(WorkflowInstance? left, WorkflowInstance? right) => !Equals(left, right);
}
