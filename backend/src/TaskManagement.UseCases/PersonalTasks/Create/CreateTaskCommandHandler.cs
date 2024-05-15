using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Exceptions;
using TaskManagement.Domain.Repositories;

namespace TaskManagement.UseCases.PersonalTasks.Create;
public class CreateTaskCommandHandler(IPersonalTaskRepository personalTaskRepository) 
    : IRequestHandler<CreatePersonalTaskCommand, CreatePersonalTaskCommandResponse>
{
    readonly IPersonalTaskRepository _personalTaskRepository = personalTaskRepository;

    public async Task<CreatePersonalTaskCommandResponse> Handle(CreatePersonalTaskCommand request, CancellationToken cancellationToken)
    {
        var response = new CreatePersonalTaskCommandResponse();


        if (!request.IsValid())
        {
            response.AddError(request.GetErrors());
            return response;
        }

        try
        {
            var personalTask = new PersonalTask(
                title: request.Title,
                description: request.Description,
                startDay: request.StartDay,
                state: request.State,
                endDay: request.EndDay
            );

            await _personalTaskRepository.Create(personalTask);
            await _personalTaskRepository.SaveChanges();

            response.TaskID = personalTask.Id;
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
