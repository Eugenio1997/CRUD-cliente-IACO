
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
using CRUD_cliente_IACO.Filtros.Cliente;
using CRUD_cliente_IACO.Modelos.DTOs;
using CRUD_cliente_IACO.Util;
using CRUD_cliente_IACO.AtributosCustomizados;

namespace CRUD_cliente_IACO.Formularios.Cliente.Listar
{
    public partial class ListaClienteForm : Form, IListagemClienteForm
    {
        private readonly IClienteRepository _clienteRepository;
        bool generoSelecionado = false;
        int generoIdSelecionado;
        int idadeMinima = 18;
        int indiceMinimo = 2; 

        //pagination
        private const int registrosPorPagina = 10;
        private int paginaAtualIndice = 1;
        private int totalPaginas = 0;
        private int totalRegistros = 0;
        private string tabela = "CLIENTES";

        DateTime dataNascimentoFiltroBackup;
        DateTime dataAtual = DateTime.Now;
        string generoFiltroPlaceholder = "Selecione o gênero";
        List<Modelos.Cliente> listaClientesFiltrados;
        PaginacaoResultado<Modelos.Cliente> listaClientesPaginado;
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
            lblPaginaAtual.Text = paginaAtualIndice.ToString();
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


                listaClientesPaginado = _clienteRepository
                    .ConsultarClientes(
                        paginaAtualIndice, 
                        registrosPorPagina,
                        Enum.GetName(typeof(OrdenarPorEnum), OrdenarPorEnum.PRIMEIRO_NOME),
                        tabela
                   );


                if (listaClientesPaginado.Registros != null && listaClientesPaginado.Registros.Count > 0)
                {

                    dataGridViewClientes.DataSource = listaClientesPaginado.Registros; // <- primeiro define o conteúdo


                    lblTotalRegistroValor.Text = listaClientesPaginado.TotalRegistros.ToString();
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
            finally
            {

                //Sobrescrevendo os nomes de colunas do DataGridView
                AplicarCabecalhosComNomesExibicao<Modelos.Cliente>(dataGridViewClientes);
                dataGridViewClientes.Columns["PrimeiroNome"].Width = 150;
                dataGridViewClientes.Columns["DataNascimento"].Width = 200;

                dataGridViewClientes.Columns["Editar"].HeaderText = " ";
                dataGridViewClientes.Columns["Excluir"].HeaderText = " ";

                dataGridViewClientes.Columns["Excluir"].Width = 50;
                dataGridViewClientes.Columns["Editar"].Width = 50;

                foreach (DataGridViewColumn col in dataGridViewClientes.Columns)
                {
                    
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                dataGridViewClientes.Columns["DataNascimento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dataGridViewClientes.EnableHeadersVisualStyles = false;
                dataGridViewClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
                dataGridViewClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            }

        }

        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex < 0)
                return;

            if (e.ColumnIndex >= 2)
            {
                //Enum.GetName(typeof(OrdenarPorEnum), OrdenarPorEnum.PRIMEIRO_NOME)
                string ordenarPor = dataGridViewClientes.Columns[e.ColumnIndex].Name;
            }

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

                        // Atualiza a lista após edição
                        listaClientesPaginado = _clienteRepository.ConsultarClientes(paginaAtualIndice, registrosPorPagina, Enum.GetName(typeof(OrdenarPorEnum), OrdenarPorEnum.PRIMEIRO_NOME), tabela);

                        dataGridViewClientes.DataSource = listaClientesPaginado.Registros;


                        lblTotalRegistroValor.Text = listaClientesPaginado.TotalRegistros.ToString();
                        lblTotalPaginas.Text = listaClientesPaginado.TotalPaginas.ToString();
                      //lblPaginaAtual.Text = paginaAtualIndice.ToString();


                    }
                }
            }

        }

        private void AplicarCabecalhosComNomesExibicao<T>(DataGridView grid)
        {
            var props = typeof(T).GetProperties();

            foreach (DataGridViewColumn col in grid.Columns)
            {
                var prop = props.FirstOrDefault(p => p.Name == col.DataPropertyName);
                if (prop != null)
                {
                    var attr = Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                    if (attr != null)
                        col.HeaderText = attr.Nome;
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
            paginaAtualIndice = 1;

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
            lblPaginaAtual.Text = paginaAtualIndice.ToString();

            dataGridViewClientes.Refresh();
           
        }

        private void btnProxima_Click(object sender, EventArgs e)
        {
            if (paginaAtualIndice < listaClientesPaginado.TotalPaginas)
            {
                paginaAtualIndice++;
                lblPaginaAtual.Text = paginaAtualIndice.ToString();

                listaClientesPaginado = _clienteRepository.ConsultarClientes(paginaAtualIndice, registrosPorPagina, Enum.GetName(typeof(OrdenarPorEnum), OrdenarPorEnum.PRIMEIRO_NOME), tabela);
                dataGridViewClientes.DataSource = listaClientesPaginado.Registros;

            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (paginaAtualIndice >= indiceMinimo)
            {
                paginaAtualIndice--;
                lblPaginaAtual.Text = paginaAtualIndice.ToString();

                listaClientesPaginado = _clienteRepository.ConsultarClientes(paginaAtualIndice, registrosPorPagina, Enum.GetName(typeof(OrdenarPorEnum), OrdenarPorEnum.PRIMEIRO_NOME), tabela);
                dataGridViewClientes.DataSource = listaClientesPaginado.Registros;
            }
        }

        private void btnPrimeira_Click(object sender, EventArgs e)
        {

            if (paginaAtualIndice == 1) return;

            paginaAtualIndice = 1;
            lblPaginaAtual.Text = paginaAtualIndice.ToString();

            listaClientesPaginado = _clienteRepository.ConsultarClientes(paginaAtualIndice, registrosPorPagina, Enum.GetName(typeof(OrdenarPorEnum), OrdenarPorEnum.PRIMEIRO_NOME), tabela);
            dataGridViewClientes.DataSource = listaClientesPaginado.Registros;
        }

        private void btnUltima_Click(object sender, EventArgs e)
        {

            if (paginaAtualIndice == listaClientesPaginado.TotalPaginas) return;
                
            paginaAtualIndice = listaClientesPaginado.TotalPaginas;
            lblPaginaAtual.Text = paginaAtualIndice.ToString();

            listaClientesPaginado = _clienteRepository.ConsultarClientes(listaClientesPaginado.TotalPaginas, registrosPorPagina, Enum.GetName(typeof(OrdenarPorEnum), OrdenarPorEnum.PRIMEIRO_NOME), tabela);
            dataGridViewClientes.DataSource = listaClientesPaginado.Registros;
        }


    }
}
