using System;
using System.Windows.Forms;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.Modelos.DTOs;
using CRUD_cliente_IACO.Modelos;
using Newtonsoft.Json;
using CRUD_cliente_IACO.CustomEventArgs;
using CRUD_cliente_IACO.Validacoes;
using CRUD_cliente_IACO.Services.Interfaces;
using System.Collections.Generic;

namespace CRUD_cliente_IACO.Formularios.Cliente.Cadastrar
{
    public partial class CadastroEnderecoClienteForm : Form, ICadastroEnderecoClienteForm
    {
        //flags
        private bool campoCEPLimpoAposDadosRecuperados = false;
        private bool dadosRecuperadosPorCepService = false;

        //Repositorios (Camada de acesso ao banco)
        private readonly IClienteRepository _clienteRepository;

        //Formularios
        private readonly ICadastroClienteForm _cadastroClienteForm;

        //Servicos
        private ICEPService _CEPService;
        private IEstadoService _EstadoService;

        //Eventos
        public event EventHandler OnVoltar;

        //DTO's
        private ClienteDTO _clienteDTO;

        //Timer
        private Timer _debounceCepTimer;


        public CadastroEnderecoClienteForm(
            IClienteRepository clienteRepository,
            ICadastroClienteForm cadastroClienteForm,
            ICEPService CEPService,
            IEstadoService EstadoService)
        {
            InitializeComponent();
            if (clienteRepository == null)
                throw new ArgumentNullException(nameof(clienteRepository));
            if (cadastroClienteForm == null)
                throw new ArgumentNullException(nameof(cadastroClienteForm));

            AdicionarEventosNosCampos();
            _clienteRepository = clienteRepository;
            _cadastroClienteForm = cadastroClienteForm;
            _cadastroClienteForm.OnClienteDTOEnviado += CadastroClienteForm_OnClienteDTORecebido;
            _CEPService = CEPService;
            //Eventos VALIDATING de cada campo
            //CamposTodos_Validating();
            
            Estado.SelectedIndexChanged += Estado_SelectedIndexChanged;

            //Eventos KeyPress de cada campo

            CEP.KeyPress += CEP_KeyPress;

            //Eventos TextChanged
            CEP.TextChanged += CEP_TextChanged;

            //Eventos Leave
            CEP.Leave += CEP_Leave;



        }


        private void CadastroEnderecoClienteForm_Load(object sender, EventArgs e)
        {
            _debounceCepTimer = new Timer();
            _debounceCepTimer.Interval = 2000; // 2000 ms de espera após a digitação
            _debounceCepTimer.Tick += DebounceCepTimer_Tick;
        }




        private void DebounceCepTimer_Tick(object sender, EventArgs e)
        {
            _debounceCepTimer.Stop(); // parar o timer após disparar

            string cep = CEP.Text.Trim();

            // Validação simples: se não tiver 8 numeros, retorna 'false' 
            if (!ValidadorDeClienteEndereco.CEP_TextChanged(CEP) || string.IsNullOrEmpty(cep))
            {
                CEP.Focus();
                return;
            }

            // Chama o serviço
            try
            {
                dadosRecuperadosPorCepService = true;

                EnderecoDTO cepDados = _CEPService.ConsultarEnderecoPorCep(cep);
                Rua.Text = cepDados.Rua;
                Bairro.Text = cepDados.Bairro;
                Cidade.Text = cepDados.Cidade;
                Estado.Text = cepDados.Estado;

                Rua.ReadOnly = false;
                Bairro.ReadOnly = false;
                Cidade.Enabled = false;
                Estado.Enabled = false;

                NResidencia.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CEP não encontrado ou inválido", "Erro ao buscar o endereço", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CEP.Focus();
            }

        }




        public void AdicionarEventosNosCampos()
        {
            foreach (Control ctrl in this.Controls)
            {

                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).TextChanged += (sender, e) => VerificarCamposPreenchidos();
                }
                else if (ctrl is MaskedTextBox)
                {
                    ((MaskedTextBox)ctrl).TextChanged += (sender, e) => VerificarCamposPreenchidos();
                }

            }

