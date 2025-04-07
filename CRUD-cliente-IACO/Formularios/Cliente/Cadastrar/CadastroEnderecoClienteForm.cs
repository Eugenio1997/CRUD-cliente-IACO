using System;
using System.Windows.Forms;
using CRUD_cliente_IACO.Repositorios.Interfaces;

namespace CRUD_cliente_IACO.Formularios.Cliente.Cadastrar
{
    public partial class CadastroEnderecoClienteForm : Form
    {
        private readonly IClienteRepository _clienteRepository;
        private static CadastroEnderecoClienteForm _instance;

        public CadastroEnderecoClienteForm(IClienteRepository clienteRepository)
        {
            InitializeComponent();
            if (clienteRepository == null)
                throw new ArgumentNullException(nameof(clienteRepository));

            _clienteRepository = clienteRepository;
        }

        //no parameless
        private CadastroEnderecoClienteForm(){}


        public static CadastroEnderecoClienteForm instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CadastroEnderecoClienteForm();
                }

                return _instance;
            }
        }


        // Exemplo de método usando o repository injetado
        private void SalvarEndereco(Modelos.Cliente cliente)
        {
            try
            {
                _clienteRepository.AtualizarCliente(cliente);
                MessageBox.Show("Cliente salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar Cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
