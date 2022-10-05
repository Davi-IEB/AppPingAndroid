using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppPingAndroid.Modelo;

namespace AppPingAndroid.Servico
{
    public class ServicoDeDados
    {
        private const string RequestUriCentros = @"C:\ITAESBRA\AppPingAndroid\AppJSon\grupo_centro.json";

        HttpClient centros = new HttpClient();
        public async Task<List<Centros>> GetCentrosAsync()
        {
            var response = await centros.GetStringAsync(RequestUriCentros);
            var cts = JsonConvert.DeserializeObject<List<Centros>>(response);
            return cts;
        }
    }
}
