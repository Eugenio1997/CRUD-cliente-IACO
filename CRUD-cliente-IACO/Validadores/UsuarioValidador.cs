using CRUD_clientes_IACO.Modelos;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace CRUD_cliente_IACO.Validadores
{
    class UsuarioValidador
    {

        private static UsuarioValidador _instance;
        public ValidationResults Validar(Cliente usuario)
        {
            Validator<Cliente> validator = ValidationFactory.CreateValidator<Cliente>();
            return validator.Validate(usuario);
        }

        public static UsuarioValidador instance {
            get
            {
                if(_instance == null)
                {
                    _instance = new UsuarioValidador();
                }

                return _instance;
            }
        }
    }
}
