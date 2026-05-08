using ManagementSystem.DAL.Database;
using ManagementSystem.DAL.Models;
using ManagementSystem.DAL.Repos.abstractions;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.DAL.Repos.Implementation
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private readonly ManagementSystemDBContext context;

		public DepartmentRepository(ManagementSystemDBContext context)
		{
			this.context = context;
		}

		public async Task Add(Department department)
		{
			await context.AddAsync(department);
			await Save();
		}

		public async Task Delete(int id)
		{
			var department = await GetById(id);
			if (department != null)
			{
				context.Remove(department);
				await Save();
			}
		}

		public async Task<List<Department>> GetAll()
		{
			return await context.Department.Include(e=>e.Employees).ToListAsync();
		}

		public async Task<Department?> GetById(int id)
		{
			return await context.Department
				.FirstOrDefaultAsync(d => d.Id == id);
		}

		public async Task Update(Department department)
		{
			var existingDepartment = await GetById(department.Id);
			if (existingDepartment != null)
			{
				existingDepartment.Name = department.Name;

				context.Update(existingDepartment);
				await Save();
			}
		}

		private async Task Save()
		{
			await context.SaveChangesAsync();
		}
	}
}