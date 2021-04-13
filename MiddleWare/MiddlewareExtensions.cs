using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BQMS.Api.MiddleWare
{
    public static class MiddlewareExtensions
    {
		public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(cfg =>
			{
				cfg.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Bumba API",
					Version = "v3",
					Description = "Bumba Api",
					License = new OpenApiLicense
					{
						// Name = "MIT",
					},
				});

			});

			return services;
		}

		public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
		{
			app.UseSwagger().UseSwaggerUI(options =>
			{
				options.DocumentTitle = "Bumba API";
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "Bumba API");
				options.RoutePrefix = string.Empty;
			});

			return app;
		}
	}
}
