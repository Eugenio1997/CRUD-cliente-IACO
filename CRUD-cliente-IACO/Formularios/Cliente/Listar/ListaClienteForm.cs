
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
using CRUD_cliente_IACO.Modelos.DTOs;
using CRUD_cliente_IACO.Util;

namespace CRUD_cliente_IACO.Formularios.Cliente.Listar
{
    public partial class ListaClienteForm : Form, IListagemClienteForm
    {
        private readonly IClienteRepository _clienteRepository;
        bool generoSelecionado = false;
        int generoIdSelecionado;
        int idadeMinima = 18;

        //pagination
        private const int registrosPorPagina = 5;
        private int totalPaginas = 0;
        private string tabela = "CLIENTES";

        DateTime dataNascimentoFiltroBackup;
        DateTime dataAtual = DateTime.Now;
        string generoFiltroPlaceholder = "Selecione o gênero";
        List<Modelos.Cliente> listaClientesFiltrados;
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
        }

        private void ListaClienteForm_Load(object sender, EventArgs e)
        {
            paginaAtualIndice = 1;
            PreencherComboBoxGeneros();
        }

        public void PreencherComboBoxGeneros()
        {
            if (generoSelecionado == false) //se o genero nao tiver sido selecionado
            {          
                GeneroFiltro.Items.Add(generoFiltroPlaceholder);
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

                if (listaClientes != null && listaClientes.Count > 0)

                listaClientesPaginado = _clienteRepository.ConsultarClientes(paginaAtualIndice, registrosPorPagina, Enum.GetName(typeof(OrdenarPorEnum), OrdenarPorEnum.PRIMEIRO_NOME), tabela);

                if (listaClientesPaginado.Registros != null && listaClientesPaginado.Registros.Count > 0)
                {



                    lblTotalPaginas.Text = listaClientesPaginado.TotalPaginas.ToString();

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
                    listaClientesPaginado = _clienteRepository.ConsultarClientes(paginaAtualIndice, registrosPorPagina, Enum.GetName(typeof(OrdenarPorEnum), OrdenarPorEnum.PRIMEIRO_NOME), tabela);


                    dataGridViewClientes.DataSource = listaClientesPaginado.Registros;


                    lblTotalRegistroValor.Text = listaClientesPaginado.TotalRegistros.ToString();
                    lblTotalPaginas.Text = listaClientesPaginado.TotalPaginas.ToString();
                    

                }
                else if (nomeColuna == "Excluir")
                {
                    var confirmar = MessageBox.Show("Tem certeza que deseja excluir?", "Excluir cliente", MessageBoxButtons.YesNo);
                    if (confirmar == DialogResult.Yes)
                    {
                        _clienteRepository.ExcluirCliente(clienteSelecionado.IdCliente);



                    }
                }
            }

        }

        private void Btn_BuscarClientes_Click(object sender, EventArgs e)
        {
            var AnoNascimentoMinimo = dataAtual.Year - idadeMinima;

            var GeneroSelecionadoNome = GeneroFiltro.SelectedItem.ToString();

            Console.WriteLine($"{DataNascimentoFiltro} ");

            //So atualizo o campo genero se o usuario selecionar um opcao valida: Homem, Mulher ou Outros
            if (GeneroSelecionadoNome != generoFiltroPlaceholder)
            {
                var generoEnum = (GenerosEnum)Enum.Parse(typeof(GenerosEnum), GeneroSelecionadoNome);
                generoIdSelecionado = (int)generoEnum;
            }
            
            //Recuperando os campos
            string primeiroNome = PrimeiroNomeFiltro.Text.Trim().ToLower();
            string sobrenome = SobrenomeFiltro.Text.Trim().ToLower();
            var DataNascimento = DataNascimentoFiltro.Value.Date;

            //Se todos os campos estiverem em branco (no caso de DateTime é a data atual e genero é o placeholder)
            if (string.IsNullOrEmpty(primeiroNome) &&
               string.IsNullOrEmpty(sobrenome) &&
               GeneroSelecionadoNome == generoFiltroPlaceholder &&
               DataNascimento.Date == dataAtual.Date
               )
            {
                return;
            }

            //verifica se a data de nascimento é de um cliente de >= 18 anos
           

            if (
                (!string.IsNullOrEmpty(primeiroNome) && DataNascimento.Date == dataAtual.Date) ||
                (!string.IsNullOrEmpty(sobrenome) && DataNascimento.Date == dataAtual.Date) ||
                (GeneroSelecionadoNome != generoFiltroPlaceholder && DataNascimento.Date == dataAtual.Date))
            {
                //DataNascimentoFiltro.Value = DateTime.MinValue;
                dataNascimentoFiltroBackup = DataNascimentoFiltro.Value.Date;
                DataNascimentoFiltro.Value = new DateTime(1900, 1, 1); // or any valid default


            }
            else if (DataNascimentoFiltro.Value.Year > AnoNascimentoMinimo)
            {
                //2009 - (selectioned by user)  |  2025 -  18 = 2007 (ano minimo atualmente)
                MessageBox.Show("Não é possível selecionar esta data.\n\nO cliente precisa ser maior de idade.", "Data inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DataNascimentoFiltro.Value = dataAtual.Date;
                DataNascimentoFiltro.Focus();
                return;
            }

       

            ClienteFiltro filtro = new ClienteFiltro {

                PrimeiroNome = primeiroNome,
                Sobrenome = sobrenome,
                GeneroId = Convert.ToString(generoIdSelecionado) == "0" ? "" : Convert.ToString(generoIdSelecionado),
                DataNascimento = DataNascimentoFiltro.Value.Date

            } ;


            listaClientesFiltrados = _clienteRepository.BuscarClientesPorFiltro(filtro);
            dataGridViewClientes.DataSource = listaClientesFiltrados;
            DataNascimentoFiltro.Value = filtro.DataNascimento;

            dataGridViewClientes.Refresh();


            if (listaClientesFiltrados == null || !listaClientesFiltrados.Any())
            {
                MessageBox.Show(
                   "Não encontramos resultados para sua busca. Verifique os dados informados e tente novamente.",
                   "Busca sem resultados",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information
               );
            }


            DataNascimentoFiltro.Value = dataNascimentoFiltroBackup.Date;

        }

        private void Btn_LimparFiltros_Click(object sender, EventArgs e)
        {
            PrimeiroNomeFiltro.Clear();
            SobrenomeFiltro.Clear();
            DataNascimentoFiltro.Value = dataAtual;

            //limpando o filtro de genero
            if (GeneroFiltro.SelectedItem.ToString() != generoFiltroPlaceholder)
            {
                GeneroFiltro.Items.Clear();

                GeneroFiltro.Items.Add(generoFiltroPlaceholder);
                GeneroFiltro.Items.AddRange(Enum.GetNames(typeof(GenerosEnum)));
                GeneroFiltro.SelectedIndex = 0;
            }

            // Atualiza a lista após edição
            listaClientesPaginado = _clienteRepository.ConsultarClientes(paginaAtualIndice, registrosPorPagina, Enum.GetName(typeof(OrdenarPorEnum), OrdenarPorEnum.PRIMEIRO_NOME), tabela);

            dataGridViewClientes.DataSource = listaClientesPaginado.Registros;


            lblTotalRegistroValor.Text = listaClientesPaginado.TotalRegistros.ToString();
            lblTotalPaginas.Text = listaClientesPaginado.TotalPaginas.ToString();

            dataGridViewClientes.Refresh();
           
        }

        private void btnProxima_Click(object sender, EventArgs e)
        {
           //f()
        }
    }
}
