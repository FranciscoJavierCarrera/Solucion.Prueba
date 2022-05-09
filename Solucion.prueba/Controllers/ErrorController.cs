using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solucion.prueba.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.prueba.Controllers
{
    [Route("errors")]

    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new CodeErrorResponse(code));
        }
    }
}
