using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Solucion.prueba.Dtos;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Web_Portal.Business;

namespace Web_Portal.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente


        public async Task<ActionResult> Index()
        {
           

            return View(await BRCliente.GetAll());
        }        
        
        public async Task<ActionResult> Crud(int id=0)
        {
            return View(await BRCliente.Get(id));
        }
        [HttpPost]
        public async Task<ActionResult> Crud(ClienteEditDto cte)
        {
            await BRCliente.Post(cte);
            return RedirectToAction("Crud", "Cliente", new { id = cte.Id });
        }


    }
}