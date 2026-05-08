using ManagementSystem.DAL.Repos.abstractions;
using ManagementSystem.DAL.Repos.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace ManagementSystem.DAL.Common
{
	public static class ModularToBusinessDll
	{
		public static IServiceCollection ModularToBusinessDllMethod(this IServiceCollection services)
		{
			services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			

			return services;

		}
	}
}
