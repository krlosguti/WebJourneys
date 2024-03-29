namespace WebJourneys.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            //connection string
            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app) 
        { 
            //app.MapCarter();
            return app;
        }
    }
}
