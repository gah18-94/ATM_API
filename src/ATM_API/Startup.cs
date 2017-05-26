﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DataAccessLayer;
using Microsoft.Extensions.Configuration;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace ATM_API
{
    public class Startup
    {

        private IHostingEnvironment _env;
        public static IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
              .SetBasePath(_env.ContentRootPath)
              .AddJsonFile("config.json")
             .AddEnvironmentVariables();

            _config = builder.Build();
            
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);
            /*services.AddDbContext<ATM_context>(options =>
            options.UseSqlServer(_config.GetConnectionString("ATMConnection")));
            */
            services.AddMvc();
            var connection = Startup._config["connectionStrings:ATMConnection"];

            services.AddDbContext<ATM_context>(options => options.UseSqlServer(connection));
            services.AddScoped<IATM_Repository, ATM_Repository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }
            
            /*app.UseStatusCodePages();*/
            app.UseMvc();

            /* app.Run(async (context) =>
             {
                 await context.Response.WriteAsync("Hello World!");
             });*/
        }
    }
}
