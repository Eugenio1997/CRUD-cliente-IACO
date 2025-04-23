using CRUD_cliente_IACO.Enums;
using CRUD_cliente_IACO.Formularios.Cliente.Listar;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using System;

using System.Windows.Forms;

namespace CRUD_cliente_IACO.Formularios.Cliente.Editar
{
    public partial class EditarClienteForm : Form
    {

        private readonly IClienteRepository _clienteRepository;

        public Modelos.Cliente clienteAtual;
        public EditarClienteForm(
            Modelos.Cliente cliente,
            ListaClienteForm _listaClienteForm,
            IClienteRepository clienteRepository = null
            )
        {
            InitializeComponent();
            clienteAtual = cliente;
            PreencherCampos();
            _clienteRepository = clienteRepository;
        }


        private void PreencherCampos()
        {
            Genero.DataSource = Enum.GetValues(typeof(GenerosEnum));

            
            PrimeiroNome.Text = clienteAtual.PrimeiroNome;
            Sobrenome.Text = clienteAtual.Sobrenome;
            CPF.Text = clienteAtual.CPF;
            Email.Text = clienteAtual.Email;
            Telefone.Text = clienteAtual.Telefone;
            Genero.SelectedItem = clienteAtual.Genero;
            DataDeNascimento.Value = clienteAtual.DataNascimento;

        }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                var clienteAtualizado = new Modelos.Cliente
                {
                    IdCliente = clienteAtual.IdCliente,
                    PrimeiroNome = PrimeiroNome.Text,
                    Sobrenome = Sobrenome.Text,
                    Email = Email.Text,
                    Telefone = Telefone.Text,
                    CPF = CPF.Text,
                    DataNascimento = DataDeNascimento.Value,
                    Genero = (GenerosEnum)Genero.SelectedItem
                };

                _clienteRepository.AtualizarCliente(clienteAtualizado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("O erro é o seguinte: " + ex.Message);
            }

            this.Close();
     
        }
    }
}
