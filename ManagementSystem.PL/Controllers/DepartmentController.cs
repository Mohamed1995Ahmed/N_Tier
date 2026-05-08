using ManagementSystem.BLL.Services.abstractions;
using ManagementSystem.BLL.ViemModels;
using ManagementSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ManagementSystem.PL.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IDepartmentService departmentService;

		public DepartmentController(IDepartmentService departmentService)
		{
			this.departmentService = departmentService;
		}
		public async Task<IActionResult> Index()
		{
			var departments=await departmentService.GetAllDepartments();
			return View("index",departments);
			
		}
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(CreateDepartment department)
		{
			var department1=new Department();
			department1.Name = department.Name;
			await departmentService.AddDepartment(department1);
			return RedirectToAction(nameof(Index));
		}
	}
}
