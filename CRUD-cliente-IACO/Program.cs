using System;
using System.Windows.Forms;
using Ninject;
using CRUD_cliente_IACO.IoC;
using CRUD_cliente_IACO.Formularios.Cliente.Cadastrar;

namespace CRUD_cliente_IACO
{
    static class Program
    {
        private static IKernel _kernel;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _kernel = new StandardKernel(new NinjectConfig());

            // Cria os dois formulários com injeção
            var cadastroForm = _kernel.Get<CadastroClienteForm>();
            var enderecoForm = _kernel.Get<CadastroEnderecoClienteForm>();

            // Evento: Avançar para o próximo formulário
            cadastroForm.OnProximo += (s, e) =>
            {
                cadastroForm.Hide();
                enderecoForm.Show();
            };

            // Evento: Voltar para o formulário anterior
            enderecoForm.OnVoltar += (s, e) =>
            {
                enderecoForm.Hide();
                cadastroForm.Show();
            };

            Application.Run(cadastroForm);
        }
    }
}
