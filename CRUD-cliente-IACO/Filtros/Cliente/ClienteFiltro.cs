using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO.Filtros.Cliente
{
    public sealed class ClienteFiltro
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string GeneroId { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
