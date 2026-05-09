using ManagementSystem.BLL.Mapper;
using ManagementSystem.BLL.Services.abstractions;
using ManagementSystem.BLL.Services.implementation;
using ManagementSystem.DAL.Common;
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
            builder.Services.AddDbContext<ManagementSystemDBContext>(option =>option.UseSqlServer(builder.Configuration.GetConnectionString("connectionstring22")));
            //         builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //         builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.ModularToBusinessDllMethod();
            builder.Services.ModularToBusinessBllMethod();
            builder.Services.AddAutoMapper(a=>a.AddProfile<ManagementSystemProfile>());

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
