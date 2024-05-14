
namespace TaskManagement.Infra.EF.Contexts;
public static class TaskManagementEFContextSchema
{
    public const string DefualtSchema = "TaskManagement";
    public const string DefualtConnectionStringName = "TaskManagementConnection";

    public static class PersonalTask
    {
        public const string TableName = "PersonalTask";
        public const string Id = "Id";
        public const string Title = "Title";
        public const string Description = "Description";
        public const string StartDay = "StartDay";
        public const string EndDay = "EndDay";
        public const string CreateDate = "CreateDate";
    }
}
