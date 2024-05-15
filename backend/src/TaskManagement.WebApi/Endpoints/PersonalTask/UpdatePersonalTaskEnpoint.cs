using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.UseCases.PersonalTasks.Update;
using TaskManagement.WebApi.Endpoints;
using TaskManagement.WebApi.Endpoints.PersonalTask.Request;

namespace TaskManagement.WebApi.Endpoints.PersonalTask
{
    public class UpdatePersonalTaskEnpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("/task/{id}", async (
               [FromRoute] Guid id,
               [FromBody] UpdatePersonalTaskRequest request,
               IMediator mediator,
               CancellationToken cancellationToken) =>
           {
               var command = new UpdatePersonalTaskCommand(id, request.Title, request.Description, request.StartDay, request.State, request.EndDay);
               var response = await mediator.Send(command, cancellationToken);

               if (response.IsValid()) return Results.NoContent();

               return Results.BadRequest(response.GetErrors());
           })
           .WithName("UpdatePersonalTask")
           .WithTags("Task")
           .WithOpenApi();
        }
    }
}