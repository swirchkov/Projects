using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalPart.Models;
using DalPart.Repositories;
using BllPart.DTO;
using BllPart.Interfaces;
using BllPart.Exceptions;

namespace BllPart.Services
{
    public class NoteService : Service, INoteService
    {
        public NoteService() : base()
        {
        }

        public void CreateNote(NoteDTO note)
        {
            if (note.BookId == 0)
            {
                throw new ArgumentException("Note object require related book");
            }

            unit.Notes.Create((Note)note);
            unit.Save();
        }

        public void DeleteNote(int noteId)
        {
            // allow up exception from repository
            unit.Notes.Delete(noteId);
            unit.Save();
        }

        public IEnumerable<NoteDTO> SearchNotes(int noteId = -1, int bookId = -1, int page = -1, string text = null)
        {
            return unit.Notes.Find(n => (noteId == -1 || n.NoteId == noteId) &&
                                        (bookId == -1 || n.BookId == bookId) &&
                                        (page == -1 || n.Page == page) &&
                                        (text == null || n.Text == text)).Select(n => (NoteDTO)n);
        }

        public void UpdateNote(NoteDTO note)
        {
            Note srcNote = unit.Notes.Find(n => n.NoteId == note.NoteId).FirstOrDefault();

            if (srcNote == null)
                throw new ArgumentException("No note with given id");

            // don't consider as mistake just nothing to do
            if (srcNote.BookId == note.BookId && srcNote.BookId == note.BookId && srcNote.Page == note.Page && srcNote.Text == note.Text)
                return;

            unit.Notes.Update((Note)note);
            unit.Save();
        }
    }
}
