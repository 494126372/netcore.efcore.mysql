using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using netcore.Models;

using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace netcore
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
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
              
            });
            // 第一步codefirst 添加MySql.Data.EntityFrameworkCore NuGet包  
            // 迁移就是已有的数据库就不需要迁移也就没有Migrations文件夹 
            //Enable - Migrations 启用迁移

            //Add - Migration 为挂起的Model变化添加迁移脚本

            //Update - Database 将挂起的迁移更新到数据库

            //  mysql 的迁移好像原来的上面迁移命令不能用 只能使用下面的cli 命令
            //Get - Migrations 获取已经应用的迁移
            // 想迁移文件夹创建的话就安装  Microsoft.EntityFrameworkCore  专门迁移 不然命令无效
            // 已有的没文件夹想创建库对应文件夹迁移 
            // Cmd 项目文件夹下dotnet ef  migrations add InitialCreate  已有的会更新不会删除
            // dotnet ef migrations remove 删除迁移，并确保正确重置快照
            //在命令窗口中，输入以下命令以创建数据库并在其中创建表。(在配置文件中修改库名称之后会自动创建新库和表)
            //console
            //复制
            //dotnet ef database update  
            var connection = Configuration.GetConnectionString("MysqlConnection");
            services.AddDbContext<BooksDBContext>(options => options.UseMySQL(connection));
            services.AddMvc();
          
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           

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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // 中间件 
            app.UseCookiePolicy();
            //app.Use(async (context, next) =>
            //{

            //    //await context.Response.WriteAsync($"中间件:evn is " + env);

            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
