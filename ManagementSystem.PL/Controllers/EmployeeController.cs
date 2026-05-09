using ManagementSystem.BLL.Services.abstractions;
using ManagementSystem.BLL.ViemModels;
using ManagementSystem.DAL.Models;
using ManagementSystem.DAL.Repos.abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ManagementSystem.PL.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IEmployeeService employeeService;
		private readonly IDepartmentService departmentService;

		public EmployeeController(IEmployeeService employeeService,IDepartmentService departmentService)
		{
			this.employeeService = employeeService;
			this.departmentService = departmentService;
		}
		public async Task<IActionResult> Index()
		{
			var employes = await employeeService.GetAll();
			var x = 10;
			x = 50;
			dynamic y = 77;
			y = "asd";
			ViewBag.y2 = y;

			return View("index", employes);
		}

			[HttpGet]
		public async Task<IActionResult> Add()
		{
			var departments = await departmentService.GetAllDepartments();
			ViewBag.Department = departments;

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(CreateEmployee model)
		{
			if (ModelState.IsValid)
			{
			
				await employeeService.Add(model);

				return RedirectToAction(nameof(Index));
			}

			

			return View(model);
		}

	}
}
