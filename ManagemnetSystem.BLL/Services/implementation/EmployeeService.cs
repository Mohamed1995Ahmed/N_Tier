using ManagementSystem.BLL.Services.abstractions;
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
		public async Task Add(Employee employee)
		{
			await employeeRepository.Add(employee);
		}

		public async Task<List<Employee>> GetAll()
		{
			return await employeeRepository.GetAll();	
		}
	}
}
