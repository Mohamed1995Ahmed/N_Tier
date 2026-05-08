using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.BLL.ViemModels
{
	public class CreateEmployee
	{
		public string Name { get; set; }
		public int Salary { get; set; }
		public int DepartmentId { get; set; }
	}
}
