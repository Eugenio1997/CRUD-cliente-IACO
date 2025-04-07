
using CRUD_cliente_IACO.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CRUD_cliente_IACO.Modelos;

namespace CRUD_cliente_IACO.Formularios.Cliente.Listar
{
    public partial class ListaClienteForm : Form
    {
        private readonly IClienteRepository _clienteRepository;

        public ListaClienteForm(IClienteRepository clienteRepository)
        {
            if(clienteRepository == null)
            {
                throw new ArgumentNullException(nameof(clienteRepository));
            }
                InitializeComponent();
                _clienteRepository = clienteRepository;
        }


        private void showClientsOnDatagrid()
        {
            try
            {
                //DataTable dt = DalHelper.GetClients();
                List<Modelos.Cliente> listaClientes = _clienteRepository.ConsultarClientes();
                if (listaClientes != null && listaClientes.Count > 0)
                {
                    dataGridView1.DataSource = listaClientes;
                }
                else
                {
                    MessageBox.Show("Nenhum dado encontrado.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormListagemDeClientes_Load(object sender, EventArgs e)
        {
            showClientsOnDatagrid();
        }

    }
}
