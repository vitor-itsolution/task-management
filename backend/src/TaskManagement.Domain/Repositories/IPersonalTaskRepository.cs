using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Repositories
{
    public interface IPersonalTaskRepository
    {
        Task<PersonalTask> GetById(Guid id);
        Task Create(PersonalTask personalTask);
        Task Update(PersonalTask personalTask);
        Task Remove(PersonalTask personalTask);
        Task SaveChanges();
    }
}