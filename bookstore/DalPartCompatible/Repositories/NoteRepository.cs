using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalPart.Models;
using System.Data.Entity;

namespace DalPart.Repositories
{
    public class NoteRepository : IRepository<Note>
    {
        private ApplicationContext db;

        public NoteRepository(string connection)
        {
            db = ApplicationContext.Create(connection);
        }

        public void Create(Note item) => db.Notes.Add(item);

        public void Delete(int id)
        {
            Note item = db.Notes.FirstOrDefault(n => n.NoteId == id);

            if (item == null)
                throw new ArgumentException("Invalid id for note - " + id);

            db.Notes.Remove(item);
        }

        public IEnumerable<Note> Find(Func<Note, bool> predicate) => db.Notes.Where(predicate);

        public void Update(Note item)
        {
            Note src = db.Notes.Where(n => n.NoteId == item.NoteId).First();

            if (src == null)
                throw new ArgumentException("No note with given id");

            src.BookId = item.BookId != 0 ? item.BookId : src.BookId;
            src.NoteId = item.NoteId != 0 ? item.NoteId : src.NoteId;
            src.Page = item.Page != 0 ? item.Page : src.Page;
            src.Text = item.Text != null ? item.Text : src.Text;

        }
    }
}
