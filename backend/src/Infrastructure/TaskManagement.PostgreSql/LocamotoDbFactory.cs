using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TaskManagement.Infra.EF.Contexts;

namespace TaskManagement.PostgreSql;

public class LocamotoDbFactory: IDesignTimeDbContextFactory<TaskManagementEFContext>
{
    public TaskManagementEFContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<TaskManagementEFContext>();
        optionBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=user;Password=123456;Database=personaltaskdb;", a => a.MigrationsAssembly("TaskManagement.PostgreSql"));

        return new TaskManagementEFContext(optionBuilder.Options);
    }
}
