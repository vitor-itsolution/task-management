namespace TaskManagement.Domain.Core;

public abstract class EntityRoot
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreateDate { get; private set; } = DateTime.Now;

    public abstract void Validate();
}
