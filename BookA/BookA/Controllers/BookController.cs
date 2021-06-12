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
        public List<BookModel> GetAllBooks()
        {
            return _reps.GetAllBooks();
        }
        public BookModel GetByid(int id)
        {
            return _reps.GetBookById(id);
        }
        public List<BookModel> GetSearch(string bookname,string athorn)
        {
            return _reps.SearchBook(bookname, athorn);
        }
    }
}
