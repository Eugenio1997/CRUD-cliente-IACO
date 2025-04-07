using System.Data;
using Ninject.Modules;
using Oracle.DataAccess.Client;
using System.Configuration;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.Repositorios;

namespace CRUD_cliente_IACO.IoC
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            
            Bind<OracleConnection>()
                .ToSelf()
                .WithConstructorArgument("connectionString",
                    ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString);

            
            Bind<IClienteRepository>().To<ClienteRepository>();
        }
    }
} 