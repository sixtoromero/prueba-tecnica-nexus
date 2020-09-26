using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaMC.Transversal.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using LaMC.Services.WebAPIRest.Helpers;
using LaMC.Transversal.Common;
using LaMC.Transversal.Logging;
using LaMC.Application.Interface;
using LaMC.Application.Main;
using LaMC.Domain.Interface;
using LaMC.Domain.Core;
using LaMC.InfraStructure.Interface;
using LaMC.InfraStructure.Repository;
using LaMC.InfraStructure.Data;

namespace LaMC.Services.WebAPIRest
{
    public class Startup
    {
        readonly string MiCors = "MiCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));
            
            services.AddMvc(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy(name: this.MiCors, builder =>
                {
                    builder.WithHeaders("*");
                    builder.WithOrigins("*");
                    builder.WithMethods("*");
                });
            });

            //Devolver el JSON tal cual como est� el modelo
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            #region Inyectando Capas

            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            services.AddScoped<IClienteApplication, ClienteApplication>();
            services.AddScoped<IClienteDomain, ClienteDomain>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IMesaApplication, MesaApplication>();
            services.AddScoped<IMesaDomain, MesaDomain>();
            services.AddScoped<IMesaRepository, MesaRepository>();

            services.AddScoped<ICamareroApplication, CamareroApplication>();
            services.AddScoped<ICamareroDomain, CamareroDomain>();
            services.AddScoped<ICamareroRepository, CamareroRepository>();

            services.AddScoped<ICocineroApplication, CocineroApplication>();
            services.AddScoped<ICocineroDomain, CocineroDomain>();
            services.AddScoped<ICocineroRepository, CocineroRepository>();

            services.AddScoped<IFacturaApplication, FacturaApplication>();
            services.AddScoped<IFacturaDomain, FacturaDomain>();
            services.AddScoped<IFacturaRepository, FacturaRepository>();

            #endregion
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));


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

            app.UseCors(this.MiCors);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
