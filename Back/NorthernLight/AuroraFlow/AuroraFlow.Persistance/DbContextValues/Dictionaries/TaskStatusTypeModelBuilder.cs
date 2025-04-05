using AuroraFlow.Persistance.Entities.Dictionaries;
using AuroraFlow.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuroraFlow.Persistance.DbContextValues.Dictionaries;

public class TaskStatusTypeModelBuilder : IEntityTypeConfiguration<TaskStatusType>
{
    public void Configure(EntityTypeBuilder<TaskStatusType> entity)
    {
        entity.ToTable("TaskStatusType", SchemaConstants.SCHEMA_DICTIONARY);
        entity.HasKey(x => x.Id);
        entity.Property(e => e.Code)
            .IsRequired(false).HasColumnType("VARCHAR(20)");
        entity.Property(e => e.Name)
            .IsRequired().HasColumnType("VARCHAR(20)");


        entity.HasData(new List<TaskStatusType>()
        {
            new() { Id = 1, Code = "default", Name = "Default" },
            new() { Id = 2, Code = "complete", Name = "Complete" },
            new() { Id = 3, Code = "closed", Name = "Closed" }
        });
    }
}