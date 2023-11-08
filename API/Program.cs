using BLL.Services;
using BLL.Services.Implementation;
using DAL.Persistence;
using DAL.Repositories;
using DAL.Repositories.Implementation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddSingleton<CassandraContext>();

// Repositories
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();

// Services
builder.Services.AddScoped<IPersonaService, PersonaService>();

// Add services to the container.
builder.Services.AddAutoMapper(Assembly.Load(nameof(BLL)));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
