using System;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using CRUD_cliente_IACO.Enums;
using System.Reflection;
using CRUD_cliente_IACO.AtributosCustomizados;

namespace CRUD_cliente_IACO.Modelos
{
    public class Cliente
    {
        [DisplayNameAttribute("ID")]
        [NotNullValidator(MessageTemplate = "O campo IdCliente é obrigatório.")]
        [RangeValidator(1, RangeBoundaryType.Inclusive, int.MaxValue, RangeBoundaryType.Inclusive, MessageTemplate = "O IdCliente deve ser um número inteiro positivo.")]
        public int IdCliente { get; set; }

        [DisplayNameAttribute("PRIMEIRO NOME")]
        [NotNullValidator(MessageTemplate = "O campo Primeiro Nome é obrigatório.")]
        [StringLengthValidator(3, 50, MessageTemplate = "O Primeiro Nome deve ter entre 3 e 50 caracteres.")]
        [RegexValidator(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{3,50}$", MessageTemplate = "O Nome contém caracteres inválidos.")]
        public string PrimeiroNome { get; set; }

        [DisplayNameAttribute("SOBRENOME")]
        [NotNullValidator(MessageTemplate = "O campo Sobrenome é obrigatório.")]
        [StringLengthValidator(3, 50, MessageTemplate = "O Sobrenome deve ter entre 3 e 50 caracteres.")]
        [RegexValidator(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{3,50}$", MessageTemplate = "O Sobrenome contém caracteres inválidos.")]
        public string Sobrenome { get; set; }

        [DisplayNameAttribute("GÊNERO")]
        [NotNullValidator(MessageTemplate = "O campo Gênero é obrigatório.")]
        public GenerosEnum Genero { get; set; }

        [NotNullValidator(MessageTemplate = "O campo CPF é obrigatório.")]
        [StringLengthValidator(3, 50, MessageTemplate = "O CPF deve ter entre 3 e 50 caracteres.")]
        [RegexValidator(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$", MessageTemplate = "Formato de CPF inválido.")]
        public string CPF { get; set; }

        [DisplayNameAttribute("DATA DE NASCIMENTO")]
        [NotNullValidator(MessageTemplate = "O campo Data de Nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [DisplayNameAttribute("TELEFONE")]
        [NotNullValidator(MessageTemplate = "O campo Telefone é obrigatório.")]
        [RegexValidator(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$", MessageTemplate = "Formato de Telefone inválido.")]
        public string Telefone { get; set; }

        [DisplayNameAttribute("EMAIL")]
        [NotNullValidator(MessageTemplate = "O campo Email é obrigatório.")]
        [StringLengthValidator(3, 50, MessageTemplate = "O Email deve ter entre 3 e 50 caracteres.")]
        [RegexValidator(@"^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,})+$", MessageTemplate = "Formato de Email inválido.")]
        /// https://regex101.com/r/UMgluf/1 (link para conferir emails válidos e inválidos)
        public string Email { get; set; }


        public bool isEqual(Cliente cliente)
        {
            foreach (PropertyInfo prop in cliente.GetType().GetProperties())
            {
                // Pega o valor da propriedade no objeto passado como parâmetro
                object valorCliente = prop.GetValue(cliente, null);

                // Pega o valor da propriedade no objeto atual (this)
                object valorAtual = prop.GetValue(this, null);

                // Se os valores forem diferentes, retorna false
                if ((valorCliente == null && valorAtual != null) ||
                    (valorCliente != null && !valorCliente.Equals(valorAtual)))
                {
                    return false;
                }
            }

            return true; // Todos os valores são iguais
        }
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
