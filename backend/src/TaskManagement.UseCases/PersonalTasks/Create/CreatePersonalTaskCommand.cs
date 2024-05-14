using TaskManagement.UseCases.Core;

namespace TaskManagement.UseCases.PersonalTasks.Create;

public record CreatePersonalTaskCommand(string Title, string Description, DateTime StartDay, DateTime? EndDay) : CommandRequest<CreatePersonalTaskCommandResponse>
{
    public override bool IsValid()
    {
        this.ValidateFieldlNull(Title, "The field Title is required");
        this.ValidateFieldlNull(Description, "The field Description is required");
        this.ValidateFieldlNull(StartDay, "The field Plate is required");
        this.ValidateFieldlNull(Description, "The field Plate is required");

        return base.IsValid();
    }
}
