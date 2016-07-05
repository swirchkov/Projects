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
using WebApp.ViewModels.Notes;
using BllPartCompatible.DTO;

namespace WebApp.Controllers
{
    public class NotesController : Controller
    {
        private IBookContentService bookContentService = null;
        private readonly IApplicationEnvironment appEnvironment;

        public NotesController(IBookContentService bookService, IApplicationEnvironment appEnvironment)
        {
            bookContentService = bookService;
            this.appEnvironment = appEnvironment;
        }

        [Authorize]
        public IActionResult Index(int bookId, int page = 0)
        {
            BookDTO book = bookContentService.SearchBook(bookId).FirstOrDefault();

            if (book == null)
            {
                return HttpNotFound();
            }

            PageViewModel pageModel = new PageViewModel();

            pageModel.Page = page;
            pageModel.Title = book.Name;
            pageModel.BookId = book.BookId;

            try
            {
                PageContentDTO content = bookContentService.GetPageContent(book, page);
                pageModel.HtmlContent = content.PageText;
                pageModel.CountPage = content.PageCount;
            }
            catch (ArgumentException)
            {
                return HttpNotFound();
            }
            return View(pageModel);
        }
    }
}
