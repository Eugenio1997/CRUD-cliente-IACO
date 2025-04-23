using CRUD_cliente_IACO.Enums;
using System;
using System.Windows.Forms;
using CRUD_cliente_IACO.Modelos.DTOs;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.CustomEventArgs;
using CRUD_cliente_IACO.Validacoes;
using System.Collections.Generic;
using CRUD_cliente_IACO.Modelos;
using CRUD_cliente_IACO.Formularios.Interfaces;
using CRUD_cliente_IACO.Formularios.Cliente.Listar;
using System.Drawing;

namespace CRUD_cliente_IACO.Formularios.Cliente.Cadastrar
{
    public partial class CadastroClienteForm : Form, ICadastroClienteForm
    {
        private string primeiroNomeRegex = @"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{3,50}$";
        //private string CPFRegex = @"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$";
        //private string telefoneRegex = @"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$";
        //private string emailRegex = @"^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,})+$";

        
        private IClienteRepository _clienteRepository;
        private ListaClienteForm _listaClienteForm;
        public ClienteDTO clienteDTO;

        //public event EventHandler OnVoltar;
        public event EventHandler OnProximo;
        public event EventHandler<ClienteEventArgs> OnClienteEnviado;

        private bool _estaLimpandoCampos = false;
        /// <summary>
        /// VALIDACOES DE CADA CAMPO DO FORMULARIO
        /// </summary>

        public CadastroClienteForm(
            IClienteRepository clienteRepository,
            ListaClienteForm listaClienteForm = null
            )
        {
            InitializeComponent();
            if (clienteRepository == null)
                throw new ArgumentNullException(nameof(clienteRepository));
           

            AdicionarEventosNosCampos();
            PreencherComboBoxGeneros();

            _clienteRepository = clienteRepository;
            _listaClienteForm = listaClienteForm;
            DataDeNascimento.Format = DateTimePickerFormat.Custom;
            DataDeNascimento.CustomFormat = "dd/MM/yyyy";

            //Eventos LEAVE de cada campo
            CamposTodos_Validating();

            //Eventos KeyPress de cada campo

            PrimeiroNome.KeyPress += PrimeiroNome_KeyPress;
            Sobrenome.KeyPress += Sobrenome_KeyPress;
            Genero.SelectedIndexChanged += Genero_SelectedIndexChanged;

        }

        public void DefinirFormularioLista(ListaClienteForm listaForm)
        {
            _listaClienteForm = listaForm;
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

            Btn_Cadastrar.Enabled = false;
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

           Btn_Cadastrar.Enabled = todosPreenchidos;
       }

       public void PreencherComboBoxGeneros()
       {
            
            var generos = new List<string>
            {
                "Selecione o gênero",
                GenerosEnum.Homem.ToString(),
                GenerosEnum.Mulher.ToString(),
                GenerosEnum.PrefiroNaoIdentificar.ToString()
            };

           Genero.DataSource = generos;
           Genero.SelectedIndex = 0;

       }

        public void Btn_Limpar_Click(object sender, EventArgs e)
        {
            _estaLimpandoCampos = true;

            foreach (Control controle in this.Controls)
            {
                if (controle is TextBox)
                    ((TextBox)controle).Text = "";

                else if (controle is ComboBox)
                    ((ComboBox)controle).SelectedIndex = 0;

                else if (controle is MaskedTextBox)
                    ((MaskedTextBox)controle).Text = "";

                else if (controle is DateTimePicker)
                {
                    ((DateTimePicker)controle).Value = DateTime.Now;
                }
            }

            Btn_Cadastrar.Enabled = false;
          
            // Foco no primeiro campo
            PrimeiroNome.Focus();
            _estaLimpandoCampos = false;

        }

        private void PrimeiroNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorDeCliente.ValidarPrimeiroNome_KeyPress(PrimeiroNome, e);
        }
        private void Sobrenome_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorDeCliente.ValidarSobreNome_KeyPress(Sobrenome, e);
        }
        private void Genero_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (_estaLimpandoCampos) return;

            string generoSelecionado = Genero.SelectedItem?.ToString();

            // Exemplo: Exibir no console
            Console.WriteLine("Gênero selecionado: " + generoSelecionado);

            // Se quiser, pode validar aqui:
            ValidadorDeCliente.ValidarGenero_SelectedIndexChanged(Genero);
        }



        //Referencia os eventos VALIDATING de cada campo
        private void CamposTodos_Validating()
        {
            PrimeiroNome.Validating += PrimeiroNome_Validating;
            Sobrenome.Validating += Sobrenome_Validating;
            Genero.Validating += Genero_Validating;
            CPF.Validating += CPF_Validating;
            Telefone.Validating += Telefone_Validating;
            Email.Validating += Email_Validating;
        }

        //Eventos VALIDATING
        private void PrimeiroNome_Validating(object sender, EventArgs e)
        {
            ValidadorDeCliente.ValidarPrimeiroNome_Validating(PrimeiroNome);
            
        }

        private void Sobrenome_Validating(object sender, EventArgs e)
        {
            ValidadorDeCliente.ValidarSobrenome_Validating(Sobrenome);
        }

        private void Genero_Validating(object sender, EventArgs e)
        {
            ValidadorDeCliente.ValidarGenero_Validating(Genero);
        }

        private void CPF_Validating(object sender, EventArgs e)
        {
            ValidadorDeCliente.ValidarCPF_Validating(CPF);
        }

        private void Telefone_Validating(object sender, EventArgs e)
        {
            ValidadorDeCliente.ValidarTelefone_Validating(Telefone);
        }

        private void Email_Validating(object sender, EventArgs e)
        {
            ValidadorDeCliente.ValidarEmail_Validating(Email);
        }

        public void Btn_Cadastrar_Click(object sender, EventArgs e)
        {
            // Preenche o Cliente com os dados do formulário
            var cliente = new Modelos.Cliente
            {
                PrimeiroNome = PrimeiroNome.Text,
                Sobrenome = Sobrenome.Text,
                Email = Email.Text,
                Telefone = Telefone.Text,
                CPF = CPF.Text,
                DataNascimento = DataDeNascimento.Value,
                Genero = (GenerosEnum)Enum.Parse(typeof(GenerosEnum), Genero.SelectedItem.ToString())
            };


            Console.WriteLine(cliente);
            var confirmar = MessageBox.Show("Tem certeza que deseja cadastrar?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar == DialogResult.Yes)
            {
                _clienteRepository.InserirCliente(cliente);
                Close();
            }

            //verifica se algum código se inscreveu no evento e dispara evento
            //OnClienteEnviado.Invoke(this, new ClienteEventArgs(cliente));


            /*
            if (_listaClienteForm != null)
            {
                _listaClienteForm.StartPosition = FormStartPosition.Manual;
                _listaClienteForm.Location = new Point(0, 0); // canto superior esquerdo
                _listaClienteForm.Show();
                _listaClienteForm.BringToFront();
            }
            */

        }
    }
}
 