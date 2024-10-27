using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

public static class SwaggerConfig
{
    public static void AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "MediCares Solution API",
                Version = "v1",
                Description = "This API allows you to manage healthcare solutions effectively. " +
                              "For API documentation, please reach out at solutionmedicares@gmail.com."
            });
        });
    }
}
