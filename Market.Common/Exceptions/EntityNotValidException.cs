using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Common.Exceptions
{
    public class EntityNotValidException : Exception
    {
        public EntityNotValidException(string source) : base(source)
        {

        }
        public EntityNotValidException(Exception ex) : base(ex.InnerException == null ? ex.Message : ex.InnerException.Message)
        {

        }
    }
}
