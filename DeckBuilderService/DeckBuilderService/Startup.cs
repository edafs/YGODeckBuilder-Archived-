using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using DeckBuilderService.Repository;
using DeckBuilderService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DeckBuilderService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        ///     This method gets called by the runtime.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Set Catalog dependencies.
            services.AddSingleton<SetCatalogService>();
            services.AddSingleton<SetCatalogRepo>();

            ConfigureAWS(services);
        }

        /// <summary>
        //      This method gets called by the runtime.
        ///     Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        ///     Configure AWS stuff.
        /// </summary>
        private void ConfigureAWS(IServiceCollection services)
        {
            services.AddAWSService<IAmazonDynamoDB>();

            // Use the default AWS Profile installed on machine.
            services.AddDefaultAWSOptions(
                new AWSOptions
                {
                    Region = RegionEndpoint.GetBySystemName("us-east-2")
                }
            );
        }
    }
}
