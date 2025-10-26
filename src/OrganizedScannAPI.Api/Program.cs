using Microsoft.OpenApi.Models;
using OrganizedScannApi.Api.Middlewares;
using OrganizedScannApi.Infrastructure;
using OrganizedScannApi.Application.UseCases.Motorcycles;

var builder = WebApplication.CreateBuilder(args);

// Controllers & Swagger with API Versioning
builder.Services.AddControllers();

// API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OrganizedScann API",
        Version = "v1",
        Description = "API para gestão de usuários, motos e portais - Versão 1.0",
        Contact = new OpenApiContact
        {
            Name = "OrganizedScann Team",
            Email = "support@organizedscann.com"
        }
    });

    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "OrganizedScann API",
        Version = "v2",
        Description = "API para gestão de usuários, motos e portais - Versão 2.0 (com novas features)",
        Contact = new OpenApiContact
        {
            Name = "OrganizedScann Team",
            Email = "support@organizedscann.com"
        }
    });

    // Include XML comments
    var xmlFile = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".xml";
    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (System.IO.File.Exists(xmlPath))
        c.IncludeXmlComments(xmlPath);
});

// Infrastructure: MongoDB, Repositories, Health Checks
builder.Services.AddInfrastructure(builder.Configuration);

// CORS
builder.Services.AddCors(o =>
    o.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
);

// Application Services
builder.Services.AddScoped<MotorcycleService>();

var app = builder.Build();

// Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrganizedScann API v1");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "OrganizedScann API v2");
    c.RoutePrefix = "swagger";
});

// Middleware Pipeline
app.UseHttpsRedirection();
app.UseCors();
app.UseMiddleware<ErrorHandlingMiddleware>();

// Health Checks
app.UseHealthChecks("/health");

// Map Controllers
app.MapControllers();

app.Run();
