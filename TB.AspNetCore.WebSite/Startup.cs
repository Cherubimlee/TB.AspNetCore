using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TB.AspNetCore.Application.Services;
using TB.AspNetCore.Domain.Config;
using TB.AspNetCore.Domain.Contexts;
using TB.AspNetCore.Domain.Repositorys;
using TB.AspNetCore.Infrastructrue.Auth.MvcAuth;
using TB.AspNetCore.Infrastructrue.Caches.Redis;
using TB.AspNetCore.Infrastructrue.Caches.Redis.Extensions;
using TB.AspNetCore.Infrastructrue.Config;
using TB.AspNetCore.Infrastructrue.Extensions;
using TB.AspNetCore.Infrastructrue.Middleware.ErrorHandlerMiddleware;
using TB.AspNetCore.Infrastructrue.Tasks.Quartz;
using TB.AspNetCore.Infrastructrue.Tasks.Quartz.Extensions;

namespace TB.AspNetCore.WebSite
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContextPool<RestApiContext>(
                options => options.UseMySql(ConfigLocator.Instance.Get<string>("MySqlDbConnection"),
                    mysqlOptions =>
                    {
                        mysqlOptions.ServerVersion(new Version(5, 7, 24), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql); // replace with your Server Version and Type
                    }
            ));
            //注入application service
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IJobCenter, JobCenter>();
            services.AddScoped<ITaskService, TaskService>();
            
            //quartz
            services.AddJobService();


            //redis
            services.AddRedisCacheService(redisOptions =>
            {
                return ConfigLocator.Instance.Get<RedisOptions>(TbConstant.RedisOptionsKey);
            })
            .Subscribe<object>(Infrastructrue.Caches.Redis.Models.RedisChannels.TestPubSub, RedisService.SubscribeDoSomething)
            .Subscribe<string>(Infrastructrue.Caches.Redis.Models.RedisChannels.MemberRegister, RedisService.MemberChannel_SubscribeDoSomething);

            services.AddMvcCustomer(option =>
            {
                option.AuthorizationSchemes = new List<MvcAuthorizeOptions> {
                    new MvcAuthorizeOptions()
                    {
                         ReturnUrlParameter="from",
                         AccessDeniedPath="/Denied",
                         AuthenticationScheme=TbConstant.WEBSITE_AUTHENTICATION_SCHEME,
                         LoginPath="/",
                         LogoutPath="/Logout"
                    },
                };
            });

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
            app.UseAuthentication();

            app.UseStaticFiles();
            app.UseCookiePolicy();
            //错误消息处理中间件
            app.UseErrorHandlerMiddleware();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
