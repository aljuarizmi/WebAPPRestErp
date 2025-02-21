using Microsoft.EntityFrameworkCore;
using BusinessEntity.Data;
using BusinessData.Interfaces;
using BusinessData.Data;
using BusinessLogic.Services;
using BusinessLogic.Interfaces;
using WebAppRest.Middlewares;
using System.Text.Json;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddSwaggerGen(c =>
{
    //c.MapType<string>(() => new OpenApiSchema { Example = new OpenApiString("") });
    c.EnableAnnotations();
});*/

builder.Services.AddSqlServer<DbConexion>(builder.Configuration.GetConnectionString("DbConnection"));

// Registrar el servicio en BusinessLogic que usa IApvenextRepository
builder.Services.AddScoped<IApvenextRepository, ApvenextRepository>();
builder.Services.AddScoped<ApvenextService>();
builder.Services.AddScoped<IApvenfilRepository, ApvenfilRepository>();
builder.Services.AddScoped<ApvenfilService>();

builder.Services.AddScoped<IApopnfilRepository, ApopnfilRepository>();
builder.Services.AddScoped<ApopnfilService>();

builder.Services.AddScoped<ExcelService>();


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

//
app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;
    response.ContentType = "application/json";

    var errorResponse = new
    {
        statusCode = response.StatusCode,
        error = response.StatusCode switch
        {
            400 => "Bad Request",
            401 => "Unauthorized",
            403 => "Forbidden",
            404 => "Not Found",
            405 => "Method Not Allowed",
            415 => "Unsupported Media Type",
            _ => "Unexpected Error"
        },
        message = "Error en la solicitud.",
        path = context.HttpContext.Request.Path
    };

    await response.WriteAsync(JsonSerializer.Serialize(errorResponse));
});

app.MapControllers();

app.Run();
