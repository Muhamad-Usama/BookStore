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
            public BookController(BookRepository repository)
        {
            _reps = repository;
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
        public ViewResult AddNewBook(bool Issuccess=false)
        {
            ViewBag.issuccess = Issuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel book)
        {
            int id = await _reps.AddNewBook(book);
            if(id>0)
            {
                return RedirectToAction(nameof(AddNewBook),new { Issuccess =true});
            }
            
            return View();
        }
    }
}
