using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models
{
    public class BooksDBContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
        public BooksDBContext(DbContextOptions<BooksDBContext> options ):base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL(@"Server=localhost;database=book;uid=root;pwd=123;SslMode=None");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
    [Table("books")]
    public class Books {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal  Price { get; set; }
        public string Author { get; set; }
      

    }
}
