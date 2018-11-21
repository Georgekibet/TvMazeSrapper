using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Impl;
using TvMazeScrapper.Context;
using TvMazeScrapper.Core.Repository;
using TvMazeScrapper.Core.Repository.Impl;
using TvMazeScrapper.Jobs;
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

      
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<MazeContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")), ServiceLifetime.Scoped);
            
            services.AddTransient<ITvShowRepository, TvShowRepository>();
            services.AddSingleton<TvShowScrapper>();
            services.AddTransient<ScrapJob>();
            var sp = services.BuildServiceProvider();
            ConfigureScrapJob(sp);
           
        }

        private async void ConfigureScrapJob(IServiceProvider serviceProvider)
        {
            var jobFactory = new JobFactory(serviceProvider);
            var scedulerFactory= new StdSchedulerFactory();
            var scheduler = await scedulerFactory.GetScheduler();
            scheduler.JobFactory = jobFactory;
            var startTime = DateBuilder.FutureDate(2, IntervalUnit.Second);
            await   scheduler.Start();

            ITrigger checkServerTrigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartAt(startTime)
                .WithSimpleSchedule(x => x
                    .WithIntervalInHours(4)
                    .RepeatForever())
                .Build();
           
            var scrapJob = JobBuilder.Create<ScrapJob>().Build();
            await scheduler.ScheduleJob(scrapJob, checkServerTrigger);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          
            app.UseMvc();
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService <MazeContext> ();
                if (!context.Database.EnsureCreated())
                    context.Database.Migrate();
            }

        }
        
    }
}
