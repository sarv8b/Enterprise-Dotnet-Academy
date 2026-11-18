namespace WorkflowPlatform.Learning.Tests;

// P1.2-E1 Part B: prove the Part A predictions.
// For each test: write your prediction + confidence label first, commit, then implement and run.
// Each test fails with Assert.Fail until you replace the body.

public class ObjectResolutionTests
{
    // ---------------------------------------------------------------
    // Q1: static type EmailNotifier, runtime type EscalationNotifier
    // ---------------------------------------------------------------

    [Fact]
    public void Send_EscalationNotifierViaEmailNotifierVariable_ReturnsEscalation()
    {
        // Prediction: escalation (H)
        EmailNotifier n = new EscalationNotifier();
        Assert.Equal("escalation", n.Send());
    }

    [Fact]
    public void Describe_EscalationNotifierViaEmailNotifierVariable_ReturnsBasic()
    {
        // Prediction: basic (H)
        EmailNotifier n = new EscalationNotifier();
        Assert.Equal("basic", n.Describe());
    }

    // ---------------------------------------------------------------
    // Q2: hidden (non-virtual) Describe, called through two static types
    // ---------------------------------------------------------------

    [Fact]
    public void Describe_EscalationNotifierViaOwnType_ReturnsUrgent()
    {
        // Prediction: urgent (H)
        var n = new EscalationNotifier();
        Assert.Equal("urgent", n.Describe());
    }

    [Fact]
    public void Describe_EscalationNotifierCastToEmailNotifier_ReturnsBasic()
    {
        // Prediction: basic (H)
        var n = (EmailNotifier)new EscalationNotifier();
        Assert.Equal("basic", n.Describe());
    }

    // ---------------------------------------------------------------
    // Q3: AuditedNotifier, `new virtual` Send (a new slot)
    // ---------------------------------------------------------------

    [Fact]
    public void Send_AuditedNotifierViaOwnType_ReturnsAudited()
    {
        // Prediction: audited (H)
        var n = new AuditedNotifier();
        Assert.Equal("audited", n.Send());
    }

    [Fact]
    public void Send_AuditedNotifierCastToEscalationNotifier_ReturnsEscalation()
    {
        // Prediction: escalation (H)
        var n = (EscalationNotifier)new AuditedNotifier();
        Assert.Equal("escalation", n.Send());
    }

    [Fact]
    public void Send_AuditedNotifierViaInterface_ReturnsEscalation()
    {
        // Prediction: escalation (H)
#pragma warning disable CA1859 // Use concrete types when possible for improved performance
        var n = (INotifier)new AuditedNotifier();
#pragma warning restore CA1859 // Use concrete types when possible for improved performance
        Assert.Equal("escalation", n.Send());
    }

    // ---------------------------------------------------------------
    // Q4: LoggedNotifier re-declares INotifier (interface re-implementation)
    // ---------------------------------------------------------------

    [Fact]
    public void Send_LoggedNotifierViaInterface_ReturnsLogged()
    {
        // Prediction: logged (H)
#pragma warning disable CA1859 // Use concrete types when possible for improved performance
        var n = (INotifier)new LoggedNotifier();
#pragma warning restore CA1859 // Use concrete types when possible for improved performance
        Assert.Equal("logged", n.Send());
    }

    [Fact]
    public void Send_LoggedNotifierCastToEmailNotifier_ReturnsEscalation()
    {
        // Prediction: escalation (H)
        var n = (EmailNotifier)new LoggedNotifier();
        Assert.Equal("escalation", n.Send());
    }

    // ---------------------------------------------------------------
    // Contrast experiments: is `virtual` the cause? (separate small types, originals unchanged)
    // ---------------------------------------------------------------

    [Fact]
    public void Send_NonVirtualHidingMethodWithoutReimplementedInterface_ViaInterfaceReturnsEscalation()
    {
        // Contrast (i): like AuditedNotifier, but `public new string Send()` (no `virtual`).
        // Prediction: escalation (H)
#pragma warning disable CA1859 // Use concrete types when possible for improved performance
        var n = (INotifier)new AuditedNotifier2();
#pragma warning restore CA1859 // Use concrete types when possible for improved performance
        Assert.Equal("escalation", n.Send());
    }

    [Fact]
    public void Send_VirtualHidingMethodWithReimplementedInterface_ViaInterfaceReturnsLogged()
    {
        // Contrast (ii): like LoggedNotifier, but `public new virtual string Send()`.
        // Prediction: logged (H)
#pragma warning disable CA1859 // Use concrete types when possible for improved performance
        var n = (INotifier)new LoggedNotifier2();
#pragma warning restore CA1859 // Use concrete types when possible for improved performance
        Assert.Equal("logged", n.Send());
    }

    // ---------------------------------------------------------------
    // Q6: virtual call from a base constructor
    // ---------------------------------------------------------------

    [Fact]
    public void Label_BaseConstructorCallsOverride_DerivedFieldNotYetAssigned()
    {
        // Prediction: Approval by <null> (H)
        // Analyzer check: did any diagnostic flag the virtual call in StepHandler's constructor? ID: none 
        var label = new ApprovalHandler("Asha").Label;
        Assert.Equal("Approval by <null>", label);
    }

    // ---------------------------------------------------------------
    // Compile-time evidence (no tests; keep the offending code commented out)
    // ---------------------------------------------------------------

    // Q5: overriding a non-virtual member
    // Diagnostic ID: CS0506: 'ObjectResolutionTests.ReminderNotifier.Describe()': cannot override inherited member 'EscalationNotifier.Describe()' because it is not marked virtual, abstract, or override
    // public class ReminderNotifier : EscalationNotifier
    // {
    //     public override string Describe() => "reminder";
    // }

    // Q7b: temporarily remove `new` from EscalationNotifier.Describe, build, record, then restore it.
    // Diagnostic ID: CS0108: 'EscalationNotifier.Describe()' hides inherited member 'EmailNotifier.Describe()'. Use the new keyword if hiding was intended.
    // Runtime behaviour without `new`: same, no difference
    // What `new` communicates, and to whom: new tells the compiler to stop giving warnings about hiding, and tells the reader that the author intended to hide the base member. It does not change runtime behaviour.
}
