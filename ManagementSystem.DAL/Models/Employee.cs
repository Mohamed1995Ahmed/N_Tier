



namespace ManagementSystem.DAL.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int Salary { get; set; }
		[ForeignKey("Department")]
		public int DepartmentId { get; set; }
		public Department Department { get; set; }
	}
}
