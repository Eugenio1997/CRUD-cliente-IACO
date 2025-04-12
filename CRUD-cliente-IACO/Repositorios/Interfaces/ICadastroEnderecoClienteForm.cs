using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO.Repositorios.Interfaces
{
    public interface ICadastroEnderecoClienteForm
    {
        event EventHandler OnVoltar;

        void SalvarCliente();
    }
}
