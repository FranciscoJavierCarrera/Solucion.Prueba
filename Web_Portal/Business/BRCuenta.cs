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
    public class BRCuenta
    {
        public static async Task<List<CuentaShowDto>> GetAll()
        {
            string rutaapi = ConfigurationManager.AppSettings["Apiuri"].ToString();
            var httplClient = new HttpClient();
            var json = await httplClient.GetStringAsync(rutaapi + "api/Cuenta");
            List<CuentaShowDto> cuentas = JsonConvert.DeserializeObject<List<CuentaShowDto>>(json);
            return cuentas;
        }

        public static async Task<CuentaDetailDto> Get(int id)
        {
            string rutaapi = ConfigurationManager.AppSettings["Apiuri"].ToString();
            var httplClient = new HttpClient();
            var json = await httplClient.GetStringAsync(rutaapi + "api/Cuenta/" + id.ToString());
            CuentaDetailDto cuenta = JsonConvert.DeserializeObject<CuentaDetailDto>(json);
            return cuenta;
        }

        public static async Task<int> Post(CuentaDetailDto cta)
        {
            var json = JsonConvert.SerializeObject(cta);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            string rutaapi = ConfigurationManager.AppSettings["Apiuri"].ToString();
            var httplClient = new HttpClient();
            HttpResponseMessage response = null;
            if (cta.Id > 0)
            {
                response = await httplClient.PutAsync(rutaapi + "api/Cuenta/" + cta.Id, data);
            }
            else
            {
                response = await httplClient.PostAsync(rutaapi + "api/Cuenta/", data);
            }

            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            return cta.Id;
        }

        public static async Task<List<TipoCuentaDto>> GetTipoCuentasAll()
        {
            string rutaapi = ConfigurationManager.AppSettings["Apiuri"].ToString();
            var httplClient = new HttpClient();
            var json = await httplClient.GetStringAsync(rutaapi + "api/TipoCuentas");
            List<TipoCuentaDto> cuentas = JsonConvert.DeserializeObject<List<TipoCuentaDto>>(json);
            return cuentas;
        }
    }
}