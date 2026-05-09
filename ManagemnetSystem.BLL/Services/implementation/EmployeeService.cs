using AutoMapper;
using ManagementSystem.BLL.Services.abstractions;
using ManagementSystem.BLL.ViemModels;
using ManagementSystem.DAL.Models;
using ManagementSystem.DAL.Repos.abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
		private readonly IMapper mapper;

		public EmployeeService(IEmployeeRepository employeeRepository,IMapper mapper)
		{
			this.employeeRepository = employeeRepository;
			this.mapper = mapper;
		}
		public async Task Add(CreateEmployee model)
		{
			var employee = mapper.Map<CreateEmployee, Employee>(model);

			await employeeRepository.Add(employee);
		}

		public async Task<List<EmployeeDto>> GetAll()
		{
			var employees = await employeeRepository.GetAll();
			var emps=mapper.Map<List<EmployeeDto>>(employees);
			
			
			return emps;

		}
	}
}
