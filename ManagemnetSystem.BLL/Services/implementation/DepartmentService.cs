using ManagementSystem.BLL.Services.abstractions;
using ManagementSystem.BLL.ViemModels;
using ManagementSystem.DAL.Models;
using ManagementSystem.DAL.Repos.abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.BLL.Services.implementation
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IDepartmentRepository departmentRepository;

		public DepartmentService(IDepartmentRepository departmentRepository)
		{
			this.departmentRepository = departmentRepository;
		}
	
		

		public async Task AddDepartment(Department department)
		{
			if (department == null)
			{
				throw new ArgumentNullException();
			}
			await departmentRepository.Add(department);
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task DeleteDepartment(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DepartmentExists(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DepartmentHasEmployees(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<DepartmentDto>> GetAllDepartments()
		{
			var departments = await departmentRepository.GetAll();

			return departments.Select(d => new DepartmentDto
			{
				Id = d.Id,
				Name = d.Name
			}).ToList();
		}

	

		public Task<Department?> GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Department?> GetDepartmentById(int id)
		{
			throw new NotImplementedException();
		}

		public Task Update(Department department)
		{
			throw new NotImplementedException();
		}

		public Task UpdateDepartment(Department department)
		{
			throw new NotImplementedException();
		}
	}
}
