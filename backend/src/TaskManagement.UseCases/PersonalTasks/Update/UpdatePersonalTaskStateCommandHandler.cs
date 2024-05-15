using MediatR;
using TaskManagement.Domain.Exceptions;
using TaskManagement.Domain.Repositories;

namespace TaskManagement.UseCases.PersonalTasks.Update;

public class UpdatePersonalTaskStateCommandHandler(IPersonalTaskRepository personalTaskRepository)
    : IRequestHandler<UpdatePersonalTaskStateCommand, UpdatePersonalTaskStateCommandResponse>
{
    readonly IPersonalTaskRepository _personalTaskRepository = personalTaskRepository;

    public async Task<UpdatePersonalTaskStateCommandResponse> Handle(UpdatePersonalTaskStateCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdatePersonalTaskStateCommandResponse();

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

            var updateDate = DateTime.Now;

            personalTask.SetState(request.State);
            personalTask.SetUpdateDate(updateDate);

            if (request.State == State.Done)
                personalTask.SetEndDay(updateDate);

            await _personalTaskRepository.Update(personalTask);
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
