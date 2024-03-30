using WebJourneys.Application;
using WebJourneys.Infrastructure;
using WebJourneys.Infrastructure.Data.Extentions;

namespace WebJourneys.Presentation.Configuration
{
    public static class Configuration
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services
                .AddApplicationServices()
                .AddInfrastructureServices(builder.Configuration)
                .AddPresentationServices();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        public static void RegisterMiddlewares(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                //load data
                DataInitializer.SeedData(services);
            }

            //app.UseExceptionHandler();
            app.UseExceptionHandler((_ => { }));
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
