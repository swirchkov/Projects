using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalPart.Models;

namespace BllPart.DTO
{
    public class BookDTO
    {
        public BookDTO()
        {
        }

        public BookDTO(Book b)
        {
            this.BookId = b.BookId;
            this.AuthorId = b.AuthorId;
            this.FileName = b.FileName;
            this.ImagePath = b.ImagePath;
            this.Name = b.Name;
        }
        public int BookId { get; set; }
        public string  AuthorId { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string ImagePath { get; set; }

        public static explicit operator BookDTO(Book b)
        {
            return new BookDTO(b);
        }

        public static explicit operator Book(BookDTO book)
        {
            return new Book()
            {
                ImagePath = book.ImagePath,
                FileName = book.FileName,
                Name = book.Name,
                BookId = book.BookId,
                AuthorId = book.AuthorId
            };
        }
    }
}
