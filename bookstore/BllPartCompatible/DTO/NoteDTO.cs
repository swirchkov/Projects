using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalPart.Models;

namespace BllPart.DTO
{
    public class NoteDTO
    {
        public NoteDTO()
        {
        }
        public NoteDTO(Note note)
        {
            this.BookId = note.BookId;
            this.NoteId = note.NoteId;
            this.Page = note.Page;
            this.Text = note.Text;
        }

        public int NoteId { get; set; }
        public int BookId { get; set; }
        public int Page { get; set; }
        public string Text { get; set; }

        public static explicit operator NoteDTO(Note note)
        {
            return new NoteDTO(note);
        }
        public static explicit operator Note(NoteDTO note)
        {
            return new Note()
            {
                BookId = note.BookId,
                NoteId = note.NoteId,
                Page = note.Page,
                Text = note.Text
            };
        }
    }
}
