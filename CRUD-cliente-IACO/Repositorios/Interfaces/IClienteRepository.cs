using System.Collections.Generic;
using CRUD_cliente_IACO.Modelos;

namespace CRUD_cliente_IACO.Repositorios.Interfaces
{
    public interface IClienteRepository
    {
        void InserirCliente(Cliente cliente);
        
        List<Cliente> ConsultarClientes();
        void ExcluirCliente(int id);
        void AtualizarCliente(Cliente cliente);
        List<Cliente> BuscarClientesPorNome(string nome);

        /*
        Cliente ConsultarClientePorId(int id);
        void ExcluirCliente(int id);
        */
    }
} 