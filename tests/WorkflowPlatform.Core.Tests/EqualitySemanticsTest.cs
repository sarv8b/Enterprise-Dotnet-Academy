namespace WorkflowPlatform.Core.Tests;

using System.Collections.Immutable;

using WorkflowPlatform.Core;

public class EqualitySemanticsTest
{
    //CS8858 The receiver type 'WorkflowDefinition' is not a valid record type and is not a struct type.
    //[Fact]
    // public void WithCopyOfDefinition_CannotAffectOriginalsSteps_ReturnsFalseOnComparison()
    // {
    //     var definition = new WorkflowDefinition(
    //         DefinitionId.NewId(),
    //         "Sample Workflow",
    //         1,
    //         ImmutableList.Create<WorkflowStep>(
    //             new WorkflowStep("Start", StepKind.Start),
    //             new WorkflowStep("Task", StepKind.ManualTask),
    //             new WorkflowStep("End", StepKind.End)
    //         ),
    //         ImmutableList.Create<Transition>
    //         (
    //             new Transition("StartToTask", new WorkflowStep("Start", StepKind.Start), new WorkflowStep("Task", StepKind.ManualTask)),
    //             new Transition("TaskToEnd", new WorkflowStep("Task", StepKind.ManualTask), new WorkflowStep("End", StepKind.End))
    //     )
    //     );
    //     var definition2 = definition with { Steps = new List<WorkflowStep>(definition.Steps) };
    // }

    [Fact]
    public void AuditEntry_CannotChangePropertiesAfterCreation_AreReadonly()
    {
        var step1 = new WorkflowStep("Start", StepKind.Start);
        var step2 = new WorkflowStep("End", StepKind.End);
        var entry = new AuditEntry("user1", "action1", step1, step2, DateTimeOffset.UtcNow);

        // Assert that properties are read-only
        Assert.Equal("user1", entry.Actor);
        Assert.Equal("action1", entry.Action);
        Assert.Equal(step1, entry.FromStep);
        Assert.Equal(step2, entry.ToStep);

        // The following lines would cause compilation errors if uncommented
        //CS0200: Property or indexer 'AuditEntry.Action' cannot be assigned to -- it is read only
        // entry.Actor = "user2"; // Cannot assign to 'Actor' because it is read-only
        // entry.Action = "action2"; // Cannot assign to 'Action' because it is read-only
    }

    [Fact]
    public void MoveToNextStep_ValidStep_AppendsOneAuditEntry()
    {
        // Arrange
        var step1 = new WorkflowStep("Start", StepKind.Start);
        var step2 = new WorkflowStep("End", StepKind.End);

        var workflowInstance = new WorkflowInstance(
            InstanceId.NewId(),
            new WorkflowDefinition(
                DefinitionId.NewId(),
                "Sample Workflow",
                1,
                ImmutableList.Create(step1, step2),
                ImmutableList.Create(new Transition("StartToEnd", step1, step2))
            ),
            step1,
            ImmutableList<AuditEntry>.Empty
        );

        // Act
        workflowInstance.MoveToNextStep(step2, "user1", "action1");

        // Assert
        Assert.Single(workflowInstance.AuditTrail);
        var auditEntry = workflowInstance.AuditTrail[0];
        Assert.Equal("user1", auditEntry.Actor);
        Assert.Equal("action1", auditEntry.Action);
        Assert.Equal(step1, auditEntry.FromStep);
        Assert.Equal(step2, auditEntry.ToStep);
    }

    [Fact]
    public void WorkflowDefinition_OriginalListChangedAfterConstruction_DoesNotAffectDefinition()
    {
        // Arrange
        var steps = new List<WorkflowStep>
        {
            new WorkflowStep("Start", StepKind.Start),
            new WorkflowStep("Task", StepKind.ManualTask),
            new WorkflowStep("End", StepKind.End)
        };

        var transitions = new List<Transition>
        {
            new Transition("StartToTask", steps[0], steps[1]),
            new Transition("TaskToEnd", steps[1], steps[2])
        };

        var definition = new WorkflowDefinition(
            DefinitionId.NewId(),
            "Sample Workflow",
            1,
            steps,
            transitions
        );

        // Act
        steps.Add(new WorkflowStep("ExtraStep", StepKind.ManualTask));
        transitions.Add(new Transition("ExtraTransition", steps[2], steps[3]));

        // Assert
        Assert.Equal(3, definition.Steps.Count);
        Assert.Equal(2, definition.Transitions.Count);
    }

    [Fact]
    public void WorkflowDefinition_EqualityBasedOnIdAndVersion_ReturnsTrueForSameIdAndVersion()
    {
        // Arrange
        var id = DefinitionId.NewId();
        var steps = new List<WorkflowStep>
        {
            new WorkflowStep("Start", StepKind.Start),
            new WorkflowStep("Task", StepKind.ManualTask),
            new WorkflowStep("End", StepKind.End)
        };

        var transitions = new List<Transition>
        {
            new Transition("StartToTask", steps[0], steps[1]),
            new Transition("TaskToEnd", steps[1], steps[2])
        };

        var definition1 = new WorkflowDefinition(
            id,
            "Sample Workflow",
            1,
            steps,
            transitions
        );

        var definition2 = new WorkflowDefinition(
            id,
            "Sample Workflow",
            1,
            steps,
            transitions
        );

        // Act
        var areEqual = definition1.Equals(definition2);

        // Assert
        Assert.True(areEqual);
    }

