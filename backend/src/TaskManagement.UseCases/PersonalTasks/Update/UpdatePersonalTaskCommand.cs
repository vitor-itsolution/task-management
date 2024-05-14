using TaskManagement.UseCases.Core;

namespace TaskManagement.UseCases.PersonalTasks.Update;

public record UpdatePersonalTaskCommand(Guid TaskID, string Title, string Description, DateTime StartDay, DateTime? EndDay): CommandRequest<UpdatePersonalTaskCommandResponse>
{
    public override bool IsValid()
    {
        this.ValidateFieldlNull(TaskID, "The field MotorcycleID is required");
        this.ValidateFieldlNull(Title, "The field Title is required");
        this.ValidateFieldlNull(Description, "The field Description is required");
        this.ValidateFieldlNull(StartDay, "The field StartDay is required");

        return base.IsValid();
    }
}
