using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels.Home
{
    public class BookCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        public IFormFile Image { get; set; }
        [Required]
        public IFormFile Book { get; set; }
    }
}
