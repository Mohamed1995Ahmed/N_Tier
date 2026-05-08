using ManagementSystem.BLL.ViemModels;
using ManagementSystem.DAL.Models;
using ManagementSystem.DAL.Repos.abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.BLL.Services.abstractions
{
	public interface IDepartmentService
	{
		Task<List<DepartmentDto>> GetAllDepartments();
		Task<Department?> GetDepartmentById(int id);
		Task AddDepartment(Department department);
		Task UpdateDepartment(Department department);
		Task DeleteDepartment(int id);
		Task<bool> DepartmentExists(int id);
		Task<bool> DepartmentHasEmployees(int id);
	}
}
