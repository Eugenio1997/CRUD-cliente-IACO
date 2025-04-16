using CRUD_cliente_IACO.Services.Interfaces;
using System.Collections.Generic;
using CRUD_cliente_IACO.Modelos.DTOs;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace CRUD_cliente_IACO.Services
{
    public class EstadoService : IEstadoService
    {
        public List<EstadoDTO> ObterEstados()
        {

            string url = "https://brasilapi.com.br/api/ibge/uf/v1";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string json = reader.ReadToEnd();

                List<EstadoDTO> estados = JsonConvert.DeserializeObject<List<EstadoDTO>>(json);
                return estados;
            }

        }
    }
}
