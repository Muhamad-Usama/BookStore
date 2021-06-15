using BookA.Models;
using BookA.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookA.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _reps = null;
            public BookController()
        {
            _reps = new BookRepository();
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        
        public ViewResult GetAllBooks()
        {
            var data= _reps.GetAllBooks();
            return View(data);
        }
        [Route("Book-Details/{id}",Name ="BookdetailsRoute")]
        public ViewResult GetByid(int id)
        {
            var data= _reps.GetBookById(id);
            return View(data);
        }
        public List<BookModel> GetSearch(string bookname,string athorn)
        {
            return _reps.SearchBook(bookname, athorn);
        }
        public ViewResult AddNewBook()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddNewBook(BookModel book)
        {
            return View();
        }
    }
}
