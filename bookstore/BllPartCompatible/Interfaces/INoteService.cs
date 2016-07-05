using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BllPart.DTO;

namespace BllPart.Interfaces
{
    public interface INoteService
    {
        IEnumerable<NoteDTO> SearchNotes(int noteId = -1, int bookId = -1, int page = -1, string text = null);

        void CreateNote(NoteDTO note);
        void UpdateNote(NoteDTO note);
        void DeleteNote(int noteId);
    }
}
