using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Domain.Repositories;
using TaskManagement.Infra.EF.Contexts;
using TaskManagement.PostgreSql.Queries;
using TaskManagement.PostgreSql.Repositories;
using TaskManagement.UseCases.PersonalTasks.Queries;

namespace TaskManagement.PostgreSql.Extensions;

public static class DbPostgreSqlServiceCollectionExtension
{
    public static void AddInfraPostgreSql(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(TaskManagementEFContextSchema.DefualtConnectionStringName);
        ArgumentNullException.ThrowIfNullOrEmpty(connectionString);

        services.AddDbContext<TaskManagementEFContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IPersonalTaskRepository, PersonalTaskRepository>();
        services.AddTransient<IPersonalTaskQuery>(x => new PersonalTaskQuery(connectionString));
    }
}
