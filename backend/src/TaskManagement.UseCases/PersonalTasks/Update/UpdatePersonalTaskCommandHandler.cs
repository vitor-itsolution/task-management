using MediatR;
using TaskManagement.Domain.Exceptions;
using TaskManagement.Domain.Repositories;

namespace TaskManagement.UseCases.PersonalTasks.Update;

public class UpdatePersonalTaskCommandHandler(IPersonalTaskRepository personalTaskRepository)
    : IRequestHandler<UpdatePersonalTaskCommand, UpdatePersonalTaskCommandResponse>
{
    readonly IPersonalTaskRepository _personalTaskRepository = personalTaskRepository;

    public async Task<UpdatePersonalTaskCommandResponse> Handle(UpdatePersonalTaskCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdatePersonalTaskCommandResponse();

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

            personalTask.SetTitle(request.Title);
            personalTask.SetDescription(request.Description);
            personalTask.SetStartDay(request.StartDay);
            personalTask.SetEndDay(request.EndDay);
            personalTask.SetUpdateDate(DateTime.Now);
            personalTask.SetState(request.State);

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
