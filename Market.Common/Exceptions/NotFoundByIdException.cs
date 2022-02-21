using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Common.Exceptions
{
    public class NotFoundByIdException : Exception
    {
        public NotFoundByIdException(string source) : base(source)
        {

        }
        public NotFoundByIdException(Exception ex) : base(ex.InnerException == null ? ex.Message : ex.InnerException.Message)
        {

        }
    }
}
