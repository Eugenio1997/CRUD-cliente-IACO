using CRUD_cliente_IACO.Modelos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO.Services.Interfaces
{
    public interface IEstadoService
    {
        List<EstadoDTO> ObterEstados();
    }
}
