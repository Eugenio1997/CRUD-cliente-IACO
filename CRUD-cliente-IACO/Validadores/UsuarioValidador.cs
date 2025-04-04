using CRUD_clientes_IACO.Modelos;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace CRUD_cliente_IACO.Validadores
{
    class UsuarioValidador
    {
        public static ValidationResults Validar(Cliente usuario)
        {
            Validator<Cliente> validator = ValidationFactory.CreateValidator<Cliente>();
            return validator.Validate(usuario);
        }
    }
}
