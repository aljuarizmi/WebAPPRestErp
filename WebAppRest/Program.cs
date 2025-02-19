using Microsoft.EntityFrameworkCore;
using BusinessEntity.Data;
using BusinessData.Interfaces;
using BusinessData.Data;
using BusinessLogic.Services;
using BusinessLogic.Interfaces;
using WebAppRest.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<DbConexion>(builder.Configuration.GetConnectionString("DbConnection"));

// Registrar el servicio en BusinessLogic que usa IApvenextRepository
builder.Services.AddScoped<IApvenextRepository, ApvenextRepository>();
builder.Services.AddScoped<ApvenextService>();
builder.Services.AddScoped<IApvenfilRepository, ApvenfilRepository>();
builder.Services.AddScoped<ApvenfilService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomExceptionMiddleware(); // Usar el Middleware personalizado

app.MapControllers();

app.Run();
