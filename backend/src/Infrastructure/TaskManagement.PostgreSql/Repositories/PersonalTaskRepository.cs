using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Repositories;
using TaskManagement.Infra.EF.Contexts;
using TaskManagement.Infra.EF.Core;

namespace TaskManagement.PostgreSql.Repositories
{
    public class PersonalTaskRepository : RepositoryBase<PersonalTask>, IPersonalTaskRepository
    {
        public PersonalTaskRepository(TaskManagementEFContext context) : base(context)
        {
        }
    }
}