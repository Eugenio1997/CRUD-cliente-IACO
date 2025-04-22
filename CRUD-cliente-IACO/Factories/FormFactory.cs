using CRUD_cliente_IACO.Formularios.Cliente.Cadastrar;
using CRUD_cliente_IACO.Formularios.Cliente.Listar;
using CRUD_cliente_IACO.Formularios.Interfaces;
using CRUD_cliente_IACO.Repositorios.Interfaces;


namespace CRUD_cliente_IACO.Factories
{
    public static class FormFactory
    {
        private static CadastroClienteForm _cadastroClienteForm;
        private static CadastroEnderecoClienteForm _cadastroEnderecoClienteForm;
        private static ListaClienteForm _listaClienteForm;

        public static CadastroClienteForm GetCadastroClienteForm(IClienteRepository clienteRepository, ListaClienteForm listaClienteForm)
        {
            if (_cadastroClienteForm == null || _cadastroClienteForm.IsDisposed)
            {
                _cadastroClienteForm = new CadastroClienteForm(clienteRepository, listaClienteForm);
            }
            return _cadastroClienteForm;
        }

        /*
        public static CadastroEnderecoClienteForm GetCadastroEnderecoClienteForm(
            IClienteRepository clienteRepository,
            ICadastroClienteForm cadastroClienteForm,
            ICEPService cepService,
            IEstadoService estadoService,
            ICidadeService cidadeService,
            IListagemClienteForm listagemClienteForm)
        {


            if (_cadastroEnderecoClienteForm == null || _cadastroEnderecoClienteForm.IsDisposed)
            {
                _cadastroEnderecoClienteForm = new CadastroEnderecoClienteForm(clienteRepository, cadastroClienteForm, cepService, estadoService, cidadeService, listagemClienteForm);
            }
            return _cadastroEnderecoClienteForm;
        }
        */
        public static ListaClienteForm GetListagemClienteForm(IClienteRepository clienteRepository, ICadastroClienteForm cadastroForm)
        {
            if (_listaClienteForm == null || _listaClienteForm.IsDisposed)
            {
                _listaClienteForm = new ListaClienteForm(clienteRepository, cadastroForm);
            }
            return _listaClienteForm;
        }
    }
}
