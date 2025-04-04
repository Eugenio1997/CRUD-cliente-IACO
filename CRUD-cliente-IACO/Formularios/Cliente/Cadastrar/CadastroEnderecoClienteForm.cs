using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRUD_cliente_IACO.Formularios.Cliente.Cadastrar
{
    public partial class CadastroEnderecoClienteForm : Form
    {

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

        public CadastroEnderecoClienteForm()
        {
            InitializeComponent();
        }
    }
}
