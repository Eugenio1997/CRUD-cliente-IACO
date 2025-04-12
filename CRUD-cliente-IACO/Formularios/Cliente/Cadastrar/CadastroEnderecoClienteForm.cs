using System;
using System.Windows.Forms;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.Modelos.DTOs;
using CRUD_cliente_IACO.Modelos;
using Newtonsoft.Json;
using CRUD_cliente_IACO.CustomEventArgs;

namespace CRUD_cliente_IACO.Formularios.Cliente.Cadastrar
{
    public partial class CadastroEnderecoClienteForm : Form, ICadastroEnderecoClienteForm
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ICadastroClienteForm _cadastroClienteForm;
        public event EventHandler OnVoltar;
        private ClienteDTO _clienteDTO;

        public CadastroEnderecoClienteForm(
            IClienteRepository clienteRepository,
            ICadastroClienteForm cadastroClienteForm)
        {
            InitializeComponent();
            if (clienteRepository == null)
                throw new ArgumentNullException(nameof(clienteRepository));
            if (cadastroClienteForm == null)
                throw new ArgumentNullException(nameof(cadastroClienteForm));

            _clienteRepository = clienteRepository;
            _cadastroClienteForm = cadastroClienteForm;
            _cadastroClienteForm.OnClienteDTOEnviado += CadastroClienteForm_OnClienteDTORecebido;


        }

        public void CadastroClienteForm_OnClienteDTORecebido(object sender, ClienteDTOEventArgs e)
        {            
            _clienteDTO = e.ClienteDTO;
        }

        private void Btn_Cadastrar_Click(object sender, EventArgs e)
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            OnVoltar?.Invoke(this, EventArgs.Empty);
        }

    }
}
