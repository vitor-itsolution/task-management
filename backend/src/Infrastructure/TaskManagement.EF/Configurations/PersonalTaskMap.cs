using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;
using TaskManagement.Infra.EF.Contexts;

namespace TaskManagement.EF.Configurations
{
    public class PersonalTaskMap : IEntityTypeConfiguration<PersonalTask>
    {
        public void Configure(EntityTypeBuilder<PersonalTask> builder)
        {
            builder.ToTable(TaskManagementEFContextSchema.PersonalTask.TableName);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.StartDay).IsRequired();
            builder.Property(p => p.EndDay);
            builder.Property(p => p.CreateDate).IsRequired();
            builder.Property(p => p.UpdateDate);

            builder.HasData(InitPersonalTask());
        }

        private IList<PersonalTask> InitPersonalTask() => new List<PersonalTask>
        {
            new PersonalTask("Set kick-off meeting", "Set kick-off meeting", new DateTime(2024,04,15)),
            new PersonalTask("Final resource plan", "Final resource plan", new DateTime(2024,04,16)),
            new PersonalTask("Api development", "Api development", new DateTime(2024,04,16))
        };
    }
}