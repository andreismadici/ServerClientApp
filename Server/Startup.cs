using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServerMagazin.Data;
using Newtonsoft.Json.Serialization;
using ServerMagazin.ComandaAlgorithm;

namespace ServerMagazin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CommanderContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("CommanderConnection")));

            services.AddControllers().AddNewtonsoftJson( s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddCors(o => {
                o.AddPolicy(MyAllowSpecificOrigins, b => { b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
            });
            /*services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.WithOrigins(
                    "http://localhost:5000/",
                    "http://apirequest.io")
                    .WithMethods("POST","GET","PUT")
                    .WithHeaders("*")
                    );
            });*/

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //services.AddScoped<IClientRepository,  MockClientRepository>();
            services.AddScoped<IClientRepository,  SqlClientRepository>();
            services.AddScoped<IComandaRepository,  SqlComandaRepository>();
            services.AddScoped<ISlabComandaRepository,  SqlSlabComandaRepository>();
            services.AddScoped<ISlabStocRepository,  SqlSlabStocRepository>();
            services.AddScoped<ComAlgorithm>();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(MyAllowSpecificOrigins);
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
