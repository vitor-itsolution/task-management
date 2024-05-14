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
            //TODO: Change this query.
            var commandText = $"select * from \"{_schema}\".\"{_tableName}\" ";
             
            var list = await connection.QueryAsync<ListPersonalTaskDto>(commandText);
            return list.ToList();
        }
    }
}