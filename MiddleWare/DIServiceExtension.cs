using BQMS.Api.Implementations;
using BQMS.Api.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BQMS.Api.MiddleWare
{
    public static class DIServiceExtension
    {
		public static void AddDIServices(this IServiceCollection services)
		{
			services.AddTransient<ICategoriesService, CategoriesService>();
			services.AddTransient<IContactsService, ContactsService>();
			services.AddTransient<IDynamics365Service, Dynamics365Service>();
			services.AddTransient<IRequestsService, RequestsService>();
			services.AddTransient<ISubcategoriesService, SubcategoriesService>();
		}
	}
}
