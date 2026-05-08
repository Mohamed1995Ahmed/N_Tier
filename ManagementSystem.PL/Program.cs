using ManagementSystem.BLL.Services.abstractions;
using ManagementSystem.BLL.Services.implementation;

using ManagementSystem.DAL.Database;
using ManagementSystem.DAL.Repos.abstractions;
using ManagementSystem.DAL.Repos.Implementation;

using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<ManagementSystemDBContext>(options =>
	  options.UseSqlServer(
		  builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
			builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			builder.Services.AddScoped<IEmployeeService, EmployeeService>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
