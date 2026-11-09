namespace WorkflowPlatform.Learning.Tests;

#pragma warning disable CA1051 // Do not declare visible instance fields
public struct Counter { public int _value; }
#pragma warning restore CA1051 // Do not declare visible instance fields
public class Step1 { public string Name { get; set; } = ""; }
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
