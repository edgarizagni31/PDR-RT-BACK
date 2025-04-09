using EmployeeApi.Application.Services;
using EmployeeApi.Domain.Dto;
using EmployeeApi.Domain.Repositories;
using EmployeeApi.Infrastructure.Data;
using EmployeeApi.Infrastructure.Data.Repositories;
using EmployeeApi.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EmployeeDbContext>((opt) => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IAFPRepository, AFPRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<JobService>();
builder.Services.AddScoped<AFPService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(ms => ms.Value.Errors.Count > 0)
            .Select(ms => ms.Value.Errors.Select(e => e.ErrorMessage).ToList())
            .SelectMany(e => e)
            .ToList();

        var apiResponse = new ApiResponse<List<string>>()
        {
            Success = false,
            Message = "Error de validación",
            Data = errors
        };

        return new BadRequestObjectResult(apiResponse);
    };
});

/*
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular");

app.UseValidationMiddleware();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
