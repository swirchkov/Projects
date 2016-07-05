using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalPart.Repositories;
using DalPart.Models;
using DalPart;
using BllPart.DTO;
using BllPart;
using BllPart.Interfaces;
using BllPart.Services;
using ConsoleInitializer.DocTests;

namespace ConsoleDbInitializer
{
    class Program
    {

        static void Main(string[] args)
        {
            TxtTester.TestRead();
            //ApplicationContext db = ApplicationContext.Create(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            //AspNetUsers user = db.AspNetUsers.Create();

            //user.Email = "somemail@ko.com";
            //user.Id = Guid.NewGuid().ToString();

            //db.AspNetUsers.Add(user);
            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //bookServiceTest(user);

            //Book b = new Book() { AuthorId = user.Id, Name = "Test" };

            //db.Books.Add(b);

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //Console.WriteLine("user successfully created");
        }

        static void bookServiceTest(AspNetUsers user)
        {
            Constants.Connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            BookDTO book = new BookDTO();

            book.AuthorId = user.Id;
            book.FileName = "some path";
            book.ImagePath = "some other path";
            book.Name = "beatiful";

            IBookContentService bookService = new BookContentService();
            bookService.CreateBook(book);

            book = bookService.SearchBook(name: "beatiful").First();
            Console.WriteLine($"Created book with id - { book.BookId }");

            book.Name = "new name";
            bookService.EditBook(book);

            Console.WriteLine("book edited");
        }
    }
}

