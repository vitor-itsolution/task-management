using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.UseCases.PersonalTasks.Queries;
using TaskManagement.WebApi.Endpoints;

namespace TaskManagement.WebApi.Endpoints.PersonalTask
{
    public class GetPersonalTaskEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/task", async (
                IPersonalTaskQuery personalTaskQuery) =>
                {
                    var list = await personalTaskQuery.GetAll();
                    return list;
                })
                .WithName("GetTask")
                .WithTags("Task")
                .WithOpenApi();
        }
    }
}