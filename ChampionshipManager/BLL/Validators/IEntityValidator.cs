using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Validators
{
    internal interface IEntityValidator<T> where T : class
    {
        bool ValidateEntityForCreate(T item);
        bool ValidateEntityForUpdate(T item);
        bool ValidateEntityForDelete(int id);
    }
}
