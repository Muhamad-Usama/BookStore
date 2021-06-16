using BookA.Data;
using BookA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookA.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                Category=model.Category,
                Description=model.Description,
                Language=model.Language,
                Title=model.Title,
                Total_Pages=model.Total_Pages,
                Tags=model.Tags
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.id;
        }
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
                new BookModel(){id=1,Title="MVC",Author="Nitish",Description="This is a Book of MVC for beginners",Language="English",Total_Pages="1254",Category="Programming"},
                new BookModel(){id=2,Title="Hi",Author="Usama", Description="This is a book for just chill purpose",Language="English",Total_Pages="527",Category="Fun"},
                new BookModel(){id=3,Title="Ego",Author="Ali",Description="This is Great Book of Ego Control you must read this book!",Language="English",Total_Pages="927",Category="Motivation"},
                new BookModel(){id=4,Title="C# for Beginners",Author="Bilal",Description="This is a Book of C# for beginners",Language="English",Total_Pages="891",Category="Programming"},
                new BookModel(){id=5,Title="Jacob Ranodsy",Author="Ahmad",Description="This is a Book based on lisfe history",Language="English",Total_Pages="894",Category="History"},
            };
        }
    }
}
