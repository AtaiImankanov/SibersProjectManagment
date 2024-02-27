using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProjectsTrackerSibers.DAL;
using ProjectsTrackerSibers.DAL.Interfaces;
using ProjectsTrackerSibers.DAL.Repositories;
using ProjectsTrackerSiber.Service.Interfaces;
using ProjectsTrackerSiber.Service.Implementations;
using ProjectsTrackerSibers.Domain.Entity;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));




//добавление сервисов
//DAL
builder.Services.AddScoped<IBaseRepository<Project>, BaseRepository<Project>>();    
//Service
builder.Services.AddScoped<IProjectService, ProjectService>();

// Identiy

//builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
//	.AddEntityFrameworkStores<AppDbContext>()
//	.AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireUppercase = true;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequiredLength = 8;
});

builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.HttpOnly = true;
	options.ExpireTimeSpan = TimeSpan.FromDays(30);
	options.LoginPath = "/Account/Login";
	options.AccessDeniedPath = "/Account/AccessDenied";
	options.SlidingExpiration = true;
});

//

// Build the service provider.
var serviceProvider = builder.Services.BuildServiceProvider();
//roles and admin user
//using (var scope = serviceProvider.CreateScope())
//{
//	var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//	var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

//	// Create roles if they don't exist
//	string[] roleNames = { "Admin", "Manager", "Employee" };
//	foreach (var roleName in roleNames)
//	{
//		var roleExist = await roleManager.RoleExistsAsync(roleName);
//		if (!roleExist)
//		{
//			await roleManager.CreateAsync(new IdentityRole(roleName));
//		}
//	}

//	// Create admin user if not exists
//	//var adminUser = await userManager.FindByEmailAsync("admin@example.com");
//	//if (adminUser == null)
//	//{
//	//	var user = new ApplicationUser
//	//	{
//	//		UserName = "admin@example.com",
//	//		Email = "admin@example.com"
//	//	};
//	//	await userManager.CreateAsync(user, "Admin@123");
//	//	await userManager.AddToRoleAsync(user, "Admin");
//	//}
//}
//



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ensure the database is created and apply migrations
using (var scope = serviceProvider.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.Run();









