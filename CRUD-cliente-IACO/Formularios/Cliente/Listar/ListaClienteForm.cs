
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
using CRUD_cliente_IACO.Extensions;
using CRUD_cliente_IACO.Filtros.Cliente;

namespace CRUD_cliente_IACO.Formularios.Cliente.Listar
{
    public partial class ListaClienteForm : Form, IListagemClienteForm
    {
        private readonly IClienteRepository _clienteRepository;
        bool generoSelecionado = false;
        int IdadeMinima = 18;
        List<Modelos.Cliente> listaClientes;
        public ListaClienteForm(
            IClienteRepository clienteRepository)
        {
            if(clienteRepository == null)
                throw new ArgumentNullException(nameof(clienteRepository));
            
          
            InitializeComponent();
            _clienteRepository = clienteRepository;

            Load += ListaClienteForm_Load;
            BtnBuscarClientes.Click += Btn_BuscarClientes_Click;
            BtnLimparFiltros.Click += Btn_LimparFiltros_Click;
            DataNascimentoFiltro.ValueChanged += DataNascimentoFiltro_ValueChanged;
        }

        private void ListaClienteForm_Load(object sender, EventArgs e)
        {
            PreencherComboBoxGeneros();
            //GeneroFiltro.SelectedIndexChanged += GeneroFiltro_SelectedIndexChanged;
        }

        public void PreencherComboBoxGeneros()
        {
            if (generoSelecionado == false) //se o genero nao tiver sido selecionado
            {          
                GeneroFiltro.Items.Add("Selecione o gênero");
                GeneroFiltro.Items.AddRange(Enum.GetNames(typeof(GenerosEnum)));
                GeneroFiltro.SelectedIndex = 0;
            }

            generoSelecionado = true;

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

        /*
        private void primeiroNomeFiltro_TextChanged(object sender, EventArgs e)
        {

            string textoBusca = primeiroNomeFiltro.Text.ToLower();
            listaClientes = _clienteRepository.BuscarClientesPorNome(textoBusca);

            dataGridViewClientes.DataSource = listaClientes;
            dataGridViewClientes.Refresh();
        }
        */

        /*
        private void GeneroFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

            ValidadorDeCliente.ValidarGenero_SelectedIndexChanged(GeneroFiltro);


           
            if (GeneroFiltro.SelectedItem.ToString() == "Selecione o gênero") return;
            GenerosEnum generoEnum = (GenerosEnum)Enum.Parse(typeof(GenerosEnum), GeneroFiltro.SelectedItem.ToString());
            int valorSelecionado = (int)generoEnum;
            var listaClientes = _clienteRepository.BuscarClientesPorGenero(valorSelecionado.ToString());
            dataGridViewClientes.DataSource = listaClientes;
           
            
        }
        */

        private void Btn_BuscarClientes_Click(object sender, EventArgs e)
        {
            //ValidadorDeCliente.ValidarGenero_SelectedIndexChanged(GeneroFiltro);


            //Recuperando o Genero
            //GenerosEnum generoEnum = (GenerosEnum)Enum.Parse(typeof(GenerosEnum), GeneroFiltro.SelectedItem.ToString());
            //int generoIdSelecionado = (int)generoEnum;



            //MessageBox.Show("generoIdSelecionado: " + generoIdSelecionado + " generoEnum: " + generoEnum);
            //Recuperando o Primeiro Nome
            string primeiroNome = PrimeiroNomeFiltro.Text.Trim().ToLower();

            var DataNascimento = DataNascimentoFiltro.Value.Date;

            //Recuperando o Sobrenome
            string sobrenome = SobrenomeFiltro.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(primeiroNome) &&
                string.IsNullOrEmpty(sobrenome) &&
                //string.IsNullOrEmpty(generoIdSelecionado.ToString()) &&
                string.IsNullOrEmpty(DataNascimentoFiltro.Value.Date.ToString())
                )
            {
                return;
            }
            
           

            ClienteFiltro filtro = new ClienteFiltro {

                PrimeiroNome = primeiroNome,
                Sobrenome = sobrenome,
                //GeneroId = Convert.ToString(generoIdSelecionado),
                DataNascimento = DataNascimentoFiltro.Value.Date

            } ;

            listaClientes = _clienteRepository.BuscarClientesPorFiltro(filtro);
            dataGridViewClientes.DataSource = listaClientes;
            dataGridViewClientes.Refresh();
        }

        private void Btn_LimparFiltros_Click(object sender, EventArgs e)
        {
            PrimeiroNomeFiltro.Clear();
            SobrenomeFiltro.Clear();
            DataNascimentoFiltro.Value = DateTime.Now;

            //limpando o filtro de genero
            if (GeneroFiltro.SelectedItem.ToString() != "Selecione o gênero")
            {
                GeneroFiltro.Items.Clear();

                GeneroFiltro.Items.Add("Selecione o gênero");
                GeneroFiltro.Items.AddRange(Enum.GetNames(typeof(GenerosEnum)));
                GeneroFiltro.SelectedIndex = 0;
            }

            if (dataGridViewClientes.Rows.Count == 0)
            {
                listaClientes = _clienteRepository.ConsultarClientes();
                dataGridViewClientes.DataSource = listaClientes;
                dataGridViewClientes.Refresh();
            }
        }

        private void GeneroFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidadorDeCliente.ValidarGenero_SelectedIndexChanged(GeneroFiltro);
            if (GeneroFiltro.SelectedItem.ToString() == "Selecione o gênero") return;
        }

        private void DataNascimentoFiltro_ValueChanged(object sender, EventArgs e)
        {
            if (DataNascimentoFiltro.Value.Year < DateTime.Now.Year - IdadeMinima)
            {
                //2009 - (selectioned by user)  |  2025 -  18 = 2007 (ano minimo atualmente)
                MessageBox.Show("Data não permitida porque não há clientes menores de idade !", "Data inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DataNascimentoFiltro.Value = new DateTime().AddYears(-IdadeMinima);
            }
        }
    }
}
