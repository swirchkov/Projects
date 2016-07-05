using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BllPart.DTO;
using BllPart.Interfaces;
using DalPart.Repositories;
using BllPart.Exceptions;
using DalPart.Models;
using BllPartCompatible.Docs;
using System.IO;
using BllPartCompatible.DTO;

namespace BllPart.Services
{
    public class BookContentService : Service, IBookContentService
    {

        public BookContentService() : base()
        {
        }

        public void CreateBook(BookDTO book)
        {
            if (book.AuthorId == null)
            {
                throw new ArgumentException("No required author id in book");
            }
            if (book.FileName == null)
            {
                throw new ArgumentException("No book file");
            }

            if (unit.Books.Find(b => b.AuthorId == book.AuthorId && b.Name == book.Name).Count() > 0)
            {
                throw new ArgumentException("You've already loaded book with such name");
            }

            unit.Books.Create((Book)book);
            unit.Save();
        }

        public void Delete(int bookId)
        {
            Book book = unit.Books.Find(b => b.BookId == bookId).First();
            File.Delete(book.FileName);
            // cannot find some better than allow possible exception to go up
            unit.Books.Delete(bookId);
            unit.Save();
        }

        public void EditBook(BookDTO book)
        {
            Book srcBook = unit.Books.Find(b => b.BookId == book.BookId).FirstOrDefault();

            if (srcBook == null)
                throw new ArgumentException("No book with given id");

            // don't consider as mistake just nothing to do
            if (srcBook.AuthorId == book.AuthorId && srcBook.FileName == book.FileName && srcBook.ImagePath == book.ImagePath && srcBook.Name == book.Name)
                return;

            unit.Books.Update((Book)book);
            unit.Save();
        }

        public IEnumerable<BookDTO> SearchBook(int bookId = -1, string authorId = null, string name = null, string fileName = null, string imagePath = null)
        {
            return unit.Books.Find(b => (bookId == -1 || b.BookId == bookId) &&
                                        (authorId == null || b.AuthorId == authorId) &&
                                        (name == null || b.Name == name) &&
                                        (fileName == null || b.FileName == fileName) &&
                                        (imagePath == null || b.ImagePath == imagePath)).Select(b => (BookDTO)b);
        }

        public void SaveAsXmlFile(BookDTO book)
        {
            FileConverter converter = new FileConverter();

            // convert to xml base format
            if (!converter.TryConvert(book.FileName, book.FileName.Replace("txt", "xml")))
            {
                throw new WrongExtensionException();
            }

            // delete old file
            File.Delete(book.FileName);

            // store in db current value
            book.FileName = book.FileName.Replace("txt", "xml");

            Book dbBook = unit.Books.Find(b => b.AuthorId == book.AuthorId && b.Name == book.Name).First();

            dbBook.FileName = book.FileName;

            unit.Books.Update(dbBook);
            unit.Save();

        }

        public PageContentDTO GetPageContent(BookDTO book, int page)
        {
            IEnumerable<Page> pages = XmlParser.ParseFile(book.FileName);

            if (pages.Count() < page)
            {
                throw new ArgumentException("no such page");
            }

            return new PageContentDTO()
            {
                PageText = pages.ElementAt(page).ToString(),
                PageCount = pages.Count() + 1
            };
        }
    }
}
