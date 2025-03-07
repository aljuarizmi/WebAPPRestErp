using BusinessData.Data;
using BusinessData.Interfaces;
using BusinessEntity.Data;
using BusinessLogic.Services;
using Common.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json;
using WebAppRest.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
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
    // **Agregar definici�n de seguridad JWT para Swagger**
    //Agregue una o m�s "securityDefinitions" que describan c�mo se protege su API al Swagger generado.
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
    //A�ade un requisito de seguridad global
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
    //Permite poner los valores en cadena vac�a para los campos que sean string en el swagger
    options.MapType<string>(() => new OpenApiSchema { Example = new OpenApiString("") });
}
);
//Se agrega AddHttpContextAccessor() para poder acceder a las variables guardads en el jwt del token
builder.Services.AddHttpContextAccessor();
//builder.Services.AddSqlServer<DbConexion>(builder.Configuration.GetConnectionString("DbConnection"));
//DbConexion se inyecta como un servicio, ya que ahora la conexi�n es din�mica.
builder.Services.AddScoped<DbConexion>();
//builder.Services.AddSqlServer<DbAcceso>(builder.Configuration.GetConnectionString("DbAcceso"));
//DbAcceso se inyecta como un servicio, ya que ahora la conexi�n es din�mica.
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

builder.Services.AddScoped<ISygengadRepository, SygengadRepository>();
builder.Services.AddScoped<SygengadService>();

builder.Services.AddScoped<ISygenopcRepository, SygenopcRepository>();
builder.Services.AddScoped<SygenopcService>();

builder.Services.AddScoped<ICmcurrteRepository, CmcurrteRepository>();
builder.Services.AddScoped<CmcurrteService>();

builder.Services.AddScoped<ICmcurratRepository, CmcurratRepository>();
builder.Services.AddScoped<CmcurratService>();

builder.Services.AddScoped<ISqlsrchRepository, SqlsrchRepository>();
builder.Services.AddScoped<SqlsrchService>();

builder.Services.AddScoped<ExcelService>();

builder.Services.AddScoped<ConnectionManager>();

builder.Services.AddScoped<AuthService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        //options.TokenValidationParameters = new TokenValidationParameters: Define las reglas para validar los tokens JWT.
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //Activa la validaci�n de la firma del token.
            ValidateIssuerSigningKey = true,
            //Especifica la clave secreta (JWT:Key) para firmar y validar los tokens.
            //Usa una clave sim�trica (SymmetricSecurityKey), lo que significa que la misma clave se usa para firmar y verificar el token.
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            //Deshabilita la validaci�n del emisor (Issuer) y del p�blico (Audience).
            //Esto significa que el token ser� aceptado sin importar de d�nde provenga.
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }
);
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{*/
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
app.UseAuthentication();//Con esto definimos que vamos a usar autentificaci�n
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
app.UseCors("PermitirTodo"); // Habilitar CORS
app.MapControllers();

app.Run();
