using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validators
{
    public class ValidationException : Exception
    {
        public ValidationException(string field, string message) : base(message)
        {
            this.Field = field;
            this.FieldMessage = message;
        }

        public string Field { get; set; }
        public string FieldMessage { get; set; }
    }
}
