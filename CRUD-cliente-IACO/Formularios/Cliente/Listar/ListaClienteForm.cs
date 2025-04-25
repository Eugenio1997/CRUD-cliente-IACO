
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
using CRUD_cliente_IACO.Formularios.Cliente.Cadastrar;
using CRUD_cliente_IACO.Enums;
using CRUD_cliente_IACO.Validacoes;

namespace CRUD_cliente_IACO.Formularios.Cliente.Listar
{
    public partial class ListaClienteForm : Form, IListagemClienteForm
    {
        private readonly IClienteRepository _clienteRepository;

        public ListaClienteForm(
            IClienteRepository clienteRepository)
        {
            if(clienteRepository == null)
                throw new ArgumentNullException(nameof(clienteRepository));
            
          
            InitializeComponent();
            _clienteRepository = clienteRepository;

            Load += ListaClienteForm_Load;
        }

        private void ListaClienteForm_Load(object sender, EventArgs e)
        {
            PreencherComboBoxGeneros();
            GeneroFiltro.SelectedIndexChanged += GeneroFiltro_SelectedIndexChanged;
        }

        public void PreencherComboBoxGeneros()
        {
            var generos = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(-1, "Selecione o gênero"),
                new KeyValuePair<int, string>((int)GenerosEnum.H, GenerosEnum.H.ToString()),
                new KeyValuePair<int, string>((int)GenerosEnum.M, GenerosEnum.M.ToString()),
                new KeyValuePair<int, string>((int)GenerosEnum.O, GenerosEnum.O.ToString())
            };

            GeneroFiltro.DataSource = generos;
            GeneroFiltro.DisplayMember = "Value";
            GeneroFiltro.ValueMember = "Key";
            GeneroFiltro.SelectedIndex = 0;

            /*
            var generos = new List<string>
            {
                "Selecione o gênero",
                GenerosEnum.H.ToString(),
                GenerosEnum.M.ToString(),
                GenerosEnum.O.ToString()
            };
            */

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
                        btnEditar.Name = "Editar"; //Necessario para identificar se a coluna existe ou nao
                        btnEditar.Text = "Editar";
                        btnEditar.UseColumnTextForButtonValue = true;
                        dataGridViewClientes.Columns.Add(btnEditar);
                    }

                    if (!dataGridViewClientes.Columns.Contains("Excluir"))
                    {
                        DataGridViewButtonColumn btnExcluir = new DataGridViewButtonColumn();
                        btnExcluir.Name = "Excluir"; //Necessario para identificar se a coluna existe ou nao
                        btnExcluir.Text = "Excluir";
                        btnExcluir.UseColumnTextForButtonValue = true;
                        dataGridViewClientes.Columns.Add(btnExcluir);
                    }

 
                    dataGridViewClientes.ScrollBars = ScrollBars.Both;
                    //this.Show();
                    this.Visible = false;
                    //this.BringToFront();
                    

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
                    EditarClienteForm editarForm = new EditarClienteForm(clienteSelecionado, null, _clienteRepository);

                    editarForm.ShowDialog();

                    // Atualiza a lista após edição
                    dataGridViewClientes.DataSource = _clienteRepository.ConsultarClientes();

                }
                else if (nomeColuna == "Excluir")
                {
                    var confirmar = MessageBox.Show("Tem certeza que deseja excluir?", "Excluir cliente", MessageBoxButtons.YesNo);
                    if (confirmar == DialogResult.Yes)
                    {
                        _clienteRepository.ExcluirCliente(clienteSelecionado.IdCliente);
                        dataGridViewClientes.DataSource = _clienteRepository.ConsultarClientes();
                    }
                }
            }

        }


        private void primeiroNomeFiltro_TextChanged(object sender, EventArgs e)
        {
            string textoBusca = primeiroNomeFiltro.Text.ToLower();
            var listaClientes = _clienteRepository.BuscarClientesPorNome(textoBusca);

            dataGridViewClientes.DataSource = listaClientes;
            dataGridViewClientes.Refresh();
        }

        private void GeneroFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

            ValidadorDeCliente.ValidarGenero_SelectedIndexChanged(GeneroFiltro);
            var valorSelecionado = (KeyValuePair<int, string>)GeneroFiltro.SelectedItem;

            //string generoSelecionadoNome = (string)GeneroFiltro.SelectedItem;
            //int valorSelecionado = Convert.ToInt32(GeneroFiltro.SelectedValue);

            Console.WriteLine(valorSelecionado.Key);
            if (valorSelecionado.Key >= 0)
            {
                // Exemplo: Exibir no console
                //Console.WriteLine("Gênero selecionado: " + generoSelecionadoNome);

                var listaClientes = _clienteRepository.BuscarClientesPorGenero(Convert.ToString(valorSelecionado));
                dataGridViewClientes.DataSource = listaClientes;
              
            }
           
            
        }


            

      
    }
}
