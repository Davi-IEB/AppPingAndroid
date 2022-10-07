using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppPingAndroid.Modelo;

namespace AppPingAndroid.Servico
{
    public class ServicoDeDados
    {
        private const string RequestUriCentros = "https://raw.githubusercontent.com/Davi-IEB/AppPingAndroid/master/AppJSon/grupo_centro.json";
        private const string RequestUriMaquinas = "https://raw.githubusercontent.com/Davi-IEB/AppPingAndroid/master/AppJSon/centro_horas.json";
        private const string RequestUriProgramas = "https://raw.githubusercontent.com/Davi-IEB/AppPingAndroid/master/AppJSon/programa_maquina.json";
        readonly HttpClient centros = new HttpClient();
        readonly HttpClient maquinas = new HttpClient();
        readonly HttpClient programas = new HttpClient();
        public async Task<List<Centro>> GetCentrosAsync()
        {
            var response = await centros.GetStringAsync(RequestUriCentros);
            var cts = JsonConvert.DeserializeObject<List<Centro>>(response);
            return cts;
        }
        public async Task<List<Maquina>> GetMaquinasAsync()
        {
            var response2 = await maquinas.GetStringAsync(RequestUriMaquinas);
            var maq = JsonConvert.DeserializeObject<List<Maquina>>(response2);
            return maq;
        }
        public async Task<List<Programa>> GetProgramaAsync()
        {
            var response3 = await programas.GetStringAsync(RequestUriProgramas);
            var prog = JsonConvert.DeserializeObject<List<Programa>>(response3);            
            return prog;
        }
    }
}
