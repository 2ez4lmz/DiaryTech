using DiaryTech.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaryTech.DAL.Configurations;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(5000);

        builder.HasData(new List<Report>()
        {
            new Report()
            {
                Id = 1,
                Name = "Report #41",
                Description = "Test description",
                UserId = 1,
                CreatedAt = DateTime.UtcNow
            }
        });
    }
}