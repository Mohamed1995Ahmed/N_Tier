using ManagementSystem.DAL.Models;


namespace ManagementSystem.DAL.Database.Configruations
{
	public class DepartmentConfigruation : IEntityTypeConfiguration<Department>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Department> builder)
		{
			builder.HasKey(d => d.Id);
			builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
		}
	}
}
