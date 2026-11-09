namespace WorkflowPlatform.Learning.Tests;

public struct Counter { public int Value { get; set; } }
public class WorkflowStep { public string Name { get; set; } = ""; }
public class AuditClass { public string Actor { get; init; } = ""; }
public record AuditRecord(string Actor);
public record Definition(string Name, List<string> Steps);
public readonly record struct InstanceId(Guid Value);
public readonly record struct DefinitionId(Guid Value);
public class Transition
{
    public required string From { get; init; }
    public required string To { get; init; }
}
