using CRUD_cliente_IACO.Enums;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CRUD_cliente_IACO.Modelos.DTOs;
using System.Globalization;
using CRUD_cliente_IACO.Repositorios.Interfaces;

namespace CRUD_cliente_IACO.Formularios.Cliente.Cadastrar
{
    public partial class CadastroClienteForm : Form
    {
        //private string primeiroNomeRegex = @"^[A-Za-z�-��-��-�\s'-]{3,50}$";
        //private string CPFRegex = @"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$";
        //private string telefoneRegex = @"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$";
        //private string emailRegex = @"^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,})+$";

        public readonly ClienteDTO _clienteDTO;
        private static CadastroClienteForm _instance;
        public event EventHandler OnProximo;
        private readonly IClienteRepository _clienteRepository;


        /// <summary>
        /// VALIDACOES DE CADA CAMPO DO FORMULARIO
        /// </summary>

        /*
        private void PrimeiroNome_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string valor = PrimeiroNome.Text;

            if (string.IsNullOrEmpty(valor) || !Regex.IsMatch(valor, primeiroNomeRegex))
            {
                MessageBox.Show("O campo Primeiro Nome � obrigat�rio e deve conter apenas letras, com 3 a 50 caracteres.", "Erro de Valida��o");
                PrimeiroNome.Focus();
                e.Cancel = true;
            }
        }
        */

        public CadastroClienteForm()
        {

        }

        public CadastroClienteForm(IClienteRepository clienteRepository)
        {
            InitializeComponent();
            AdicionarEventosNosCampos();
            PreencherComboBoxGeneros();
            _clienteDTO = new ClienteDTO();
            _clienteRepository = clienteRepository;
            
            //PrimeiroNome.Validating += PrimeiroNome_Validating; ;
        }

        /// Seguindo o padrao Singleton
        public static CadastroClienteForm GetInstance(IClienteRepository clienteRepository)
        {
          
            if (_instance == null)
            {
                _instance = new CadastroClienteForm(clienteRepository);
            }

            return _instance;
           
        }

        /*
        private void MostrarPasso()
        {
            if (passoAtual == (int)FormTypeEnum.CadastroDadosPessoaisCliente)
            {
                this.Show();
                CadastroEnderecoClienteForm.GetInstance(_clienteRepository).Hide();
            }
            else if (passoAtual == (int)FormTypeEnum.CadastroEnderecoCliente)
            {
                this.Hide();
                CadastroEnderecoClienteForm.GetInstance(_clienteRepository).Show();
            }
        }

       
        private void CadastrarCliente_Load(object sender, EventArgs e)
        {
            MostrarPasso();
        }
         */

        private void Btn_Proximo_Click(object sender, EventArgs e)
        {

            // Preenche o DTO com os dados do formulário
            _clienteDTO.PrimeiroNome = PrimeiroNome.Text;
            _clienteDTO.Sobrenome = Sobrenome.Text;
            _clienteDTO.Email = Email.Text;
            _clienteDTO.DataNascimento = DataDeNascimento.Value;
            _clienteDTO.Telefone = Telefone.Text;
            _clienteDTO.CPF = CPF.Text;
            _clienteDTO.Genero = (GenerosEnum)Genero.SelectedItem;


            // Dispara o evento
            if (OnProximo != null)
                OnProximo(this, EventArgs.Empty);
            /*
            if (passoAtual == 0)
            {
                passoAtual = 1;
                MostrarPasso();
            }
            */
        }

        

        private void Btn_Limpar_Click(object sender, EventArgs e)
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

        private void AdicionarEventosNosCampos()
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

       private void VerificarCamposPreenchidos()
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

       private void PreencherComboBoxGeneros()
       {
           Genero.DataSource = Enum.GetValues(typeof(GenerosEnum));
           Genero.SelectedItem = GenerosEnum.Homem;
       }

    }
}
 