
using TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TaskManagement.EF.Configurations;

namespace TaskManagement.Infra.EF.Contexts;

public class TaskManagementEFContext : DbContext
{
    public DbSet<PersonalTask> PersonalTasks => Set<PersonalTask>();

    public TaskManagementEFContext(DbContextOptions<TaskManagementEFContext> dbContextOptions)
            : base(dbContextOptions)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(TaskManagementEFContextSchema.DefualtSchema);

        modelBuilder.ApplyConfiguration(new PersonalTaskMap());
    }
}
