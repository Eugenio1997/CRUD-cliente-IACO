using CRUD_cliente_IACO.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO.Services.Interfaces
{
    public interface ICEPService
    {
        EnderecoDTO ConsultarEnderecoPorCep(string cep);
    }
}
