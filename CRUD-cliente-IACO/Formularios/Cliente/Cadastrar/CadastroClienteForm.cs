using CRUD_cliente_IACO.Enums;
using System;
using System.Windows.Forms;
using CRUD_cliente_IACO.Modelos.DTOs;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.CustomEventArgs;

namespace CRUD_cliente_IACO.Formularios.Cliente.Cadastrar
{
    public partial class CadastroClienteForm : Form, ICadastroClienteForm
    {
        //private string primeiroNomeRegex = @"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{3,50}$";
        //private string CPFRegex = @"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$";
        //private string telefoneRegex = @"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$";
        //private string emailRegex = @"^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,})+$";

        
        private IClienteRepository _clienteRepository;
        public ClienteDTO clienteDTO;

        //public event EventHandler OnVoltar;
        public event EventHandler OnProximo;
        public event EventHandler<ClienteDTOEventArgs> OnClienteDTOEnviado;

        /// <summary>
        /// VALIDACOES DE CADA CAMPO DO FORMULARIO
        /// </summary>

        /*
        private void PrimeiroNome_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string valor = PrimeiroNome.Text;

            if (string.IsNullOrEmpty(valor) || !Regex.IsMatch(valor, primeiroNomeRegex))
            {
                MessageBox.Show("O campo Primeiro Nome é obrigatório e deve conter apenas letras, com 3 a 50 caracteres.", "Erro de Validação");
                PrimeiroNome.Focus();
                e.Cancel = true;
            }
        }
        */


        public CadastroClienteForm(IClienteRepository clienteRepository)
        {
            InitializeComponent();
            if (clienteRepository == null)
                throw new ArgumentNullException(nameof(clienteRepository));
            AdicionarEventosNosCampos();
            PreencherComboBoxGeneros();
            Console.WriteLine($"CadastroClienteForm (NO CONSTRUTOR) criado - HashCode: {this.GetHashCode()}");

            _clienteRepository = clienteRepository;
            //PrimeiroNome.Validating += PrimeiroNome_Validating; ;
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

       public void PreencherComboBoxGeneros()
       {
           Genero.DataSource = Enum.GetValues(typeof(GenerosEnum));
           Genero.SelectedItem = GenerosEnum.Homem;

       }

        public void Btn_Proximo_Click(object sender, EventArgs e)
        {
            // Preenche o DTO com os dados do formulário
            clienteDTO = new ClienteDTO
            {
                PrimeiroNome = PrimeiroNome.Text,
                Sobrenome = Sobrenome.Text,
                Email = Email.Text,
                Telefone = Telefone.Text,
                CPF = CPF.Text,
                DataNascimento = DataDeNascimento.Value,
                Genero = (GenerosEnum)Genero.SelectedValue,
            };


            //verifica se algum código se inscreveu no evento e dispara evento
            OnClienteDTOEnviado.Invoke(this, new ClienteDTOEventArgs(clienteDTO));        
                
            if(OnClienteDTOEnviado != null)
                OnProximo?.Invoke(this, EventArgs.Empty);
        }

        public void Btn_Limpar_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = "";

                else if (ctrl is ComboBox)
                    ((ComboBox)ctrl).SelectedIndex = 0;

                else if (ctrl is MaskedTextBox)
                    ((MaskedTextBox)ctrl).Text = "";
            }

            Btn_Proximo.Enabled = false;
        }
    }
}
 