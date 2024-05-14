using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.WebApi.Endpoints.PersonalTask.Request
{
    public class UpdatePersonalTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDay { get; set; }
        public State State { get; set; }
        public DateTime? EndDay { get; set; }
    }
}