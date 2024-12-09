using OtelRez.BL.Managers.Abstract;
using OtelRez.BL.Managers.Concrete;

namespace OtelRez.MVC.Extensions
{
    public static class OtelExtensions
    {
        public static IServiceCollection AddOtelService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IManager<>), typeof(Manager<>));

            return services;
        }
    }
}
