using System;
using App.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScheduleApi.DataAccess;
using Swashbuckle.AspNetCore.Swagger;


namespace App
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
            var connectionString = Configuration["POSTGRES_STRING"] ?? "Host=localhost;Port=5432;Database=schedule_api_db_3;Username=postgres;Password=pass";
            var herokuString = Configuration["HEROKU_STRING"] ?? "";
            if (herokuString != "")
            {
                // [database type]://[username]:[password]@[host]:[port]/[database name]
                var list = herokuString.Split(':');
                var username = list[1].Substring(2);
                var passHost = list[2].Split('@');
                var password = passHost[0];
                var host = passHost[1];
                var portDbName = list[3].Split('/');
                var port = portDbName[0];
                var dbName = portDbName[1];

                connectionString = $"Host={host};Port={port};Database={dbName};Username={username};Password={password}";
            }

            ScheduleContext.ConnectionString = connectionString;
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ScheduleContext>(options => options.UseNpgsql(connectionString));

            services.AddMvc();

            //services.AddTransient<IUnitOfWork, UnitOfWork>();

            AutoMapperInitializer.Initialize();

            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new Info()
                {
                    Title = "Schedule API",
                    Version = "v1"
                })
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/"); 
            }

            app.UseMvc();

            try
            {
                using (var serviceScope =
                    app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<ScheduleContext>().Database.Migrate();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nMigrating Error\n");
            }
            

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Schedule API v1")
                //c.SwaggerEndpoint("/api/docs", "api v1")
            );
        }
    }
}
