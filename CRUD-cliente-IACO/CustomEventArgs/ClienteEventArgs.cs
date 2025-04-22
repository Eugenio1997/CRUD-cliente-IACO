using CRUD_cliente_IACO.Modelos;
using CRUD_cliente_IACO.Modelos.DTOs;
using System;

namespace CRUD_cliente_IACO.CustomEventArgs
{
    public class ClienteEventArgs: EventArgs
    {
        public Cliente Cliente { get; private set; }

        public ClienteEventArgs(Modelos.Cliente cliente)
        {
            Cliente = cliente;
        }
    }
}
