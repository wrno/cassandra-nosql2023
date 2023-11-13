using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.RegularExpressions;

namespace API.Swagger;

internal class PagingStateOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (Regex.IsMatch(context.ApiDescription.RelativePath ?? string.Empty, @"^/?api/domicilio/persona/[0-9]*", RegexOptions.IgnoreCase))
        {
			if (operation.Parameters == null)
				operation.Parameters = new List<OpenApiParameter>();

			operation.Parameters.Add(new OpenApiParameter
			{
				Name = "X-PagingState",
				In = ParameterLocation.Header,
				Description = "Sirve para obtener la siguiente página de la consulta.",
				Required = false,
				Schema = new OpenApiSchema
				{
					Type = "string"
				}
			});
		}
    }
}
