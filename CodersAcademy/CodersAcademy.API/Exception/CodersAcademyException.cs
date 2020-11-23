using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CodersAcademy.API.Exception
{
    [Serializable]
    public class CodersAcademyException : System.Exception
    {
        public CodersAcademyException(string message) : base(message)
        {

        }

        protected CodersAcademyException(SerializationInfo info, StreamingContext streamingContext ): base(info, streamingContext)
        {

        }

    }
}
