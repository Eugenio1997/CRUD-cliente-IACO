using CRUD_cliente_IACO.Formularios.Cliente.Cadastrar;
using CRUD_cliente_IACO.Formularios.Cliente.Listar;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using System;
using System.Windows.Forms;

namespace CRUD_cliente_IACO.Formularios
{
    public partial class MenuPrincipalForm : Form
    {
        
        public CadastroClienteForm _cadastroForm;
        public ListaClienteForm _listaForm;

        public MenuPrincipalForm(
            CadastroClienteForm cadastroForm,
            ListaClienteForm listaForm
            )
        {
            InitializeComponent();
            _cadastroForm = cadastroForm;
            _listaForm = listaForm;
        }

        public void MenuPrincipalForm_Load(object sender, EventArgs e)
        {

        }

        public void AdicionarCliente_Click(object sender, EventArgs e)
        {
            _cadastroForm.ShowDialog();
        }

        public void VisualizarClientesCadastrados_Click(object sender, EventArgs e)
        {
            _listaForm.showClientsOnDatagrid();
            _listaForm.ShowDialog();
        }
    }
}
