using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.prueba.Errors
{
    public class CodeErrorException: CodeErrorResponse
    {
        public string Details { get; set; }
        public CodeErrorException(int statusCode, string message= null, string details = null): base(statusCode,message)
        {
            Details = details;
        }
    }
}
