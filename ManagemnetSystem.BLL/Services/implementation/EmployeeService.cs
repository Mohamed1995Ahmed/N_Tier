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
	public class EmployeeService : IEmployeeService
	{
		IEmployeeRepository employeeRepository;
		public EmployeeService(IEmployeeRepository employeeRepository)
		{
			this.employeeRepository = employeeRepository;
		}
		public async Task Add(CreateEmployee model)
		{
			var employee = new Employee
			{
				Name = model.Name,
				Salary = model.Salary,
				DepartmentId = model.DepartmentId
			};

			await employeeRepository.Add(employee);
		}

		public async Task<List<EmployeeDto>> GetAll()
		{
			var employees = await employeeRepository.GetAll();

			return employees.Select(e => new EmployeeDto
			{
				
				Name = e.Name,
				Salary = e.Salary,
				DepartmentId = e.DepartmentId
			}).ToList();
		}
	}
}
