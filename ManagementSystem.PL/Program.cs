using ManagementSystem.BLL.Mapper;
using ManagementSystem.DAL.Common;
using ManagementSystem.DAL.Database;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ManagementSystem.PL
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// ✅ Localization services
			//builder.Services.AddLocalization(options =>
			//	options.ResourcesPath = "SharedResource");

			builder.Services.AddControllersWithViews()
				.AddViewLocalization()
				.AddDataAnnotationsLocalization(options =>
				{
					options.DataAnnotationLocalizerProvider = (type, factory) =>
						factory.Create(typeof(SharedResource.SharedResource));
				});

			builder.Services.Configure<RequestLocalizationOptions>(options =>
			{
				var supportedCultures = new[]
				{
					new CultureInfo("en"),
					new CultureInfo("ar")
				};

				options.DefaultRequestCulture = new RequestCulture("en");
				options.SupportedCultures = supportedCultures;
				options.SupportedUICultures = supportedCultures;

				// ✅ Fallback to parent cultures (e.g. "ar-EG" → "ar")
				options.FallBackToParentCultures = true;
				options.FallBackToParentUICultures = true;

				// ✅ Cookie has highest priority
				options.RequestCultureProviders = new List<IRequestCultureProvider>
				{
					new CookieRequestCultureProvider(),
					new QueryStringRequestCultureProvider(),
					new AcceptLanguageHeaderRequestCultureProvider()
				};
			});

			// ✅ Database
			builder.Services.AddDbContext<ManagementSystemDBContext>(option =>
				option.UseSqlServer(
					builder.Configuration.GetConnectionString("connectionstring22")));

			// ✅ Services
			builder.Services.ModularToBusinessDllMethod();
			builder.Services.ModularToBusinessBllMethod();
			builder.Services.AddAutoMapper(a =>
				a.AddProfile<ManagementSystemProfile>());

			var app = builder.Build();

			// ✅ Exception handling
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();

			// ✅ MUST come before UseAuthorization
			app.UseRequestLocalization();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}