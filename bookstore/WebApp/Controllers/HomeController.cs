using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using BllPart.Interfaces;
using BllPart.DTO;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using WebApp.ViewModels.Home;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNet.Http;
using BllPart.Exceptions;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IBookContentService bookContentService = null;
        private readonly IApplicationEnvironment appEnvironment;

        private readonly string[] imageExtensions = new string[] { "jpg", "gif", "png", "jpeg", "bmp" };
        private readonly string[] fileExtensions = new string[] { "txt", "doc", "docx" };

        public HomeController(IBookContentService bookService, IApplicationEnvironment appEnvironment)
        {
            bookContentService = bookService;
            this.appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Books", "Home");
            }

            return View();
        }

        [Authorize]
        public IActionResult Books()
        {
            //find book
            IEnumerable<BookDTO> books = bookContentService.SearchBook(authorId: User.GetUserId());
            return View(books);
        }

        public IActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBook(BookCreateViewModel model)
        {
            // model validation

            string imageName = ContentDispositionHeaderValue.Parse(model.Image.ContentDisposition).FileName.Trim('"');
            string bookFileName = ContentDispositionHeaderValue.Parse(model.Book.ContentDisposition).FileName.Trim('"');
            // image file validation        
            if (!imageExtensions.Contains(imageName.Split('.').Last()))
            {
                ModelState.AddModelError("Image", "Неверный формат файла");
                return View();
            }
            // file validation
            if (!fileExtensions.Contains(bookFileName.Split('.').Last()))
            {
                ModelState.AddModelError("Book", "Неверный формат файла");
                return View();
            }

            BookDTO book = new BookDTO();

            book.AuthorId = User.GetUserId();
            book.Name = model.Name;

            book.FileName = ContentDispositionHeaderValue.Parse(model.Book.ContentDisposition).FileName.Trim('"');
            book.FileName = Path.Combine(appEnvironment.ApplicationBasePath, "wwwroot", "files", "books", book.FileName);
            book.ImagePath = "/images/books/" + imageName;

            try
            {
                bookContentService.CreateBook(book);
            }
            catch (WrongExtensionException)
            {
                ModelState.AddModelError("Book", "Неверный формат файла");
                return View();
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError("Book", e.Message);
                return View();
            }

            model.Book.SaveAs(Path.Combine(appEnvironment.ApplicationBasePath, "wwwroot", "files", "books", bookFileName));

            try
            {
                bookContentService.SaveAsXmlFile(book);
            }
            catch (WrongExtensionException)
            {
                bookContentService.Delete(book.BookId);
                ModelState.AddModelError("Book", "Неверный формат файла");
                return View();
            }

            model.Image.SaveAs(Path.Combine(appEnvironment.ApplicationBasePath, "wwwroot", "images", "books", imageName));

            return RedirectToAction("Books");
        }

        public IActionResult DeleteBook(int bookId)
        {
            try
            {
                bookContentService.Delete(bookId);
            }
            catch (ArgumentException e)
            {
                return Json(new { success = false, message = e.Message });
            }
            return Json(new { success=true });
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
