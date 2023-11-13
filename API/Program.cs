using API.Swagger;
using BLL.Services;
using BLL.Services.Implementation;
using DAL.Persistence;
using DAL.Repositories;
using DAL.Repositories.Implementation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomSwaggerGen();

// DbContext
builder.Services.AddSingleton<CassandraContext>();

// Repositories
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IDomicilioRepository, DomicilioRepository>();

// Services
builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IDomicilioService, DomicilioService>();

// Add services to the container.
builder.Services.AddAutoMapper(Assembly.Load(nameof(Models)));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
	app.AddCustomSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
