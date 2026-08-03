using CleanArchitecture.Api.Extensions;
using CleanArchitecture.Api.OptionsSetup;
using CleanArchitecture.Application;
using CleanArchitecture.Application.Abstractions.Authentication;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();

// 1. Configurar las opciones PRIMERO para que estén listas al registrar el JWT
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionSetup>();

// 2. Registrar dependencias de la aplicación y autenticación
builder.Services.AddTransient<IJwtProvider, JwtProvider>();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// 3. Registrar autenticación UNA SOLA VEZ
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddAuthorization();
builder.Services
    .AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.ApplyMigration();
app.SeedData();
app.SeedDataAuthentication();

// 1. PRIMERO: Capturar y propagar el CorrelationId (Debe ir al inicio absoluto)
app.UseRequestContextLogging();

// 2. Manejo de excepciones global (para atrapar errores con su CorrelationId)
app.UseCustomExceptionHandler();

// 3. Logging automático de peticiones de Serilog
app.UseSerilogRequestLogging();

// 4. Seguridad (Authentication ANTES de Authorization)
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();