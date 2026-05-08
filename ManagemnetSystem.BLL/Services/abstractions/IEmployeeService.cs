using ManagementSystem.BLL.ViemModels;
using ManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.BLL.Services.abstractions
{
	public interface IEmployeeService
	{
		
			Task Add(CreateEmployee employee);
			//Task Update(Employee employee);
			//Task Delete(int id);
			//Task<Employee?> GetById(int id);
			Task<List<EmployeeDto>> GetAll();
		
	}
}
