
using TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TaskManagement.EF.Configurations;

namespace TaskManagement.Infra.EF.Contexts;

public class TaskManagementEFContext: DbContext
{
    public DbSet<PersonalTask> PersonalTasks => Set<PersonalTask>();

    public TaskManagementEFContext(DbContextOptions<TaskManagementEFContext> dbContextOptions)
            : base(dbContextOptions)
    {
            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(TaskManagementEFContextSchema.DefualtSchema);

        modelBuilder.ApplyConfiguration(new PersonalTaskMap());
    }
}
