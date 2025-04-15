using System;
using System.Windows.Forms;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.Modelos.DTOs;
using CRUD_cliente_IACO.Modelos;
using Newtonsoft.Json;
using CRUD_cliente_IACO.CustomEventArgs;
using CRUD_cliente_IACO.Validacoes;
using CRUD_cliente_IACO.Services.Interfaces;

namespace CRUD_cliente_IACO.Formularios.Cliente.Cadastrar
{
    public partial class CadastroEnderecoClienteForm : Form, ICadastroEnderecoClienteForm
    {
        //flags
        private bool dadosRecuperadosPorCepService = false;

        //Repositorios (Camada de acesso ao banco)
        private readonly IClienteRepository _clienteRepository;

        //Formularios
        private readonly ICadastroClienteForm _cadastroClienteForm;

        //Servicos
        private ICEPService _CEPService;

        //Eventos
        public event EventHandler OnVoltar;

        //DTO's
        private ClienteDTO _clienteDTO;

        public CadastroEnderecoClienteForm(
            IClienteRepository clienteRepository,
            ICadastroClienteForm cadastroClienteForm,
            ICEPService CEPService)
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

            //verifica se o controle está em branco ou se foi inserido letras
            if (ValidadorDeClienteEndereco.CEP_TextChanged(CEP))
            {
                dadosRecuperadosPorCepService = true;
                //fazer request para obter dados de endereco baseado no cep
                EnderecoDTO cepDados = _CEPService.ConsultarEnderecoPorCep(CEP.Text);
                Rua.Text = cepDados.Rua;
                Bairro.Text = cepDados.Bairro;
                Cidade.Text = cepDados.Cidade;
                Estado.Text = cepDados.Estado;


                Rua.ReadOnly = true;
                Bairro.ReadOnly = true;
                Cidade.Enabled = false;
                Estado.Enabled = false;

                NResidencia.Focus();
                return;
            }
            else
            {
                MessageBox.Show("CPF Inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CEP.Focus();
            }
        }
    }
}
