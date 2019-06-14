using asp.netmvc.mysql.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.netmvc.mysql.Controllers
{
    public class BooksController : Controller
    {
        public bookEntities _bookEntities;
        public BooksController()
        {
            //_bookEntities = bookEntities;
        }
        // GET: Books
        public ActionResult Index()
        {
            _bookEntities = new bookEntities();
         List<books> books=  _bookEntities.books.ToList();
            return View(books);
        }
    }
}