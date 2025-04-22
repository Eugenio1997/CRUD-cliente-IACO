using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO.Modelos.Views
{
    class ClienteView
    {
        public int IdCliente { get; set; }
        public int IdEndereco { get; set; }

        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }

        public string CEP { get; set; }
        public string Rua { get; set; }
        public string NumeroResidencia { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

    }
}
