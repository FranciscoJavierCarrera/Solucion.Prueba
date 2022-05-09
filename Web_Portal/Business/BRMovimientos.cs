using Newtonsoft.Json;
using Solucion.prueba.Dtos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Web_Portal.Business
{
    public class BRMovimientos
    {
        public static async Task<List<MovimientoDto>> GetAll()
        {
            string rutaapi = ConfigurationManager.AppSettings["Apiuri"].ToString();
            var httplClient = new HttpClient();
            var json = await httplClient.GetStringAsync(rutaapi + "api/Movimiwnto");
            List<MovimientoDto> movs = JsonConvert.DeserializeObject<List<MovimientoDto>>(json);
            return movs;
        }

        public static async Task<List<TipoMovimientoDto>> GetTipoMov()
        {
            string rutaapi = ConfigurationManager.AppSettings["Apiuri"].ToString();
            var httplClient = new HttpClient();
            var json = await httplClient.GetStringAsync(rutaapi + "api/TipoMovimiento/" );
            List<TipoMovimientoDto> tmovs = JsonConvert.DeserializeObject<List<TipoMovimientoDto>>(json);
            return tmovs;
        }

        public static async Task<int> Post(MovimientoDto cte)
        {
            var json = JsonConvert.SerializeObject(cte);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            string rutaapi = ConfigurationManager.AppSettings["Apiuri"].ToString();
            var httplClient = new HttpClient();
            HttpResponseMessage response = null;
            if (cte.Id > 0)
            {
                response = await httplClient.PutAsync(rutaapi + "api/Movimiento/" + cte.Id, data);
            }
            else
            {
                response = await httplClient.PostAsync(rutaapi + "api/Movimiento/", data);
            }

            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            return cte.Id;
        }
    }
}