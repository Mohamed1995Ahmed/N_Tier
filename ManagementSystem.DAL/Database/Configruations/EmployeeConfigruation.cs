using ManagementSystem.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.DAL.Database.Configruations
{
	public class EmployeeConfigruation : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
			builder.HasOne(a => a.Department).WithMany(a => a.Employees).HasForeignKey(s=>s.DepartmentId);
		}
	}
}
