using System;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using CRUD_cliente_IACO.Enums;

namespace CRUD_cliente_IACO.Modelos
{
    public class Cliente
    {
        [NotNullValidator(MessageTemplate = "O campo IdCliente é obrigatório.")]
        [RangeValidator(1, RangeBoundaryType.Inclusive, int.MaxValue, RangeBoundaryType.Inclusive, MessageTemplate = "O IdCliente deve ser um número inteiro positivo.")]
        public int IdCliente { get; set; }

        [NotNullValidator(MessageTemplate = "O campo Primeiro Nome é obrigatório.")]
        [StringLengthValidator(3, 50, MessageTemplate = "O Primeiro Nome deve ter entre 3 e 50 caracteres.")]
        [RegexValidator(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{3,50}$", MessageTemplate = "O Nome contém caracteres inválidos.")]
        public string PrimeiroNome { get; set; }

        [NotNullValidator(MessageTemplate = "O campo Sobrenome é obrigatório.")]
        [StringLengthValidator(3, 50, MessageTemplate = "O Sobrenome deve ter entre 3 e 50 caracteres.")]
        [RegexValidator(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{3,50}$", MessageTemplate = "O Sobrenome contém caracteres inválidos.")]
        public string Sobrenome { get; set; }

        [NotNullValidator(MessageTemplate = "O campo Gênero é obrigatório.")]
        public GenerosEnum Genero { get; set; }
        [NotNullValidator(MessageTemplate = "O campo CPF é obrigatório.")]
        [StringLengthValidator(3, 50, MessageTemplate = "O CPF deve ter entre 3 e 50 caracteres.")]
        [RegexValidator(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$", MessageTemplate = "Formato de CPF inválido.")]
        public string CPF { get; set; }

        [NotNullValidator(MessageTemplate = "O campo Data de Nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [NotNullValidator(MessageTemplate = "O campo Telefone é obrigatório.")]
        [RegexValidator(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$", MessageTemplate = "Formato de Telefone inválido.")]
        public string Telefone { get; set; }

        [NotNullValidator(MessageTemplate = "O campo Email é obrigatório.")]
        [StringLengthValidator(3, 50, MessageTemplate = "O Email deve ter entre 3 e 50 caracteres.")]
        [RegexValidator(@"^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,})+$", MessageTemplate = "Formato de Email inválido.")]
        /// https://regex101.com/r/UMgluf/1 (link para conferir emails válidos e inválidos)
        public string Email { get; set; }


        public override string ToString()
        {
            return $"Primeiro Nome: {PrimeiroNome}\n" +
                   $"Sobrenome: {Sobrenome}\n" +
                   $"CPF: {CPF}\n" +
                   $"Nascimento: {DataNascimento:dd/MM/yyyy}\n" +
                   $"Email: {Email}\n" +
                   $"Telefone: {Telefone}\n" +
                   $"Gênero: {Genero}";
        }


    }
}
