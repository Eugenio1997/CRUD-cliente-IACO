using CRUD_cliente_IACO.CustomEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO.Repositorios.Interfaces.Formularios
{
    public interface ICadastroEnderecoClienteForm
    {
        //métodos
        void AdicionarEventosNosCampos();
        void VerificarCamposPreenchidos();
        void Btn_Voltar_Click(object sender, EventArgs e);
        void SalvarCliente();
        void CadastroClienteForm_ClienteDTOEnviado(object sender, ClienteDTOEventArgs e);
   
        //eventos
        event EventHandler OnVoltar;
    }
}
