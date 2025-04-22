using System;
using System.Windows.Forms;
using Ninject;
using CRUD_cliente_IACO.IoC;
using CRUD_cliente_IACO.Formularios.Cliente.Cadastrar;
using CRUD_cliente_IACO.Factories;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.Services.Interfaces;
using Oracle.DataAccess.Client;
using System.Configuration;

namespace CRUD_cliente_IACO
{
    public class Program
    {
        private static IKernel _kernel;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _kernel = new StandardKernel(new NinjectConfig());

            //recuperando a implementacao concreta passando a abstracao atraves de Ninject
            var clienteRepository = _kernel.Get<IClienteRepository>();
            /*
            var cepService = _kernel.Get<ICEPService>();
            var estadoService = _kernel.Get<IEstadoService>();
            var cidadeService = _kernel.Get<ICidadeService>();
            */

            // Primeiro cria o CadastroClienteForm com valor temporário null
            var cadastroFormTemp = FormFactory.GetCadastroClienteForm(clienteRepository, null);

            // Depois cria o ListaClienteForm passando o cadastro real
            var listaForm = FormFactory.GetListagemClienteForm(clienteRepository, cadastroFormTemp);

            // Agora atualiza o campo listaForm dentro do cadastroForm
            cadastroFormTemp.DefinirFormularioLista(listaForm);
            /*
            var enderecoForm = FormFactory.GetCadastroEnderecoClienteForm(
                clienteRepository, cadastroForm, cepService,
                estadoService, cidadeService, listaForm
           );
           */
            // Evento: Avançar para o próximo formulário
            /*
             cadastroForm.OnProximo += (s, e) =>
             {
                 cadastroForm.Hide();
                 listaForm.Show();
             }
             */

            string connString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;

            using (var conn = new OracleConnection(connString))
            {
       
                // Rodar o seeder
                DatabaseSeeder.Seed(conn);

                // Abrir o formulário principal
                Application.Run(cadastroFormTemp);
            }



        }
    }
}
