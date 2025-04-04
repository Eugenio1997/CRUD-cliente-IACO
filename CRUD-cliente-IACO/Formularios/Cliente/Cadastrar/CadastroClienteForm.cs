using CRUD_cliente_IACO.Enums;
using CRUD_cliente_IACO.Formularios.Cliente.Cadastrar;
using System;
using System.Windows.Forms;

namespace CRUD_clientes_IACO
{
    public partial class CadastrarCliente : Form
    {

        private static CadastrarCliente _instance;

        public CadastrarCliente()
        {
            InitializeComponent();
            AdicionarEventosNosCampos();
            PreencherComboBoxGeneros();
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

        private int passoAtual = 0;

        


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

        

        private void Btn_Proximo_Click(object sender, EventArgs e)
        {
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

        private void Genero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}