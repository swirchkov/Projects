using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DalPart.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string AuthorId { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string ImagePath { get; set; }

        public virtual AspNetUsers Author { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
