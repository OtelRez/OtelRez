using OtelRez.BL.Managers.Abstract;
using OtelRez.BL.Managers.Concrete;
using OtelRez.DAL.Repositories.Abstract;
using OtelRez.DAL.Repositories.Concrete;

namespace OtelRez.MVC.Extensions
{
    public static class OtelExtensions
    {
        public static IServiceCollection AddOtelService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IManager<>), typeof(Manager<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
