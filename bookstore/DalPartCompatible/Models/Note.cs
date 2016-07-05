using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalPart.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public int BookId { get; set; }
        public int Page { get; set; }
        public string Text { get; set; }

        public Book Book { get; set; }
    }
}
