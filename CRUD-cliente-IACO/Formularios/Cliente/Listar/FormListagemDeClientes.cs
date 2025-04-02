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
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormListagemDeClientes_Load(object sender, EventArgs e)
        {
            showClientsOnDatagrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
