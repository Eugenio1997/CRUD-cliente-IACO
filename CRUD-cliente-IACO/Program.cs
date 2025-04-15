using System;
using System.Windows.Forms;
using Ninject;
using CRUD_cliente_IACO.IoC;
using CRUD_cliente_IACO.Formularios.Cliente.Cadastrar;
using CRUD_cliente_IACO.Factories;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.Services.Interfaces;

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

            //recuperando a implementacao concreta passando a abstracao atraves de Ninject
            var clienteRepository = _kernel.Get<IClienteRepository>();
            var cepService = _kernel.Get<ICEPService>();


            // Usa a factory para obter as instâncias dos formulários
            var cadastroForm = FormFactory.GetCadastroClienteForm(clienteRepository);
            var enderecoForm = FormFactory.GetCadastroEnderecoClienteForm(clienteRepository, cadastroForm, cepService);

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
