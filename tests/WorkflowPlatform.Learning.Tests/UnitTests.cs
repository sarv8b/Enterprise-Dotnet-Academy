namespace WorkflowPlatform.Learning.Tests;

public class UnitTests
{
    [Fact]
    public void StructInsideListCopiesValue()
    {
        var counters = new List<Counter> { new Counter() };
        var c = counters[0];
        c._value = 5;
        Assert.Equal(0, counters[0]._value);
        //CS1612: Cannot modify the return value of 'List<Counter>.this[int]' because it is not a variable. counters[0] when assigned to a variable is a copy of the value in the list, not a reference to it.
        //counters[0]._value = 5;
    }

    static void Rename(Step1 s)
    {
        s.Name = "Triage";
        s = new Step1 { Name = "Closed" };
    }

    [Fact]
    public void MethodLocalVariableIsNotReferenceToOriginalObject()
    {
        var step = new Step1 { Name = "Reported" };
        Rename(step);
        Console.WriteLine(step.Name);
        Assert.Equal("Triage", step.Name);
    }

    [Fact]
    public void ReferenceEqualityVsValueEqualityStructVsClass()
    {
        Assert.False(new AuditClass { Actor = "ana" } == new AuditClass { Actor = "ana" });
        Assert.True(new AuditRecord("ana") == new AuditRecord("ana"));
    }

    [Fact]
    public void WithExpressionCreatesNewRecordObjectWithShallowCopy()
    {
        var v1 = new Definition("Incident", ["Reported", "Triage"]);
        var v2 = v1 with { Name = "Incident v2" };
        v2.Steps.Add("Closed");
        Assert.Equal(3, v1.Steps.Count);
        Assert.NotSame(v1, v2);

    }

    [Fact]
    public void WithExpressionCreatesNewRecordObjectWithShallowCopyValueEquality()
    {
        var v1 = new Definition("Incident", ["Reported", "Triage"]);
        var v3 = v1 with { };
        Console.WriteLine(v1 == v3);
        Assert.True(v1 == v3);
    }

    [Fact]
    public void RecordsWithEqualListContentsAreNotEqual()
    {
        var v1 = new Definition("Incident", ["Reported", "Triage"]);
        var v2 = new Definition("Incident", ["Reported", "Triage"]);
        Assert.False(v1 == v2);
    }

    [Fact]
    public void StronglyTypedGuidsAreEqualIfTheyHaveTheSameValue()
    {
        var g = Guid.NewGuid();
        Assert.Equal(new InstanceId(g), new InstanceId(g));
    }

    // CS1503: Types do not match, therefore it gives compile time error.
    // public void WrappingTypesMakesReferencesDifferent()
    // {
    //     var g = Guid.NewGuid();
    //     static void Cancel(InstanceId id) { }
    //     Cancel(new DefinitionId(g));
    // }

    [Fact]
    public void RequiredInitPropertiesMustBeSet()
    {
        var u = new Transition { From = "Reported", To = "Triage" };
        //CS9035: Something marked required must be set in the object initializer. 'To' must be set.
        //var t = new Transition { From = "Reported" };

        //CS8852: Init-only property can not be directly assigned using assignment operators. Use an object initializer instead.
        //u.To = "Closed";
        Assert.Equal("Reported", u.From);
        Assert.Equal("Triage", u.To);
    }
}
