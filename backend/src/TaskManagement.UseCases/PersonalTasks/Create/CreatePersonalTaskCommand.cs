using TaskManagement.UseCases.Core;

namespace TaskManagement.UseCases.PersonalTasks.Create;

public record CreatePersonalTaskCommand(string Title, string Description, DateTime StartDay, State State, DateTime? EndDay) : CommandRequest<CreatePersonalTaskCommandResponse>
{
    public override bool IsValid()
    {
        this.ValidateFieldlNull(Title, "The field Title is required");
        this.ValidateFieldlNull(Description, "The field Description is required");
        this.ValidateFieldlNull(StartDay, "The field StartDay is required");
        this.ValidateFieldlNull(State.ToString(), "The field State is required");

        return base.IsValid();
    }
}
