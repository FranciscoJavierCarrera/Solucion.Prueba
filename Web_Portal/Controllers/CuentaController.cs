using Solucion.prueba.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_Portal.Business;

namespace Web_Portal.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public async Task<ActionResult> Index()
        {
            return View(await BRCuenta.GetAll());
        }

        public async Task<ActionResult> Crud(int id = 0)
        {
            var clientes = await BRCliente.GetAll();
            ViewBag.clientes = new SelectList(clientes.Select(row => new { value = row.Id, text = row.Nombre+" "+row.ApellidoP }), "value", "text");
            var tcuentas = await BRCuenta.GetTipoCuentasAll();
            ViewBag.TipoCuentas = new SelectList(tcuentas.Select(row => new { value = row.Id, text = row.Descripcion }), "value", "text");
            var tmovs = await BRMovimientos.GetTipoMov();
            ViewBag.TipoMovs = tmovs;
            ViewBag.TipoMovimientos = new SelectList(tmovs.Select(row => new { value = row.Id, text = row.Descripcion }), "value", "text");


            return View(await BRCuenta.Get(id));
        }
        [HttpPost]
        public async Task<ActionResult> Crud(CuentaDetailDto cte)
        {
            await BRCuenta.Post(cte);
            return RedirectToAction("Crud", "Cuenta", new { id = cte.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Abonar(MovimientoDto mov)
        {
            await BRMovimientos.Post(mov);
            await BRCuenta.Post(new CuentaDetailDto() { Id=mov.CuentaId});


            return RedirectToAction("Crud", "Cuenta", new { id = mov.CuentaId });
        }
    }
}