using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.UseCases.Core;

namespace TaskManagement.UseCases.PersonalTasks.Create;

public record CreatePersonalTaskCommandResponse: CommandResponse
{
    public Guid TaskID { get; set; }
}

