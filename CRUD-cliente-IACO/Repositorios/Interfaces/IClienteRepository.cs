using System.Collections.Generic;
using CRUD_cliente_IACO.Modelos;
using CRUD_cliente_IACO.Filtros.Cliente;

namespace CRUD_cliente_IACO.Repositorios.Interfaces
{
    public interface IClienteRepository
    {
        void InserirCliente(Cliente cliente);
        
        List<Cliente> ConsultarClientes();
        void ExcluirCliente(int id);
        void AtualizarCliente(Cliente cliente);
        List<Cliente> BuscarClientesPorFiltro(ClienteFiltro filtro);
        //List<Cliente> BuscarClientesPorNome(string nome);
        List<Cliente> BuscarClientesPorGenero(string generoId);
        Cliente ConsultarClientePorId(int id);
        bool VerificarClienteExistePorCPF(string cpf);
    }
} 