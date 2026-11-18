namespace WorkflowPlatform.Learning.Tests;

public interface INotifier { string Send(); }

public class EmailNotifier : INotifier
{
    public virtual string Send() => "email";
#pragma warning disable CA1822 // Mark members as static
    public string Describe() => "basic";
#pragma warning restore CA1822 // Mark members as static
}

public class EscalationNotifier : EmailNotifier
{
    public override string Send() => "escalation";
#pragma warning disable CA1822 // Mark members as static
    public new string Describe() => "urgent";
#pragma warning restore CA1822 // Mark members as static
}

public class AuditedNotifier : EscalationNotifier
{
    public new virtual string Send() => "audited";
}

public class AuditedNotifier2 : EscalationNotifier
{
#pragma warning disable CA1822 // Mark members as static
    public new string Send() => "audited";
#pragma warning restore CA1822 // Mark members as static
}

public class LoggedNotifier : EscalationNotifier, INotifier
{
    public new string Send() => "logged";
}

public class LoggedNotifier2 : EscalationNotifier, INotifier
{
    public new virtual string Send() => "logged";
}

public abstract class StepHandler
{
    protected StepHandler() { Label = BuildLabel(); }
    public string Label { get; }
    protected abstract string BuildLabel();
}

public sealed class ApprovalHandler : StepHandler
{
    private readonly string _approver;
    public ApprovalHandler(string approver) { _approver = approver; }
    protected override string BuildLabel() => $"Approval by {_approver ?? "<null>"}";
}
