using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademy.API.Exception
{
    public class CodersAcademyException : System.Exception
    {
        public CodersAcademyException(string message) : base(message)
        {

        }

    }
}
