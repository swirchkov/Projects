using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BllPart.DTO;
using BllPartCompatible.DTO;

namespace BllPart.Interfaces
{
    public interface IBookContentService
    {
        IEnumerable<BookDTO> SearchBook(int bookId = -1, string authorId = null, string name = null, string fileName = null,
            string imagePath = null); 
        void CreateBook(BookDTO book);
        void EditBook(BookDTO book);
        void Delete(int bookId);

        void SaveAsXmlFile(BookDTO book);
        PageContentDTO GetPageContent(BookDTO book, int page = 0);
    }
}
