using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using netcore.Models;

namespace netcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //MySqlConnection con = new MySqlConnection("server=127.0.0.1;database=book;uid=root;pwd=123;charset='gbk';SslMode=None");
            ////新增数据
            //con.Execute("insert into books values(null, '测试', 'http://www.cnblogs.com/linezero/', 18)");
            ////新增数据返回自增id 使用的Dapper 进行操作
            //var id = con.QueryFirst<int>("insert into books values(null, 'linezero', 'http://www.cnblogs.com/linezero/', 18);select last_insert_id();");
            ////修改数据
            //con.Execute("update user set Name = 'linezero123' where Id = @Id", new { Id = id });
            ////查询数据
            //var list = con.Query<Books>("select * from user");
            //foreach (var item in list)
            //{
            //    Console.WriteLine($"用户名：{item.Name} 链接：{item.Price}");
            //}
            ////删除数据
            //con.Execute("delete from user where Id = @Id", new { Id = id });
            //Console.WriteLine("删除数据后的结果");
            //list = con.Query<Books>("select * from books");
            //foreach (var item in list)
            //{
            //    Console.WriteLine($"名称：{item.Name } 价格：{item.Price}");
            //}
            Console.ReadKey();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
