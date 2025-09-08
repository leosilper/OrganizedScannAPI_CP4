using Microsoft.OpenApi.Models;
using OrganizedScannApi.Api.Middlewares;
using OrganizedScannApi.Infrastructure;
using OrganizedScannApi.Application.UseCases.Motorcycles; // <- SERVICE da aplicação

var builder = WebApplication.CreateBuilder(args);

// Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OrganizedScann API",
        Version = "v1",
        Description = "API para gestão de usuários, motos e portais"
    });

    // Inclui comentários XML do assembly (se existir) para descrever endpoints
    var xmlFile = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".xml";
    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (System.IO.File.Exists(xmlPath))
        c.IncludeXmlComments(xmlPath);
});

// Infraestrutura: DbContext e demais serviços da camada Infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

// CORS
builder.Services.AddCors(o =>
    o.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
);

// Application Services (injeção para os controllers)
builder.Services.AddScoped<MotorcycleService>(); // <- registra a service usada pelo MotorcycleController

var app = builder.Build();

// Swagger (deixando sempre ligado; se preferir, condicione a Development)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrganizedScann API v1");
    c.RoutePrefix = "swagger";
});

// Pipeline
app.UseHttpsRedirection();
app.UseCors();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
