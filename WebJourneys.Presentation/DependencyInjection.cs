using WebJourneys.Presentation.Middleware;

namespace WebJourneys.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app) 
        { 
            //app.MapCarter();
            return app;
        }
    }
}
