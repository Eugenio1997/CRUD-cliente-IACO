using CRUD_cliente_IACO.Infraestrutura;
using System;
using System.Data;
using System.Windows.Forms;

namespace CadastroDeCliente
{
    public partial class FormListagemDeClientes : Form
    {

        
        public FormListagemDeClientes()
        {
            InitializeComponent();
           
        }


        private void showClientsOnDatagrid()
        {
            try
            {
                DataTable dt = DalHelper.GetClients();
                if (dt != null && dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
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
