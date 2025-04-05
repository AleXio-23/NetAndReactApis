using AuroraFlow.Persistance.Entities.Dictionaries;
using AuroraFlow.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuroraFlow.Persistance.DbContextValues.Dictionaries;

public class TaskPriorityModelBuilder : IEntityTypeConfiguration<TaskPriority>
{
    public void Configure(EntityTypeBuilder<TaskPriority> entity)
    {
        entity.ToTable("TaskPriority", SchemaConstants.SCHEMA_DICTIONARY);
        entity.HasKey(x => x.Id);
        entity.Property(e => e.Code)
            .IsRequired(false).HasColumnType("VARCHAR(20)");
        entity.Property(e => e.Name)
            .IsRequired().HasColumnType("VARCHAR(20)");
        entity.Property(e => e.Color)
            .IsRequired(false).HasColumnType("VARCHAR(20)");


        entity.HasData(new List<TaskPriority>()
        {
            new() { Id = 1, Code = "urgent", Name = "Urgent", Color = "#C62A2F" },
            new() { Id = 2, Code = "high", Name = "High", Color = "#FFC53C" },
            new() { Id = 3, Code = "normal", Name = "Normal", Color = "#3E63DD" },
            new() { Id = 4, Code = "low", Name = "Low", Color = "#BBBBBB" }
        });
    }
}