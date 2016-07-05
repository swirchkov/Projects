using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalPart.Models;

namespace DalPart.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private string connection;

        private IRepository<Book> books;
        private IRepository<Note> notes;

        private ApplicationContext db;

        public UnitOfWork(string connection)
        {
            this.connection = connection;
            db = ApplicationContext.Create(connection);
        }

        public IRepository<Book> Books
        {
            get
            {
                if (books == null)
                    books = new BookRepository(connection);

                return books;
            }
        }

        public IRepository<Note> Notes
        {
            get
            {
                return notes ?? new NoteRepository(connection);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                disposedValue = true;
            }
        }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
