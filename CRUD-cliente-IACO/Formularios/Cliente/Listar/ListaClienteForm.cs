
using CRUD_cliente_IACO.Formularios.Interfaces;
using CRUD_cliente_IACO.Modelos.Views;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using CRUD_cliente_IACO.CustomEventArgs;
using System.Drawing;

namespace CRUD_cliente_IACO.Formularios.Cliente.Listar
{
    public partial class ListaClienteForm : Form, IListagemClienteForm
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ICadastroClienteForm _cadastroClienteForm;

        private Modelos.Cliente _cliente;

        public ListaClienteForm(
            IClienteRepository clienteRepository,
            ICadastroClienteForm cadastroClienteForm)
        {
            if(clienteRepository == null)
                throw new ArgumentNullException(nameof(clienteRepository));
            
            if (cadastroClienteForm == null)
                throw new ArgumentNullException(nameof(cadastroClienteForm));

            InitializeComponent();
            this.Resize += ListaClienteForm_Resize;
            _clienteRepository = clienteRepository;
            _cadastroClienteForm = cadastroClienteForm;

            _cadastroClienteForm.OnClienteEnviado += CadastroClienteForm_OnClienteRecebido;


        }

        public void CadastroClienteForm_OnClienteRecebido(object sender, ClienteEventArgs e)
        {
            _cliente = e.Cliente;

            Console.WriteLine(_cliente);

            _clienteRepository.InserirCliente(_cliente);

            // Isso aqui já chama o método que mostra a tela + carrega os dados
            showClientsOnDatagrid();
        }

        public void showClientsOnDatagrid()
        {
            try
            {
                dataGridView1.AutoGenerateColumns = true;

                List<Modelos.Cliente> listaClientes = _clienteRepository.ConsultarClientes();
                if (listaClientes != null && listaClientes.Count > 0)
                {

                    dataGridView1.DataSource = listaClientes; // <- primeiro define o conteúdo

                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.BringToFront();

                    dataGridView1.Size = new Size(800, 200); // altura menor
                    dataGridView1.Dock = DockStyle.None;
                    dataGridView1.ScrollBars = ScrollBars.Both;
                   

                    dataGridView1.Location = new Point(0, 0);
                    dataGridView1.Show();
                    dataGridView1.BringToFront();
                }
                else
                {
                    MessageBox.Show("Nenhum dado encontrado.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ListaClienteForm_Resize(object sender, EventArgs e)
        {
            // Calcula a posição central
            int x = (this.ClientSize.Width - dataGridView1.Width) / 2;
            int y = (this.ClientSize.Height - dataGridView1.Height) / 2;

            dataGridView1.Location = new Point(x, y);
        }
    }
}
