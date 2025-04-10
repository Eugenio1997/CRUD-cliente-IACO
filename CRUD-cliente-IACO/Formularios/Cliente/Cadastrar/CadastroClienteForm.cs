using CRUD_cliente_IACO.Enums;
using System;
using System.Windows.Forms;
using CRUD_cliente_IACO.Modelos.DTOs;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.Repositorios.Interfaces.Formularios;
using CRUD_cliente_IACO.CustomEventArgs;

namespace CRUD_cliente_IACO.Formularios.Cliente.Cadastrar
{
    public partial class CadastroClienteForm : Form, ICadastroClienteForm
    {
        //private string primeiroNomeRegex = @"^[A-Za-z---\s'-]{3,50}$";
        //private string CPFRegex = @"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$";
        //private string telefoneRegex = @"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$";
        //private string emailRegex = @"^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,})+$";

        private ClienteDTO _clienteDTO;
        private readonly IClienteRepository _clienteRepository;
        private readonly ICadastroEnderecoClienteForm _cadastroEnderecoClienteForm;

        public event EventHandler OnProximo;
        public event EventHandler OnVoltar;
        public event EventHandler<ClienteDTOEventArgs> ClienteDTOEnviado;

        /// <summary>
        /// VALIDACOES DE CADA CAMPO DO FORMULARIO
        /// </summary>

        /*
        private void PrimeiroNome_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string valor = PrimeiroNome.Text;

            if (string.IsNullOrEmpty(valor) || !Regex.IsMatch(valor, primeiroNomeRegex))
            {
                MessageBox.Show("O campo Primeiro Nome obrigatrio e deve conter apenas letras, com 3 a 50 caracteres.", "Erro de Validao");
                PrimeiroNome.Focus();
                e.Cancel = true;
            }
        }
        */

        public CadastroClienteForm(IClienteRepository clienteRepository, ICadastroEnderecoClienteForm cadastroEnderecoClienteForm)
        {
            InitializeComponent();
            _clienteRepository = clienteRepository;
            _cadastroEnderecoClienteForm = cadastroEnderecoClienteForm;
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Configuração inicial do formulário
            AdicionarEventosNosCampos();
            PreencherComboBoxGeneros();
        }

        public void PreencherComboBoxGeneros()
        {
            Genero.DataSource = Enum.GetValues(typeof(GenerosEnum));
            Genero.SelectedItem = GenerosEnum.Homem;
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
                else if (ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).SelectedIndexChanged += (sender, e) => VerificarCamposPreenchidos();
                }
            }

            Btn_Proximo.Enabled = false;
        }

        public void VerificarCamposPreenchidos()
        {
            /// excluindo os caracteres da máscara
            CPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            Telefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            bool todosPreenchidos = !string.IsNullOrEmpty(PrimeiroNome.Text.Trim()) &&
                                   !string.IsNullOrEmpty(Sobrenome.Text.Trim()) &&
                                   Genero.SelectedIndex != -1 &&
                                   !string.IsNullOrEmpty(CPF.Text.Trim()) &&
                                   !string.IsNullOrEmpty(DataDeNascimento.Text.Trim()) &&
                                   !string.IsNullOrEmpty(Telefone.Text.Trim()) &&
                                   !string.IsNullOrEmpty(Email.Text.Trim());

            Btn_Proximo.Enabled = todosPreenchidos;
        }

        public void Btn_Proximo_Click(object sender, EventArgs e)
        {

            _clienteDTO.PrimeiroNome = PrimeiroNome.Text;
            _clienteDTO.Sobrenome = Sobrenome.Text;
            _clienteDTO.Telefone = Telefone.Text;
            _clienteDTO.CPF = CPF.Text;
            _clienteDTO.DataNascimento = DataDeNascimento.Value;
            _clienteDTO.Email = Email.Text;
            _clienteDTO.Genero = (GenerosEnum)Genero.SelectedItem;



            // Dispara o evento com os dados do cliente
            ClienteDTOEnviado?.Invoke(this, new ClienteDTOEventArgs(_clienteDTO));
            
            OnProximo?.Invoke(this, e);
        }

        public void Btn_Limpar_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = "";

                else if (ctrl is ComboBox)
                    ((ComboBox)ctrl).SelectedIndex = -1;

                else if (ctrl is MaskedTextBox)
                    ((MaskedTextBox)ctrl).Text = "";
            }

            Btn_Proximo.Enabled = false;
        }

      
    }
}
 