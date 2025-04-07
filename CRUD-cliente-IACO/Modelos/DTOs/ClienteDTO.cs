using CRUD_cliente_IACO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO.Modelos.DTOs
{
    public sealed class ClienteDTO
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public GenerosEnum Genero { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Método para converter o DTO em um Cliente quando todos os dados estiverem prontos
        public Cliente ToCliente()
        {
            return new Cliente
            {
                PrimeiroNome = this.PrimeiroNome,
                Sobrenome = this.Sobrenome,
                Genero = this.Genero,
                CPF = this.CPF,
                DataNascimento = this.DataNascimento,
                Telefone = this.Telefone,
                Email = this.Email
            };
        }
    }
}