            Btn_Cadastrar.Enabled = false;
        }

        public void VerificarCamposPreenchidos()
        {
            /// excluindo os caracteres da máscara
            CEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            bool todosPreenchidos = !string.IsNullOrEmpty(CEP.Text.Trim()) &&
                                    !string.IsNullOrEmpty(Estado.Text.Trim()) &&
                                    !string.IsNullOrEmpty(Bairro.Text.Trim()) &&
                                    !string.IsNullOrEmpty(Rua.Text.Trim()) &&
                                    !string.IsNullOrEmpty(Cidade.Text.Trim()) &&
                                    !string.IsNullOrEmpty(NResidencia.Text.Trim());

            Btn_Cadastrar.Enabled = todosPreenchidos;
        }

        public void CadastroClienteForm_OnClienteDTORecebido(object sender, ClienteDTOEventArgs e)
        {            
            _clienteDTO = e.ClienteDTO;
        }

        public void Btn_Cadastrar_Click(object sender, EventArgs e)
        {
            SalvarCliente();
        }

        public void SalvarCliente()
        {
            try
            {
                // Preencher o endereço no ClienteDTO
                _clienteDTO.Endereco = new Endereco
                {
                    CEP = CEP.Text,
                    Rua = Rua.Text,
                    NumeroResidencia = NResidencia.Text,
                    Bairro = Bairro.Text,
                    Cidade = Cidade.Text,
                    Estado = Estado.Text
                };

                // Converter DTO para Cliente e salvar
                var cliente = _clienteDTO.ToCliente();

                // Serializa o objeto para JSON
                string clienteJSON = JsonConvert.SerializeObject(cliente, Formatting.Indented);

                MessageBox.Show(clienteJSON);
                //_clienteRepository.Inserir(cliente);

                MessageBox.Show("Cliente salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar Cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btnVoltar_Click(object sender, EventArgs e)
        {
            OnVoltar?.Invoke(this, EventArgs.Empty);
        }

        
        //EVENTOS KEYPRESS
        public void CEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorDeClienteEndereco.ValidarCEP_KeyPress(CEP, e);

        }

        public void Estado_SelectedIndexChanged(object sender, EventArgs e)
        {

            string estadoSelecionado = Estado.SelectedItem?.ToString();

            Console.WriteLine("Estado selecionado: " + estadoSelecionado);

            ValidadorDeClienteEndereco.ValidarEstado_SelectedIndexChanged(Estado);
        }


        public void CEP_TextChanged(object sender, EventArgs e)
        {
            //caso o maskedTextBox CEP fique vazio, entao os demais campos preenchidos
            //devem ser limpos.
            if (string.IsNullOrEmpty(CEP.Text) &&
                !string.IsNullOrEmpty(Estado.Text) &&
                !string.IsNullOrEmpty(Cidade.Text) &&
                !string.IsNullOrEmpty(Bairro.Text) &&
                !string.IsNullOrEmpty(Rua.Text)
                )
            {
                //limpando os campos
                Estado.Text = "";
                Cidade.Text = "";
                Bairro.Text = "";
                Rua.Text = "";

                //habilitando os campos novamente
                Rua.ReadOnly = true;
                Bairro.ReadOnly = true;
                Cidade.Enabled = false;
                Estado.Enabled = true;

                //Estado.DataSource = ;
                List<EstadoDTO> estados = _EstadoService.ObterEstados();
                Console.WriteLine(estados);
            }
            _debounceCepTimer.Stop(); //limpa o timer anterior
            _debounceCepTimer.Start(); //inicia um novo contador a partir do zero
        }

        private void CEP_Leave(object sender, EventArgs e)
        {
            if (!ValidadorDeClienteEndereco.CEP_Leave(CEP))
            {
                CEP.Focus();
            }
        }
    }
}
