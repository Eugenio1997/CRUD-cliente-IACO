using System;
using System.Windows.Forms;

namespace CRUD_clientes_IACO
{
    public partial class CadastrarCliente : Form
    {

        public CadastrarCliente()
        {
            InitializeComponent();
        }

        private int passoAtual = 0;

        private void btn_proximo_Click(object sender, EventArgs e)
        {
            if (passoAtual < 2)
            {
                passoAtual++;
                MostrarPasso(passoAtual);
            }

        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {

            if (passoAtual > 0)
            {
                passoAtual--;
                MostrarPasso(passoAtual);
            }
        }

        private void MostrarPasso(int passoAtual)
        {

            switch (passoAtual)
            {

                case 0:
                    panel1_endereco.Visible = false;
                    break;

                case 1:
                    panel1_endereco.Visible = true;
                    break;
            }
        }

        private void CadastrarCliente_Load(object sender, EventArgs e)
        {
            MostrarPasso(passoAtual);
        }
    }

}
