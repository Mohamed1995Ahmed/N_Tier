



using ManagementSystem.DAL.Models;

namespace ManagementSystem.DAL.Database
{
	public class ManagementSystemDBContext:DbContext
	{
		public DbSet<Employee> Employee { get; set; }
		public DbSet<Department> Department { get; set; }
		public ManagementSystemDBContext(DbContextOptions<ManagementSystemDBContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ManagementSystemDBContext).Assembly);
		}
		
	}
	
}
