using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;


namespace CRUD_clientes_IACO.Modelos
{
    public sealed class Endereco
    {

        [NotNullValidator(MessageTemplate = "O campo CEP é obrigatório.")]
        [StringLengthValidator(3, 50, MessageTemplate = "O CEP deve ter entre 3 e 20 caracteres.")]
        public string CEP { get; set; }

        [NotNullValidator(MessageTemplate = "O campo Rua é obrigatório.")]
        [StringLengthValidator(3, 50, MessageTemplate = "A Rua deve ter entre 3 e 50 caracteres.")]
        public string Rua { get; set; }

        [NotNullValidator(MessageTemplate = "O campo Número da Residência é obrigatório.")]
        [StringLengthValidator(3, 50, MessageTemplate = "O Número da Residência deve ter entre 3 e 50 caracteres.")]
        public string NumeroResidencia { get; set; }

        [NotNullValidator(MessageTemplate = "O campo Bairro é obrigatório.")]
        [StringLengthValidator(3, 50, MessageTemplate = "O Bairro deve ter entre 3 e 50 caracteres.")]
        public string Bairro { get; set; }

        [NotNullValidator(MessageTemplate = "O campo Cidade é obrigatório.")]
        [StringLengthValidator(3, 50, MessageTemplate = "A Cidade deve ter entre 3 e 50 caracteres.")]
        public string Cidade { get; set; }

        [NotNullValidator(MessageTemplate = "O campo Estado é obrigatório.")]
        [StringLengthValidator(3, 50, MessageTemplate = "O Estado deve ter entre 3 e 50 caracteres.")]
        public string Estado { get; set; }

    }
}
