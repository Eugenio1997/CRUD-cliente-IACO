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


            string url = $"https://brasilapi.com.br/api/ibge/municipios/v1/{siglaEstado}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string json = reader.ReadToEnd();

                    return JsonConvert.DeserializeObject<List<CidadeDTO>>(json);

                }
            }
            catch(WebException ex)
            {
                Console.WriteLine("Erro ao obter cidades: " + ex.Message);

                if (ex.Response != null)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        string errorResponse = reader.ReadToEnd();
                        Console.WriteLine("Resposa do servidor: " + errorResponse);
                    }
                }
            }
            return new List<CidadeDTO>();
        }
    }
}
