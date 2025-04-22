using CRUD_cliente_IACO.CustomEventArgs;
using CRUD_cliente_IACO.Formularios.Cliente.Cadastrar;
using CRUD_cliente_IACO.Modelos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO.Repositorios.Interfaces
{
    public interface ICadastroClienteForm
    {

        event EventHandler<ClienteEventArgs> OnClienteEnviado;
        
        void Btn_Cadastrar_Click(object sender, EventArgs e);
        void Btn_Limpar_Click(object sender, EventArgs e);
        void AdicionarEventosNosCampos();
        void VerificarCamposPreenchidos();
        void PreencherComboBoxGeneros();
    }
}
