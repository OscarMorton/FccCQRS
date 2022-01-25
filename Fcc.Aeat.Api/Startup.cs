using Fcc.Aeat.core.Data;
using Fcc.Aeat.Factura.Contracts.Contracts;
using Fcc.Aeat.Factura.Contracts.Repositories;
using Fcc.Aeat.Factura.Handlers;
using Fcc.Aeat.Factura.Managers;
using Fcc.Aeat.Factura.Queries.Impl;
using Fcc.Aeat.Factura.Queries.Interfaces;
using Fcc.Aeat.Factura.Repositorys;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Fcc.Aeat.Api
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
            ConfigureManagers(services);
            ConfigureHandlers(services);
            configureServiceQueries(services);
            ConfigureDapperConnectionStrings(services);
            ConfigureServiceRepositories(services);

            // Validations

            services.AddControllers().AddFluentValidation(s =>
           {
               s.RegisterValidatorsFromAssemblyContaining<Startup>(); // Adding validation
               s.DisableDataAnnotationsValidation = true;
           });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fcc.Aeat.Api", Version = "v1" });
            });
        }

        private void configureServiceQueries(IServiceCollection services)
        {
            services.AddScoped<IFacturaQueries, FacturaQueries>();
        }

        private void ConfigureDapperConnectionStrings(IServiceCollection servies)
        {
            string FccConnectionString
                = Configuration.GetConnectionString("FccConnectionString");
            var connectionString = new ConnectionString(FccConnectionString);
            servies.AddSingleton(connectionString); // Es un singleton por que es un paramentro de configuracion
        }

        private void ConfigureHandlers(IServiceCollection services)
        {
            services.AddMediatR(
                typeof(FacturaAddCommandHandler).Assembly);
        }

        private void ConfigureManagers(IServiceCollection services)
        {
            services.AddScoped<IAddFacturaManager, AddFacturaManager>();
            services.AddScoped<IDeleteFacturaManager, DeleteFacturaManager>();
            services.AddScoped<IUpdateFacturaManager, UpdateFacturaManager>();
        }

        private void ConfigureServiceRepositories(IServiceCollection services)
        {
            services.AddScoped<IFacturaRepository, FacturaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fcc.Aeat.Api v1"));
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