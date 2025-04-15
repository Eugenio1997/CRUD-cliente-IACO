using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO.Modelos
{
    public class EnderecoDTO
    {
        public string Rua {get;set;}
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

    }
    /*
    "cep":"57046341",
	"state":"AL",
	"city":"Maceió",
	"neighborhood":"Serraria",
	"street":"Rua Adolfo Gustavo",
	"service":"open-cep"
    */
}
