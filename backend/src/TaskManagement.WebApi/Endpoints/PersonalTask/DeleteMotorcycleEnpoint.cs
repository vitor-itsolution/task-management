using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.UseCases.PersonalTasks.Remove;
using TaskManagement.WebApi.Endpoints;

namespace Locamoto.WebApi.Enpoints.Motorcycle
{
    public class RemoveMotorcycleEnpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("/task/{id}", async (
                [FromRoute] Guid id,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = new RemovePersonalTaskCommand(id);
                var response = await mediator.Send(command, cancellationToken);

                if (response.IsValid()) return Results.NoContent();

                return Results.BadRequest(response.GetErrors());
            })
            .WithName("RemoveTask")
            .WithTags("Task")
            .WithOpenApi();
        }
    }
}