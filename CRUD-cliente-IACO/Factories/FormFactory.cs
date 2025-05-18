using CRUD_cliente_IACO.Formularios;
using CRUD_cliente_IACO.Formularios.Cliente.Cadastrar;
using CRUD_cliente_IACO.Formularios.Cliente.Editar;
using CRUD_cliente_IACO.Formularios.Cliente.Listar;
using CRUD_cliente_IACO.Formularios.Interfaces;
using CRUD_cliente_IACO.Repositorios.Interfaces;


namespace CRUD_cliente_IACO.Factories
{
    public static class FormFactory
    {
        private static CadastroClienteForm _cadastroClienteForm;
        private static ListaClienteForm _listaClienteForm;
        private static MenuPrincipal _menuPrincipalForm;
        private static EditarClienteForm _editarClienteForm;


        public static CadastroClienteForm GetCadastrarClienteForm(IClienteRepository clienteRepository, ListaClienteForm listaClienteForm)
        {
            if (_cadastroClienteForm == null || _cadastroClienteForm.IsDisposed)
            {
                _cadastroClienteForm = new CadastroClienteForm(clienteRepository, listaClienteForm);
            }
            return _cadastroClienteForm;
        }

        public static MenuPrincipal GetMenuPrincipalForm(CadastroClienteForm cadastroForm, ListaClienteForm listaForm, IClienteRepository clienteRepository = null)
        {
           
            _cadastroClienteForm = GetCadastrarClienteForm(clienteRepository, _listaClienteForm);
            _listaClienteForm = GetListagemClienteForm(clienteRepository);

            return _menuPrincipalForm = new MenuPrincipal(_cadastroClienteForm, _listaClienteForm);
        }

        public static EditarClienteForm GetEditarClienteForm(ListaClienteForm listaClienteForm, IClienteRepository clienteRepository)
        {
            _listaClienteForm = GetListagemClienteForm(clienteRepository);
            _editarClienteForm = new EditarClienteForm(null, listaClienteForm, clienteRepository);
            return _editarClienteForm;
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
        public static ListaClienteForm GetListagemClienteForm(IClienteRepository clienteRepository)
        {
            if (_listaClienteForm == null || _listaClienteForm.IsDisposed)
            {
                _listaClienteForm = new ListaClienteForm(clienteRepository);
            }
            return _listaClienteForm;
        }
    }
}
