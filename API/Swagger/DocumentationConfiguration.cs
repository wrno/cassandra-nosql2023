using Microsoft.OpenApi.Models;
using System.Reflection;

namespace API.Swagger;
internal static class DocumentationConfiguration
{
    internal static void AddCustomSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>                                                   // Replaces default Swagger Config
        {
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Version = "1.0.0",
                    Title = "cassandra-nosql2023",
                    Description = @"
                        Laboratorio 2 de Taller de Bases de Datos NoSQL 2023 utilizando Apache Cassandra.
                        "
				});

            // Add custom filters
            options.OperationFilter<PagingStateOperationFilter>();
        });
    }

    internal static void AddCustomSwaggerUI(this IApplicationBuilder app)
    {
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "cassandra-nosql2023");
        });
    }
}
