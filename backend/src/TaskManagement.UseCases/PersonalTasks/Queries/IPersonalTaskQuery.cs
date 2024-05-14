
using TaskManagement.UseCases.PersonalTasks.Queries.Dtos;

namespace TaskManagement.UseCases.PersonalTasks.Queries;

public interface IPersonalTaskQuery
{
    Task<IEnumerable<ListPersonalTaskDto>> GetAll();
}
