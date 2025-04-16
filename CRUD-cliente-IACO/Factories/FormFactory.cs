using CRUD_cliente_IACO.Formularios.Cliente.Cadastrar;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO.Factories
{
    public static class FormFactory
    {
        private static CadastroClienteForm _cadastroClienteForm;
        private static CadastroEnderecoClienteForm _cadastroEnderecoClienteForm;

        public static CadastroClienteForm GetCadastroClienteForm(IClienteRepository clienteRepository)
        {
            if (_cadastroClienteForm == null || _cadastroClienteForm.IsDisposed)
            {
                _cadastroClienteForm = new CadastroClienteForm(clienteRepository);
            }
            return _cadastroClienteForm;
        }

        public static CadastroEnderecoClienteForm GetCadastroEnderecoClienteForm(
            IClienteRepository clienteRepository,
            ICadastroClienteForm cadastroClienteForm,
            ICEPService cepService,
            IEstadoService estadoService)
        {
            if (_cadastroEnderecoClienteForm == null || _cadastroEnderecoClienteForm.IsDisposed)
            {
                _cadastroEnderecoClienteForm = new CadastroEnderecoClienteForm(clienteRepository, cadastroClienteForm, cepService, estadoService);
            }
            return _cadastroEnderecoClienteForm;
        }
    }
}
