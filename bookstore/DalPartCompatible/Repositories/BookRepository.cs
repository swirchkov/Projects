using System;
using System.Collections.Generic;
using System.Linq;
using DalPart.Models;
using System.Data.Entity;

namespace DalPart.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private ApplicationContext db;
        public BookRepository(string connection)
        {
            db = ApplicationContext.Create(connection);
        }

        public void Create(Book item) => db.Books.Add(item);

        public void Delete(int id)
        {
            Book item = db.Books.FirstOrDefault(b => b.BookId == id);

            if (item == null)
                throw new ArgumentException("Invalid id for book - " + id);

            db.Books.Remove(item);
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate) => db.Books.Where(predicate);

        public void Update(Book item)
        {
            Book src = db.Books.Where(b => b.BookId == item.BookId).FirstOrDefault();

            if (src == null)
                throw new ArgumentException("Not found book with such id");

            src.AuthorId = item.AuthorId != null ? item.AuthorId : src.AuthorId;
            src.FileName = item.FileName != null ? item.FileName : src.FileName;
            src.Name = item.Name != null ? item.Name : src.Name;
            src.ImagePath = item.ImagePath != null ? item.ImagePath : src.ImagePath;
        }
    }
}
