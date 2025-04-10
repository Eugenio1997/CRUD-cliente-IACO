using CRUD_cliente_IACO.CustomEventArgs;
using CRUD_cliente_IACO.Enums;
using CRUD_cliente_IACO.Formularios.Cliente.Cadastrar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO.Repositorios.Interfaces.Formularios
{
    public interface ICadastroClienteForm
    {
        //métodos
        void AdicionarEventosNosCampos();
        void VerificarCamposPreenchidos();
        void PreencherComboBoxGeneros();
        void Btn_Limpar_Click(object sender, EventArgs e);
        void Btn_Proximo_Click(object sender, EventArgs e);

        //eventos
        event EventHandler<ClienteDTOEventArgs> ClienteDTOEnviado;
        event EventHandler OnProximo;
      
    }
}
