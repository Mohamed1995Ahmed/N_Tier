using ManagementSystem.DAL.Database;
using ManagementSystem.DAL.Models;
using ManagementSystem.DAL.Repos.abstractions;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.DAL.Repos.Implementation
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly ManagementSystemDBContext context;

		public EmployeeRepository(ManagementSystemDBContext context)
		{
			this.context = context;
		}

		public async Task Add(Employee employee)
		{
			await context.AddAsync(employee);
			await Save();
		}

		public async Task Delete(int id)
		{
			var employee = await GetById(id);
			if (employee != null)
			{
				context.Remove(employee);
				 await Save();
			}
		}

		public async Task<List<Employee>> GetAll()
		{
			return await context.Employee.Include(e => e.Department).ToListAsync();
		}

		public async Task<Employee?> GetById(int id)
		{
			return await context.Employee
				.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Update(Employee employee)
		{
			var existingEmployee = await GetById(employee.Id);

			if (existingEmployee != null)
			{
				// Update fields
				existingEmployee.Name = employee.Name;
				existingEmployee.Salary = employee.Salary;
				existingEmployee.DepartmentId = employee.DepartmentId;

				context.Update(existingEmployee);
				 await Save();
			}

		}
		private async Task Save()
		{
			await context.SaveChangesAsync();

		}
	}
}