using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoFang.MobileSite.Core;
using MoFang.MobileSite.Core.Model.Config;
using MoFang.MobileSite.Core.Redis;
using MoFang.MobileSite.Data.EntityFramework;
using MoFang.MobileSite.Data.EntityFramework.Context;
using MoFang.MobileSite.Dashboard.Middlewares;

namespace MoFang.MobileSite.Dashboard
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath)
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();
            services.AddDbContext<MoFangMobileSiteContext>(builder =>
            {
                builder.UseMySql(this.Configuration.GetConnectionString("DefaultConnection"), options =>
                {
                    options.MigrationsAssembly("MoFang.MobileSite.Dashboard");
                });
            }, ServiceLifetime.Transient);

            services.Configure<SiteConfiguration>(Configuration.GetSection("Site").Bind);
            services.Configure<RedisOptions>(Configuration.GetSection("Redis").Bind);
            services.Configure<QiniuConfig>(Configuration.GetSection("Qiniu").Bind);
            services.Configure<DashboardConfig>(Configuration.GetSection("Dashboard").Bind);


            services.AddScoped<Core.Security.OASecurityManager>();
            services.AddScoped<Core.File.FileManager>();
            services.AddScoped<Core.Model.ResponseModel>();

            //注册aotumapper
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.AddProfile<AutoMapperConfig>();
            });
            services.AddSingleton(typeof(IMapper), mapperConfiguration.CreateMapper());
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterInstance(this.Configuration).AsImplementedInterfaces();

            builder.RegisterType<RedisProvider>().As<IRedisProvider>().SingleInstance();

            builder.RegisterModule<CoreModule>()
                .RegisterModule<EntityFrameworkModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
