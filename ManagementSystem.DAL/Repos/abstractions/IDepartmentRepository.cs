


using ManagementSystem.DAL.Models;

namespace ManagementSystem.DAL.Repos.abstractions
{
	public interface IDepartmentRepository
	{
		Task Add(Department department);
		Task Update(Department department);
		Task Delete(int id);
		Task<Department?> GetById(int id);
		Task<List<Department>> GetAll();
		
	}
	}

