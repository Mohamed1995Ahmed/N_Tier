using ManagementSystem.BLL.Services.abstractions;
using ManagementSystem.BLL.Services.implementation;
using ManagementSystem.DAL.Repos.abstractions;
using ManagementSystem.DAL.Repos.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace ManagementSystem.DAL.Common
{
	public static class ModularToBusinessbll
	{
		public static IServiceCollection ModularToBusinessBllMethod(this IServiceCollection services)
		{
			services.AddScoped<IDepartmentService, DepartmentService>();
			services.AddScoped<IEmployeeService, EmployeeService>();
			

			return services;

		}
	}
}
