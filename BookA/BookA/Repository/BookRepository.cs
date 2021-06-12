using BookA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookA.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title,string authorname)
        {
            return DataSource().Where(x => x.Title == title || x.Author == authorname).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){id=1,Title="MVC",Author="Nitish"},
                new BookModel(){id=2,Title="Hi",Author="Usama"},
                new BookModel(){id=3,Title="Ego",Author="Ali"},
            };
        }
    }
}
