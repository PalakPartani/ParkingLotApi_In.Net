// <copyright file="Startup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotApplication
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using ParkingLotBusinessLayer;
    using ParkingLotRepositoryLayer;

    /// <summary>
    /// Class to initialize.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">initialize the config.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">IserviceCollection Object.</param>
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

             services.AddSingleton<IConfiguration>(this.Configuration);
             services.AddTransient<IParkingLotRepository, ParkingLotRepository>();
             services.AddTransient<IParkingLotService, ParkingLotService>();
             services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Parking Lot API",
                    Version = "v1",
                    Description = "A ASP.NET Core Web API",
                    TermsOfService = new Uri("https://github.com/PalakPartani"),
                    Contact = new OpenApiContact
                    {
                        Name = "Palakk Partani",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/PalakPartani"),
                    },
                });
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">IApplicationBuilder Object.</param>
        /// <param name="env">IHostingEnvironment object.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger(c => { c.SerializeAsV2 = true; });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Parking Lot API");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
        }
    }
}