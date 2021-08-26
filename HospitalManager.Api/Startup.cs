using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManager.Api.Data;
using HospitalManager.Api.Hospitals;
using HospitalManager.Api.Patients;
using HospitalManager.Api.Rooms;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace HospitalManager.Api
{
    public class Startup
    {
        private const string ConnectionString = "ConnectionStrings:Default";
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHospitalService, HospitalService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IPatientService, PatientService>();

            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlite(Configuration[ConnectionString]));
            
            services.AddControllers();
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
