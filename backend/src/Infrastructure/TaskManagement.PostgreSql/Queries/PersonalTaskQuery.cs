using Dapper;
using TaskManagement.Infra.EF.Contexts;
using TaskManagement.PostgreSql.Core;
using TaskManagement.UseCases.PersonalTasks.Queries;
using TaskManagement.UseCases.PersonalTasks.Queries.Dtos;

namespace Locamoto.Infra.PostgreSql.Queries
{
    public class PersonalTaskQuery(string connectionString) : QueryRepository(connectionString), IPersonalTaskQuery
    {
        readonly string _tableName = TaskManagementEFContextSchema.PersonalTask.TableName;
        readonly string _schema = TaskManagementEFContextSchema.DefualtSchema;

        public async Task<IEnumerable<ListPersonalTaskDto>> GetAll()
        {
            using var connection = this.GetConnection();
           
            var commandText = $"select \"Id\", \"Title\", \"Description\", \"StartDay\", \"EndDay\", \"State\", \"UpdateDate\", \"CreateDate\" from \"{_schema}\".\"{_tableName}\" order by \"State\" asc ";
             
            var list = await connection.QueryAsync<ListPersonalTaskDto>(commandText);
            return list.ToList();
        }
    }
}