using CRUD_cliente_IACO.Modelos.DTOs;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CRUD_cliente_IACO.Services
{
    public class CidadeService : ICidadeService
    {
        public List<CidadeDTO> ObterCidadesPorEstado(string siglaEstado)
        {

            string url = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{siglaEstado}/municipios";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string json = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<List<CidadeDTO>>(json);

            }
        }
    }
}
