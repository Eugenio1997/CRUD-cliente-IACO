using System.Collections.Generic;
using CRUD_cliente_IACO.Modelos;

namespace CRUD_cliente_IACO.Repositorios.Interfaces
{
    public interface IClienteRepository
    {
        void InserirCliente(Cliente cliente);
        
        List<Cliente> ConsultarClientes();
        /*
        Cliente ConsultarClientePorId(int id);
        void AtualizarCliente(Cliente cliente);
        void ExcluirCliente(int id);
        */
    }
} 