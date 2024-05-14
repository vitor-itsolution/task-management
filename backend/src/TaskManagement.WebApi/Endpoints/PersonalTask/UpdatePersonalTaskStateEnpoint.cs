using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.UseCases.PersonalTasks.Update;
using TaskManagement.WebApi.Endpoints;
using TaskManagement.WebApi.Endpoints.PersonalTask.Request;

namespace Locamoto.WebApi.Enpoints.Motorcycle
{
    public class UpdatePersonalTaskStateEnpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("/task/{id}/state", async (
               [FromRoute] Guid id,
               [FromBody] UpdatePersonalTaskStateRequest request,
               IMediator mediator,
               CancellationToken cancellationToken) =>
           {
               var command = new UpdatePersonalTaskStateCommand(id, request.State);
               var response = await mediator.Send(command, cancellationToken);

               if (response.IsValid()) return Results.NoContent();

               return Results.BadRequest(response.GetErrors());
           })
           .WithName("UpdatePersonalStateTask")
           .WithTags("Task")
           .WithOpenApi();
        }
    }
}