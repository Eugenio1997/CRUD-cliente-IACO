using CRUD_cliente_IACO.Modelos;
using CRUD_cliente_IACO.Services.Interfaces;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System;
using Newtonsoft.Json.Linq;

namespace CRUD_cliente_IACO.Services
{
    public class CEPService : ICEPService
    {
        
        public EnderecoDTO ConsultarEnderecoPorCep(string cep)
        {

           
            string url = $"https://brasilapi.com.br/api/cep/v1/{cep}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string json = reader.ReadToEnd();
                JObject obj = JObject.Parse(json);
                string estado = (string)obj["state"];
                string cidade = (string)obj["city"];
                string bairro = (string)obj["neighborhood"];
                string rua = (string)obj["street"];

                EnderecoDTO endereco = new EnderecoDTO
                {
                    Rua = rua,
                    Bairro = bairro,
                    Cidade = cidade,
                    Estado = estado
                };

                return endereco;
            }
          

        }
    }
}
