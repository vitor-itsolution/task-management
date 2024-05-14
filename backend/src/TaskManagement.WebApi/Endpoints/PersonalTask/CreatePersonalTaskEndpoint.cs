using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.UseCases.PersonalTasks.Create;

namespace TaskManagement.WebApi.Endpoints.PersonalTask
{
    public class CreatePersonalTaskEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
              app.MapPost("/task", async (
                [FromBody] CreatePersonalTaskCommand command,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var response = await mediator.Send(command, cancellationToken);

                if (response.IsValid()) return Results.Ok(response.TaskID);

                return Results.BadRequest(response.GetErrors());
            })
            .WithName("CreatePersonalTask")
            .WithTags("Task")
            .WithOpenApi();
        }
    }
}