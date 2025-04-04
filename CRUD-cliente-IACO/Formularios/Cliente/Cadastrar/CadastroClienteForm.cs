using CRUD_cliente_IACO.Enums;
using CRUD_cliente_IACO.Formularios.Cliente.Cadastrar;
using CRUD_cliente_IACO.Validadores;
using CRUD_clientes_IACO.Modelos;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CRUD_clientes_IACO
{
    public partial class CadastrarCliente : Form
    {
        private string primeiroNomeRegex = @"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{3,50}$";
        private string CPFRegex = @"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$";
        private string telefoneRegex = @"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$";
        private string emailRegex = @"^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,})+$";

        private static CadastrarCliente _instance;
        private int passoAtual = 0;

        public CadastrarCliente()
        {
            InitializeComponent();
            AdicionarEventosNosCampos();
            PreencherComboBoxGeneros();
            PrimeiroNome.Validating += PrimeiroNome_Validating; ;
        }

        /// Seguindo o padrao Singleton
        public static CadastrarCliente instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CadastrarCliente();
                }

                return _instance;
            }
        }


        private void MostrarPasso()
        {
            if (passoAtual == 0)
            {
                this.Show();
                CadastroEnderecoClienteForm.instance.Hide();
            }
            else if (passoAtual == 1)
            {
                this.Hide();
                CadastroEnderecoClienteForm.instance.Show();
            }
        }





        private void CadastrarCliente_Load(object sender, EventArgs e)
        {
            MostrarPasso();
        }

        private void PrimeiroNome_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string valor = PrimeiroNome.Text;

            if (string.IsNullOrEmpty(valor) || !Regex.IsMatch(valor, primeiroNomeRegex))
            {
                MessageBox.Show("O Primeiro Nome é obrigatório e deve ter entre 3 e 50 caracteres válidos.", "Erro de Validação");
                PrimeiroNome.Focus(); // opcional, o foco já será mantido por causa do e.Cancel
                e.Cancel = true; // impede o usuário de sair do campo até corrigir
            }
        }

        private void Btn_Proximo_Click(object sender, EventArgs e)
        {
            Cliente clienteNovo = new Cliente {
                
            };
            //fazer validação
            //UsuarioValidador.instance.Validar()

            if (passoAtual == 0)
            {
                passoAtual = 1;
                MostrarPasso();
            }
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
            DataDeNascimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
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