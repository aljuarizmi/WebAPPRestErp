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
using System.Reflection;
using Common.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    //Permite mostrar la documentacion en swagger
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
    // **Agregar definición de seguridad JWT para Swagger**
    //Agregue una o más "securityDefinitions" que describan cómo se protege su API al Swagger generado.
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Please enter your token"
    });
    // **Agregar requerimiento de seguridad para todos los endpoints** (en rojo)
    //Añade un requisito de seguridad global
    options.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
    //Permite poner los valores en cadena vacía para los campos que sean string en el swagger
    options.MapType<string>(() => new OpenApiSchema { Example = new OpenApiString("") });
}
);

builder.Services.AddSqlServer<DbConexion>(builder.Configuration.GetConnectionString("DbConnection"));
//builder.Services.AddSqlServer<DbAcceso>(builder.Configuration.GetConnectionString("DbAcceso"));
//DbAcceso se inyecta como un servicio, ya que ahora la conexión es dinámica.
builder.Services.AddScoped<DbAcceso>();

// Registrar el servicio en BusinessLogic que usa IApvenextRepository
builder.Services.AddScoped<IApvenextRepository, ApvenextRepository>();
builder.Services.AddScoped<ApvenextService>();
builder.Services.AddScoped<IApvenfilRepository, ApvenfilRepository>();
builder.Services.AddScoped<ApvenfilService>();

builder.Services.AddScoped<IApopnfilRepository, ApopnfilRepository>();
builder.Services.AddScoped<ApopnfilService>();

builder.Services.AddScoped<ISygendbcRepository, SygendbcRepository>();
builder.Services.AddScoped<SygendbcService>();

builder.Services.AddScoped<ExcelService>();
builder.Services.AddScoped<ConnectionManager>();


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
