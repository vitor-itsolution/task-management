
using TaskManagement.UseCases.Core;

namespace TaskManagement.UseCases.PersonalTasks.Remove;

public record RemovePersonalTaskCommand(Guid TaskID): CommandRequest<RemovePersonalTaskCommandResponse>
{
    public override bool IsValid()
    {
        this.ValidateFieldlNull(TaskID, "The field TaskID is required");

        return base.IsValid();
    }
}
