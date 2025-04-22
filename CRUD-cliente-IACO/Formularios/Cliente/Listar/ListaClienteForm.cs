
using CRUD_cliente_IACO.Formularios.Interfaces;
using CRUD_cliente_IACO.Modelos.Views;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using CRUD_cliente_IACO.CustomEventArgs;
using System.Drawing;
using CRUD_cliente_IACO.Formularios.Cliente.Editar;

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
            //this.Resize += ListaClienteForm_Resize;
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
                dataGridViewClientes.AutoGenerateColumns = true;

                List<Modelos.Cliente> listaClientes = _clienteRepository.ConsultarClientes();
                if (listaClientes != null && listaClientes.Count > 0)
                {

                    dataGridViewClientes.DataSource = listaClientes; // <- primeiro define o conteúdo

                   
                    // Adiciona colunas de botão, se ainda não foram adicionadas
                    if (!dataGridViewClientes.Columns.Contains("Editar"))
                    {
                        DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                        btnEditar.Name = "Editar";
                        btnEditar.Text = "Editar";
                        btnEditar.UseColumnTextForButtonValue = true;
                        dataGridViewClientes.Columns.Add(btnEditar);
                    }

                    if (!dataGridViewClientes.Columns.Contains("Excluir"))
                    {
                        DataGridViewButtonColumn btnExcluir = new DataGridViewButtonColumn();
                        btnExcluir.Name = "Excluir";
                        btnExcluir.Text = "Excluir";
                        btnExcluir.UseColumnTextForButtonValue = true;
                        dataGridViewClientes.Columns.Add(btnExcluir);
                    }

 
                    dataGridViewClientes.ScrollBars = ScrollBars.Both;
                    this.Show();
                    this.BringToFront();

                 
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

        /*
        private void ListaClienteForm_Resize(object sender, EventArgs e)
        {
            // Calcula a posição central
            int x = (this.ClientSize.Width - dataGridViewClientes.Width) / 2;
            int y = (this.ClientSize.Height - dataGridViewClientes.Height) / 2;

            dataGridViewClientes.Location = new Point(x, y);
        }
        */

        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex < 0)
                return;

            if (e.RowIndex >= 0)
            {
                string nomeColuna = dataGridViewClientes.Columns[e.ColumnIndex].Name;
                Modelos.Cliente clienteSelecionado = (Modelos.Cliente)dataGridViewClientes.Rows[e.RowIndex].DataBoundItem;

                if (nomeColuna == "Editar")
                {
                    // Abrir formulário de edição passando o cliente
                    EditarClienteForm editarForm = new EditarClienteForm(clienteSelecionado);
                    editarForm.ShowDialog();

                    // Atualiza a lista após edição
                    dataGridViewClientes.DataSource = _clienteRepository.ConsultarClientes();

                }
                else if (nomeColuna == "Excluir")
                {
                    var confirmar = MessageBox.Show("Tem certeza que deseja excluir?", "Confirmar", MessageBoxButtons.YesNo);
                    if (confirmar == DialogResult.Yes)
                    {
                        _clienteRepository.ExcluirCliente(clienteSelecionado.IdCliente);
                        dataGridViewClientes.DataSource = _clienteRepository.ConsultarClientes();
                    }
                }
            }

        }
    }
}
