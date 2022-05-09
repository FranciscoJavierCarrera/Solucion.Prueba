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
    public class BRCliente
    {

        public static async Task<List<ClienteDto>> GetAll()
        {
            string rutaapi = ConfigurationManager.AppSettings["Apiuri"].ToString();
            var httplClient = new HttpClient();
            var json = await httplClient.GetStringAsync(rutaapi+"api/Cliente");
            List<ClienteDto> clientes = JsonConvert.DeserializeObject<List<ClienteDto>>(json);
            return clientes;
        }

        public static async Task<ClienteEditDto> Get(int id)
        {
            string rutaapi = ConfigurationManager.AppSettings["Apiuri"].ToString();
            var httplClient = new HttpClient();
            var json = await httplClient.GetStringAsync(rutaapi+"api/Cliente/" + id.ToString());
            ClienteEditDto cliente = JsonConvert.DeserializeObject<ClienteEditDto>(json);
            return cliente;
        }

        public static async Task<int> Post(ClienteEditDto cte)
        {
            var json = JsonConvert.SerializeObject(cte);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            string rutaapi = ConfigurationManager.AppSettings["Apiuri"].ToString();
            var httplClient = new HttpClient();
            HttpResponseMessage response = null;
            if (cte.Id > 0)
            {
                response =await httplClient.PutAsync(rutaapi+"api/Cliente/" + cte.Id, data);
            }
            else
            {
                response = await httplClient.PostAsync(rutaapi+"api/Cliente/", data);
            }

            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            return cte.Id;
        }
    }
}