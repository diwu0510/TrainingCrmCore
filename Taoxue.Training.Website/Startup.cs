using AutoMapper;
using HZC.Database;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taoxue.Training.Services;

namespace Taoxue.Training.Website
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public ILoggerRepository loggerRepository;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            loggerRepository = LogManager.CreateRepository(Log4NetConfig.RepositoryName);
            XmlConfigurator.ConfigureAndWatch(loggerRepository, new System.IO.FileInfo("Config/Log4net.config"));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // 使用分布式缓存
            // services.AddDistributedMemoryCache();

            // 启用Session
            services.AddSession();

            // 初始化数据库工具
            MyDbUtil.Init(Configuration);

            // 初始化并添加AutoMapper
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ServicesProfile>();
            });
            services.AddAutoMapper();

            // 压缩输出
            services.AddResponseCompression();

            // cookie身份验证
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opts =>
                {
                    opts.Cookie.Name = "Taoxue.Training.Core";
                    opts.Cookie.HttpOnly = true;
                    opts.LoginPath = "/Login";
                    opts.LogoutPath = "/Home/Logout";
                });
            services
                .AddAuthorization(opts =>
                {
                    opts.AddPolicy("AdminOnly", policy => policy.RequireRole("admin"));
                    opts.AddPolicy("ManagerOnly", policy => policy.RequireRole("manager")); 
                });

            // senparc使用本地缓存必须注册此服务
            services.AddMemoryCache();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

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

            // 启用身份验证
            app.UseAuthentication();

            // 启用Session
            app.UseSession();

            // 压缩输出
            app.UseResponseCompression();

            // 配置区域路由
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areaRoute",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
