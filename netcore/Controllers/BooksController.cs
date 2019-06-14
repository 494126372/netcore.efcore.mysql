using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netcore.Models;

namespace netcore.Controllers
{
    public class BooksController : Controller
    {
        public BooksDBContext _BooksDBContext;
      
        public BooksController(BooksDBContext booksDBContext)
        {
            _BooksDBContext = booksDBContext;
        }
        public IActionResult Index()
        {
            //var books = _BooksDBContext.Books.ToList();
            var book = new Books()
            {
                Name = "zhangsan1",
                
                Price = 24,
                Author="sanmao",
               
            };
            _BooksDBContext.Books.Add(book);
            _BooksDBContext.SaveChanges();
                //User user = new User() { Name = "Herry", CreateTime = DateTime.Now };
                //context.User.Add(user);  
            return View();
        }
    }
}