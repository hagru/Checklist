using Checklist.Interfaces;
using Checklist.Models;
using Checklist.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checklist
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Register databases
            services.AddDbContext<MemoryDatabaseContext>();
            services.AddEntityFrameworkInMemoryDatabase();

            // Register repositories
            services.AddScoped<ICheckItemRepository, CheckItemRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Checklist", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Checklist v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private async static void AddInMemoryTestData(MemoryDatabaseContext context)
        {
            var itemList = new List<CheckItem>
            {
                new CheckItem
                {
                    Id = "0",
                    Owner = "Tolli",
                    Content = "Schpaell"
                },
                new CheckItem
                {
                    Id = "1",
                    Owner = "Wessel",
                    Content = "Rydde"
                },
                new CheckItem
                {
                    Id = "2",
                    Owner = "Hagru",
                    Content = "Vaske"
                },
                new CheckItem
                {
                    Id = "3",
                    Owner = "Christian",
                    Content = "Støvsuge"
                }
            };

            await context.CheckItems.AddRangeAsync(itemList);
            await context.SaveChangesAsync();

        }

    }
}
