using System.Reflection;
using BandManager.Api.DAL.Context;
using Microsoft.EntityFrameworkCore;
using BandManager.Api.BLL.Services;
using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;
using BandManager.Api.DAL.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Title = "BandManager.Api",
		Version = "v1",
		Description = "A simple API for managing bands and bookings",
	});

	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});




//Gets the version of the database from appsettings.json this because XAMPP(the local test environment) uses a older version of MariaDB
string dbVersion = builder.Configuration.GetValue<string>("DbVersions:Dev") ?? "10.11.8-mariadb";

// Dependency injection
builder.Services.AddDbContext<BandManagerContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DevConnection"),
        new MySqlServerVersion(new Version(10, 11, 8)) // Insira a versão correta aqui
    ));

builder.Services.AddCors(options =>
{
	options.AddPolicy("ReactFrontEndDev", policyBuilder =>
	{
		policyBuilder.AllowAnyOrigin() //Cors is currently not working, mainly because the app sometimes runs on different ports, and we don't have auth in the backend yet. That's why we're opening this up for now
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});

builder.Services.AddScoped<IDirectDbRepository<Availability>, DirectDbRepository<Availability>>();
builder.Services.AddScoped<AvailabilityService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.UseCors("ReactFrontEndDev");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
