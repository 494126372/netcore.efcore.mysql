using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace asp.netmvc.mysql.Models
{
    public class BooksDBContext:DbContext
    {
        public BooksDBContext():base("name=constr")
        {
            // 1 . 安装NuGet安装 MySql.Data.EntityFramework  ( MySql.Data   EntityFrameWork 后面这两个跟前一个是一个功能 建议前一个) 
            // 安装 Connector/NET 8.0.12 https://dev.mysql.com/downloads/connector/net/
            //安装：Mysql for Visual Studio 1.1.1  (这个是MySQL Database (MySQL Data Provider)ef添加关键)
            //下载位置：https://cdn.mysql.com/Downloads/MySQLInstaller/mysql-visualstudio-plugin-1.1.1.msi
            // 创建DB上下文 连接字符串放在最后配置文件下 上下文使用dbfirst的话就不需要创建了
            // MySql.Data.EntityFramework 
            // 方法“MySql.Data.Entity.EFMySqlCommand.set_DbConnection(System.Data.Common.DbConnection)”尝试访问方法“MySql.Data.MySqlClient.MySqlConnection.get_Settings()”失败。
            // 报错解决  原来是使用的MySql.Data使用的版本过高，默认使用了最新的8.0.15
            // 解决方案一：将MySql.Data的版本改成6.10.8版本。
            //解决方案二：NuGet卸载MySql.Data.Entity，安装MySql.Data.EntityFramework。（未测试）
        }
        public DbSet<Books> _books { get; set; }
    }
    public class Books
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }


    }
}