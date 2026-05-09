using AutoMapper;
using ManagementSystem.BLL.ViemModels;
using ManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.BLL.Mapper
{
	public class ManagementSystemProfile:Profile
	{
		public ManagementSystemProfile() {
			CreateMap<Employee,EmployeeDto>().ForMember(d=>d.Name,opt=>opt.MapFrom(src=>src.Name)).
				ForMember(des=>des.Salary,opt=>opt.MapFrom(src=>src.Salary));
			CreateMap<Department,DepartmentDto>().ForMember(des=>des.Name,opt=>opt.MapFrom(src=>src.Name));
			CreateMap<CreateDepartment, Department>().ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name)); ;
			CreateMap<CreateEmployee, Employee>().ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(des => des.Salary, opt => opt.MapFrom(src => src.Salary));





		}
	}
}
