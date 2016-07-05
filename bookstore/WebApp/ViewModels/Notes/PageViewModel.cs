using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels.Notes
{
    public class PageViewModel
    {
        public string HtmlContent { get; set; }
        public int Page { get; set; }
        public string Title { get; set; }
        public int BookId { get; set; }
        public int CountPage { get; set; }
    }
}
