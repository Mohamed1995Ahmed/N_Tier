using ManagementSystem.DAL.Models;

namespace ManagementSystem.DAL.Repos.abstractions
{
	public interface IEmployeeRepository
	{
		Task Add(Employee employee);
		Task Update(Employee employee);
		Task Delete(int id);
		Task<Employee?> GetById(int id);
		Task<List<Employee>> GetAll();
	}
}