using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.ML;
using SampleApp.Api.Extensions;
using SampleApp.Api.Loaders;
using SampleApp.Api.Models;
using SampleApp.Api.Services;
using SampleApp.Api.Services.Interfaces;

namespace SampleApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                .ScanAssembly()
                .Configure<ModelOptions>(Configuration.GetSection("Model"));

            AddPredictionEnginePool<FooRegressionPrediction>();
            AddPredictionEnginePool<FooTimeSeriesPrediction>();

            void AddPredictionEnginePool<TPrediction>() where TPrediction : class, new()
            {
                //TODO: This is where I would call AddPredictionEnginePoolServices instead of AddPredictionEnginePool.
                services.AddPredictionEnginePool<FooInput, TPrediction>();

                services.AddSingleton<LazyService<PredictionEnginePool<FooInput, TPrediction>>>();

                services.AddOptions<PredictionEnginePoolOptions<FooInput, TPrediction>>().Configure(pepOptions =>
                {
                    services.AddOptions<TrainModelLoaderOptions>().Configure(tmlOptions =>
                    {
                        tmlOptions.ModelService = services.BuildServiceProvider().GetServices<IModelService>().Single(s => s.CanTrain(typeof(TPrediction)));
                    });

                    pepOptions.ModelLoader = services.BuildServiceProvider().GetService<TrainModelLoader>();
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
    }
}
