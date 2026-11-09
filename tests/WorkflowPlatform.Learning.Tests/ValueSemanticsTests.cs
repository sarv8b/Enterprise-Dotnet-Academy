namespace WorkflowPlatform.Learning.Tests;

public class ValueSemanticsTests
{
    [Fact]
    public void ListIndexer_StructElementCopiedToLocal_ListElementUnchanged()
    {
        // Arrange
        var counters = new List<Counter> { new Counter() };

        // Act
        var c = counters[0];
        c.Value = 5;

        // Assert
        Assert.Equal(0, counters[0].Value);

        // CS1612: Cannot modify the return value of 'List<Counter>.this[int]' because it is not a variable.
        // The indexer returns a copy of the struct, so mutating it in place would be silently lost.
        // counters[0].Value = 5;
    }

    private static void Rename(WorkflowStep s)
    {
        s.Name = "Triage";
        s = new WorkflowStep { Name = "Closed" };
    }

    [Fact]
    public void Rename_ParameterReassignedToNewObject_CallerSeesMutationButNotReassignment()
    {
        // Arrange
        var step = new WorkflowStep { Name = "Reported" };

        // Act
        Rename(step);

        // Assert
        Assert.Equal("Triage", step.Name);
    }

    [Fact]
    public void EqualityOperator_ClassesWithSameValues_ReturnsFalse()
    {
        // Arrange
        var a = new AuditClass { Actor = "ana" };
        var b = new AuditClass { Actor = "ana" };

        // Act
        var areEqual = a == b;

        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void EqualityOperator_RecordsWithSameValues_ReturnsTrue()
    {
        // Arrange
        var a = new AuditRecord("ana");
        var b = new AuditRecord("ana");

        // Act
        var areEqual = a == b;

        // Assert
        Assert.True(areEqual);
    }

    [Fact]
    public void WithExpression_RecordWithListProperty_SharesSameListInstance()
    {
        // Arrange
        var v1 = new Definition("Incident", ["Reported", "Triage"]);

        // Act
        var v2 = v1 with { Name = "Incident v2" };

        // Assert
        Assert.NotSame(v1, v2);
        Assert.Same(v1.Steps, v2.Steps);
    }

    [Fact]
    public void WithExpression_ChangedName_CopyIsNotEqualToOriginal()
    {
        // Arrange
        var v1 = new Definition("Incident", ["Reported", "Triage"]);

        // Act
        var v2 = v1 with { Name = "Incident v2" };

        // Assert
        Assert.False(v1 == v2);
    }

    [Fact]
    public void WithExpression_NoChanges_CopyIsEqualToOriginal()
    {
        // Arrange
        var v1 = new Definition("Incident", ["Reported", "Triage"]);

        // Act
        var v3 = v1 with { };

        // Assert
        Assert.True(v1 == v3);
    }

    [Fact]
    public void WithExpression_NoChanges_CopyIsDifferentInstance()
    {
        // Arrange
        var v1 = new Definition("Incident", ["Reported", "Triage"]);

        // Act
        var v3 = v1 with { };

        // Assert
        Assert.False(ReferenceEquals(v1, v3));
    }

    [Fact]
    public void EqualityOperator_RecordsWithDistinctListsOfSameContents_ReturnsFalse()
    {
        // Arrange
        var v1 = new Definition("Incident", ["Reported", "Triage"]);
        var v2 = new Definition("Incident", ["Reported", "Triage"]);

        // Act
        var areEqual = v1 == v2;

        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void Equals_StronglyTypedIdsWrappingSameGuid_ReturnsTrue()
    {
        // Arrange
        var g = Guid.NewGuid();

        // Act
        var a = new InstanceId(g);
        var b = new InstanceId(g);

        // Assert
        Assert.Equal(a, b);
    }

    // CS1503: InstanceId and DefinitionId are distinct types, so mixing them up is a compile-time error.
    // public void Cancel_DefinitionIdPassedAsInstanceId_DoesNotCompile()
    // {
    //     var g = Guid.NewGuid();
    //     static void Cancel(InstanceId id) { }
    //     Cancel(new DefinitionId(g));
    // }

    [Fact]
    public void ObjectInitializer_AllRequiredPropertiesSet_PropertiesAssigned()
    {
        // Arrange / Act
        var t = new Transition { From = "Reported", To = "Triage" };

        // CS9035: Required member 'Transition.To' must be set in the object initializer.
        // var missing = new Transition { From = "Reported" };

        // CS8852: Init-only property can only be assigned in an object initializer.
        // t.To = "Closed";

        // Assert
        Assert.Equal("Reported", t.From);
        Assert.Equal("Triage", t.To);
    }
}
