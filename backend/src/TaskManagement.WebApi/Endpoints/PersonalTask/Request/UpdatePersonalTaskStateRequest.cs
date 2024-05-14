using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.WebApi.Endpoints.PersonalTask.Request
{
    public class UpdatePersonalTaskStateRequest
    {
        public State State { get; set; }
    }
}