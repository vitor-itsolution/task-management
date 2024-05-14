using TaskManagement.UseCases.Core;

namespace TaskManagement.UseCases.PersonalTasks.Update;

public record UpdatePersonalTaskStateCommand(Guid TaskID, State State): CommandRequest<UpdatePersonalTaskStateCommandResponse>
{
    public override bool IsValid()
    {
        this.ValidateFieldlNull(TaskID, "The field MotorcycleID is required");
        this.ValidateFieldlNull(State.ToString(), "The field State is required");

        return base.IsValid();
    }
}
