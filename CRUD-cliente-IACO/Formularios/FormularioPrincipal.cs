using System;
using System.Windows.Forms;
using CRUD_cliente_IACO.Formularios.Cliente.Cadastrar;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.Modelos.DTOs;
using CRUD_cliente_IACO.Repositorios;

namespace CRUD_cliente_IACO.Formularios
{
    public partial class FormularioPrincipal : Form
    {
        private readonly IClienteRepository _clienteRepository;
        private CadastroClienteForm _cadastroClienteForm;
        private CadastroEnderecoClienteForm _cadastroEnderecoForm;
        private ClienteDTO _clienteDTO;

        public FormularioPrincipal()
        {
            InitializeComponent();
            _clienteRepository = new ClienteRepository();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;
            AbrirFormularioCadastroCliente();
        }

        private void AbrirFormularioCadastroCliente()
        {
            _clienteDTO = new ClienteDTO();
            _cadastroClienteForm = new CadastroClienteForm(_clienteRepository, _clienteDTO);
            _cadastroClienteForm.ProximoClick += CadastroClienteForm_ProximoClick;
            AbrirFormulario(_cadastroClienteForm);
        }

        private void CadastroClienteForm_ProximoClick(object sender, EventArgs e)
        {
            _cadastroEnderecoForm = new CadastroEnderecoClienteForm(_clienteRepository, _clienteDTO);
            _cadastroEnderecoForm.VoltarClick += CadastroEnderecoForm_VoltarClick;
            _cadastroEnderecoForm.SalvoComSucesso += CadastroEnderecoForm_SalvoComSucesso;
            AbrirFormulario(_cadastroEnderecoForm);
        }

        private void CadastroEnderecoForm_VoltarClick(object sender, EventArgs e)
        {
            _cadastroEnderecoForm.Close();
            _cadastroClienteForm.Show();
        }

        private void CadastroEnderecoForm_SalvoComSucesso(object sender, EventArgs e)
        {
            _cadastroEnderecoForm.Close();
            AbrirFormularioCadastroCliente();
        }

        private void AbrirFormulario(Form formulario)
        {
            foreach (Form formAberto in this.MdiChildren)
            {
                formAberto.Close();
            }

            formulario.MdiParent = this;
            formulario.WindowState = FormWindowState.Maximized;
            formulario.Show();
        }
    }
} 