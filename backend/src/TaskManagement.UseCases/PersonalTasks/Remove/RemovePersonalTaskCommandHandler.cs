using MediatR;
using TaskManagement.Domain.Exceptions;
using TaskManagement.Domain.Repositories;

namespace TaskManagement.UseCases.PersonalTasks.Remove;

public class RemovePersonalTaskCommandHandler(
    IPersonalTaskRepository personalTaskRepository) 
    : IRequestHandler<RemovePersonalTaskCommand, RemovePersonalTaskCommandResponse>
{
    readonly IPersonalTaskRepository _personalTaskRepository = personalTaskRepository;

    public async Task<RemovePersonalTaskCommandResponse> Handle(RemovePersonalTaskCommand request, CancellationToken cancellationToken)
    {
        var response = new RemovePersonalTaskCommandResponse();

        if (!request.IsValid())
        {
            response.AddError(request.GetErrors());
            return response;
        }

        try
        {
            var personalTask = await _personalTaskRepository.GetById(request.TaskID);

            if (personalTask is null)
            {
                response.AddError("Task not found");
                return response;
            }

            await _personalTaskRepository.Remove(personalTask);
            await _personalTaskRepository.SaveChanges();

        }
        catch (DomainException ex)
        {
            response.AddError(ex.Message);
            return response;
        }
        catch (Exception)
        {
            throw;
        }

        return response;
    }
}
