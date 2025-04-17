using CRUD_cliente_IACO.Modelos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO.Repositorios.Interfaces
{
    public interface ICidadeService
    {
        List<CidadeDTO> ObterCidadesPorEstado(string siglaEstado);

    }
}
