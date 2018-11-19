﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TvMazeScrapper.Context;
using TvMazeScrapper.Core.Repository;
using TvMazeScrapper.Core.Repository.Impl;
using TvMazeScrapper.Scrapper;

namespace TvMazeScrapper
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }

        public IConfiguration Configuration { get; }
        public IServiceProvider ServiceProvider { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<MazeContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
            services.AddSingleton<MazeContext>();
            services.AddSingleton<ITvShowRepository, TvShowRepository>();
           
            services.AddSingleton<TvShowScrapper>();
            var sp = services.BuildServiceProvider();
            var scrapper = sp.GetService<TvShowScrapper>();
            scrapper.GetShowsFromApi();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            
        }
        
    }
}
