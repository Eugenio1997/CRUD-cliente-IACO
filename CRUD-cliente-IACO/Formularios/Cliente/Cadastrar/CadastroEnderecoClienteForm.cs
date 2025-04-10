using System;
using System.Windows.Forms;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.Enums;
using CRUD_cliente_IACO.Repositorios.Interfaces.Formularios;
using CRUD_cliente_IACO.Modelos.DTOs;
using CRUD_cliente_IACO.CustomEventArgs;

namespace CRUD_cliente_IACO.Formularios.Cliente.Cadastrar
{
    public partial class CadastroEnderecoClienteForm : Form, ICadastroEnderecoClienteForm
    {
        private readonly IClienteRepository _clienteRepository;
        private ClienteDTO _clienteDTO;
        private ICadastroClienteForm _cadastroClientForm;
        public event EventHandler OnVoltar;


        public CadastroEnderecoClienteForm(IClienteRepository clienteRepository)
        {
            InitializeComponent();
            if (clienteRepository == null)
                throw new ArgumentNullException(nameof(clienteRepository));


            _clienteRepository = clienteRepository;

            //_cadastroClientForm.ClienteDTOEnviado += CadastroClienteForm_ClienteDTOEnviado;

        }

       

        public void CadastroClienteForm_ClienteDTOEnviado(object sender, ClienteDTOEventArgs e)
        {
            ClienteDTO clienteDTO = e.ClienteDTO;
            MessageBox.Show($"Cliente recebido: {clienteDTO.PrimeiroNome}, nasceu em {clienteDTO.DataNascimento.Year}.");
        }

        public void SalvarCliente()
        {
            try
            {
                Modelos.Cliente clientNovo = _clienteDTO.ToCliente();
                clientNovo.Endereco.CEP = CEP.Text;
                clientNovo.Endereco.Rua = Rua.Text;
                clientNovo.Endereco.NumeroResidencia = NResidencia.Text;
                clientNovo.Endereco.Cidade = Cidade.Text;
                clientNovo.Endereco.Estado = Estado.Text;
                /*
                    1. Recuperar o ClienteDTO instanciado no formulario anterior
                    2. Fazer o cast do ClienteDTO para Cliente
                    3. Adicionar à propriedade Endereço do Cliente os respectivos valores
                */

                MessageBox.Show(clientNovo.ToString());

                //_clienteRepository.InserirCliente(cliente);
                MessageBox.Show("Cliente salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar Cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        public void Btn_Voltar_Click(object sender, EventArgs e)
        {

            if (OnVoltar != null)
                OnVoltar(this, EventArgs.Empty);
        }

        private void Btn_Cadastrar_Click(object sender, System.EventArgs e)
        {
            SalvarCliente();
        }

        public void AdicionarEventosNosCampos()
        {
            throw new NotImplementedException();
        }

        public void VerificarCamposPreenchidos()
        {
            throw new NotImplementedException();
        }
    }
}
