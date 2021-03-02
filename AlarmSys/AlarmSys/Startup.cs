using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActedAlarmService;
using AlarmService;
using AlarmSys.Core.Connection;
using AlarmSys.Core.Interfaces;
using AlarmSys.Core.Providers;
using EquipmentService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AlarmSys
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
            services.AddCors(op =>
            {
                op.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                });
            });
            services.AddControllers();

            services.AddScoped<IDBDriver, SqlDataBaseDriver>(x => new SqlDataBaseDriver(this.Configuration.GetSection("ConnectionString").Value));
            services.AddScoped<ApiConnection>();

            ConfigureServicesDependencyInjection(services);
        }
        private void ConfigureServicesDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<AlarmBO>();
            services.AddScoped<EquipmentBO>();
            services.AddScoped<ActedAlarmBO>();

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

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