    [Fact]
    public void WorkflowDefinition_SameIdAndVersion_DifferentSteps_ReturnsTrue()
    {
        // Arrange
        var id = DefinitionId.NewId();
        var steps1 = new List<WorkflowStep>
        {
            new WorkflowStep("Start", StepKind.Start),
            new WorkflowStep("Task", StepKind.ManualTask),
            new WorkflowStep("End", StepKind.End)
        };

        var steps2 = new List<WorkflowStep>
        {
            new WorkflowStep("Start", StepKind.Start),
            new WorkflowStep("DifferentTask", StepKind.ManualTask),
            new WorkflowStep("End", StepKind.End)
        };

        var transitions = new List<Transition>
        {
            new Transition("StartToTask", steps1[0], steps1[1]),
            new Transition("TaskToEnd", steps1[1], steps1[2])
        };

        var definition1 = new WorkflowDefinition(
            id,
            "Sample Workflow",
            1,
            steps1,
            transitions
        );

        var definition2 = new WorkflowDefinition(
            id,
            "Sample Workflow",
            1,
            steps2,
            transitions
        );

        // Act
        var areEqual = definition1.Equals(definition2);

        // Assert
        Assert.True(areEqual);
    }

    [Fact]
    public void WorkflowDefinition_DifferentVersion_ReturnsFalse()
    {
        // Arrange
        var id = DefinitionId.NewId();
        var steps = new List<WorkflowStep>
        {
            new WorkflowStep("Start", StepKind.Start),
            new WorkflowStep("Task", StepKind.ManualTask),
            new WorkflowStep("End", StepKind.End)
        };

        var transitions = new List<Transition>
        {
            new Transition("StartToTask", steps[0], steps[1]),
            new Transition("TaskToEnd", steps[1], steps[2])
        };

        var definition1 = new WorkflowDefinition(
            id,
            "Sample Workflow",
            1,
            steps,
            transitions
        );

        var definition2 = new WorkflowDefinition(
            id,
            "Sample Workflow",
            2, // Different version
            steps,
            transitions
        );

        // Act
        var areEqual = definition1.Equals(definition2);

        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void WorkflowDefinition_EqualObjects_HaveEqualHashCodes()
    {
        // Arrange
        var id = DefinitionId.NewId();
        var steps = new List<WorkflowStep>
        {
            new WorkflowStep("Start", StepKind.Start),
            new WorkflowStep("Task", StepKind.ManualTask),
            new WorkflowStep("End", StepKind.End)
        };

        var transitions = new List<Transition>
        {
            new Transition("StartToTask", steps[0], steps[1]),
            new Transition("TaskToEnd", steps[1], steps[2])
        };

        var definition1 = new WorkflowDefinition(
            id,
            "Sample Workflow",
            1,
            steps,
            transitions
        );

        var definition2 = new WorkflowDefinition(
            id,
            "Sample Workflow",
            1,
            steps,
            transitions
        );

        // Act
        var hashCode1 = definition1.GetHashCode();
        var hashCode2 = definition2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }

    [Fact]
    public void InstanceIdAndDefinitionId_AreDistinctTypes_ReferencesNotEqual()
    {
        // Arrange
        var g = Guid.NewGuid();

        // Act
        var instanceId = new InstanceId(g);
        var definitionId = new DefinitionId(g);

        // Assert
        Assert.NotEqual<object>(instanceId, definitionId);

        // The following line would cause a compile-time error if uncommented
        //CS1503: Argument 1: cannot convert from 'WorkflowPlatform.Core.DefinitionId' to 'WorkflowPlatform.Core.InstanceId'
        // static void Cancel(InstanceId id) { }
        // Cancel(definitionId); // This line would not compile
    }

    [Fact]
    public void AuditEntry_NormalisesNonUtcTimestampToUtc()
    {
        var StepA = new WorkflowStep("StepA", StepKind.Start);
        var StepB = new WorkflowStep("StepB", StepKind.End);
        // Arrange: A timestamp with a +05:30 local offset
        var localTime = new DateTimeOffset(2026, 11, 14, 10, 0, 0, TimeSpan.FromMinutes(330));

        // Act
        var entry = new AuditEntry("Alice", "Update", StepA, StepB, localTime);

        // Assert: It is successfully stored as UTC (Offset is Zero, time is adjusted)
        Assert.Equal(TimeSpan.Zero, entry.TimestampUtc.Offset);
        Assert.Equal(new DateTime(2026, 11, 14, 4, 30, 0, DateTimeKind.Utc), entry.TimestampUtc.UtcDateTime);
    }

    [Fact]
    public void AuditTrail_ClearFromOutside_DoesNotAffectTrail()
    {
        var step1 = new WorkflowStep("Start", StepKind.Start);
        var step2 = new WorkflowStep("End", StepKind.End);

        var workflowInstance = new WorkflowInstance(
            InstanceId.NewId(),
            new WorkflowDefinition(
                DefinitionId.NewId(),
                "Sample Workflow",
                1,
                ImmutableList.Create(step1, step2),
                ImmutableList.Create(new Transition("StartToEnd", step1, step2))
            ),
            step1,
            ImmutableList<AuditEntry>.Empty
        );

        // Move to the next step, which adds an entry to the audit trail
        workflowInstance.MoveToNextStep(step2, "user1", "action1");

        // Attempt to clear the audit trail from outside
        var clearedTrail = workflowInstance.AuditTrail.Clear();

        // Assert that the original AuditTrail still has exactly one entry
        Assert.Single(workflowInstance.AuditTrail);
    }
}
