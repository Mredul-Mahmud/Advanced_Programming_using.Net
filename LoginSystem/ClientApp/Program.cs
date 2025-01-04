using BLL.Mapping;
using BLL.Services;
using ClassLibrary1.EF;
using ClassLibrary1.Repos.Implementations;
using ClassLibrary1.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Configure the connection string
var connectionString = builder.Configuration.GetConnectionString("DatabaseforClient");

builder.Services.AddDbContext<ClientContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container
builder.Services.AddControllersWithViews();

// Register AutoMapper with the profile
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<AutoMapperProfile>();
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Register Business Logic Services
builder.Services.AddScoped<EmployeeService>(); // No interface for EmployeeService
builder.Services.AddScoped<DepartmentService>(); // No interface for DepartmentService
builder.Services.AddScoped<DesignationService>(); // No interface for DesignationService

// Register Repository Implementations
builder.Services.AddScoped<IEmployee, ImEmployee>();
builder.Services.AddScoped<IDepartment, ImDepartment>();
builder.Services.AddScoped<IDesignation, ImDesignation>();

var app = builder.Build();

// Configure the HTTP request pipeline
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

app.Run();
