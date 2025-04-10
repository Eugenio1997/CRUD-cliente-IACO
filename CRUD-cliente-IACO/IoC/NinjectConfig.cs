using System.Data;
using Ninject.Modules;
using Oracle.DataAccess.Client;
using System.Configuration;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.Repositorios;
using CRUD_cliente_IACO.Formularios.Cliente.Cadastrar;
using CRUD_cliente_IACO.Modelos.DTOs;
using CRUD_cliente_IACO.Repositorios.Interfaces.Formularios;

namespace CRUD_cliente_IACO.IoC
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            // Configuração da conexão Oracle
            Bind<OracleConnection>()
                .ToSelf()
                .WithConstructorArgument("connectionString",
                    ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString);

            // Bindings para repositórios
            Bind<IClienteRepository>().To<ClienteRepository>().InSingletonScope();

            // Bindings para DTOs
            Bind<ClienteDTO>().ToSelf().InSingletonScope();

            // Bindings para formulários
            Bind<ICadastroClienteForm>().To<CadastroClienteForm>().InSingletonScope();
            Bind<ICadastroEnderecoClienteForm>().To<CadastroEnderecoClienteForm>().InSingletonScope();
            //Bind<CadastroEnderecoClienteForm>().ToSelf().InTransientScope();
        }
    }
} 