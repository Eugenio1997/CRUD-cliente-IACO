using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using CRUD_cliente_IACO.Repositorios.Interfaces;

namespace CRUD_cliente_IACO.Formularios.Cliente.Cadastrar
{
    public partial class CadastroEnderecoClienteForm : Form
    {
        private readonly IClienteRepository _clienteRepository;
        private static CadastroEnderecoClienteForm _instance;

        public static CadastroEnderecoClienteForm instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CadastroEnderecoClienteForm();
                }

                return _instance;
            }
        }

        public CadastroEnderecoClienteForm(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            InitializeComponent();
        }

        // Exemplo de método usando o repository injetado
        private void SalvarEndereco(Modelos.Cliente cliente)
        {
            try
            {
                _clienteRepository.AtualizarCliente(cliente);
                MessageBox.Show("Endereço salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar endereço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
