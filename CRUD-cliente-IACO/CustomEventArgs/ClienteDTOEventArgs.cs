using CRUD_cliente_IACO.Modelos.DTOs;
using System;

namespace CRUD_cliente_IACO.CustomEventArgs
{
    public class ClienteDTOEventArgs: EventArgs
    {
        public ClienteDTO ClienteDTO { get; private set; }

        public ClienteDTOEventArgs(ClienteDTO clienteDTO)
        {
            ClienteDTO = clienteDTO;
        }
    }
}
