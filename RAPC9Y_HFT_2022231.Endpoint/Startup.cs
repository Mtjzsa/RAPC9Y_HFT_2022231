using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RAPC9Y_HFT_2022231.Logic;
using RAPC9Y_HFT_2022231.Models;
using RAPC9Y_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAPC9Y_HFT_2022231.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<LoLDbContext>();

            services.AddTransient<IRepository<Champions>, ChampionRepository>();
            services.AddTransient<IRepository<Lanes>, LaneRepository>();
            services.AddTransient<IRepository<Regions>, RegionRepository>();

            services.AddTransient<IChampionLogic, ChampionLogic>();
            services.AddTransient<ILaneLogic, LaneLogic>();
            services.AddTransient<IRegionLogic, RegionLogic>();

            services.AddControllers();

            services.AddSwaggerGen(t =>
            {
                t.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "RAPC9Y_HFT_202223.Endpoint",
                    Version = "v1",
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(t=>t.SwaggerEndpoint("/swagger/v1/swagger.json", "RAPC9Y_HFT_202223.Endpoint v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
