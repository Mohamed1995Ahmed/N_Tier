using AutoMapper;
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
		private readonly IMapper mapper;

		public DepartmentService(IDepartmentRepository departmentRepository,IMapper mapper)
		{
			this.departmentRepository = departmentRepository;
			this.mapper = mapper;
		}
	
		

		public async Task AddDepartment(CreateDepartment department)
		{
			if (department == null)
			{
				throw new ArgumentNullException();
			}
			var dept=mapper.Map<CreateDepartment,Department>(department);

			await departmentRepository.Add(dept);
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

			var deptDto = mapper.Map<List<DepartmentDto>>(departments);
			return deptDto;
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
