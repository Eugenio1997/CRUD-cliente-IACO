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

            // Configurar Ninject
            _kernel = new StandardKernel(new NinjectConfig());

            // Criar o formulário principal usando Ninject
            var mainForm = _kernel.Get<CadastroClienteForm>();
            
            Application.Run(mainForm);
        }
    }
}
