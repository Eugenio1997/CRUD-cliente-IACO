using CRUD_cliente_IACO.Modelos;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;

namespace CRUD_cliente_IACO.Validadores
{
    public class UsuarioValidador
    {
        private static UsuarioValidador _instance;
        private readonly string _connectionString;

        private UsuarioValidador(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ValidationResults Validar(Cliente usuario)
        {
            // Validação básica usando Enterprise Library
            Validator<Cliente> validator = ValidationFactory.CreateValidator<Cliente>();
            var results = validator.Validate(usuario);

            // Validações adicionais específicas
            ValidarDadosOracle(usuario, results);

            return results;
        }

        private void ValidarDadosOracle(Cliente usuario, ValidationResults results)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();

                    // Verificar se o usuário já existe
                    using (var command = new OracleCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT COUNT(*) FROM CLIENTES WHERE EMAIL = :email AND ID != :id";
                        command.Parameters.Add(":email", OracleDbType.Varchar2).Value = usuario.Email ?? (object)DBNull.Value;
                        command.Parameters.Add(":id", OracleDbType.Int32).Value = usuario.Id;

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        if (count > 0)
                        {
                            results.AddResult(new ValidationResult(
                                "Email já cadastrado para outro usuário",
                                usuario,
                                "Email",
                                "DuplicateEmail",
                                null));
                        }
                    }

                    // Outras validações específicas do Oracle podem ser adicionadas aqui
                }
            }
            catch (OracleException ex)
            {
                results.AddResult(new ValidationResult(
                    $"Erro ao validar dados no Oracle: {ex.Message}",
                    usuario,
                    "Database",
                    "OracleError",
                    null));
            }
        }

        public static UsuarioValidador Instance(string connectionString)
        {
            if (_instance == null)
            {
                _instance = new UsuarioValidador(connectionString);
            }

            return _instance;
        }

        public List<string> ObterMensagensErro(ValidationResults results)
        {
            var mensagens = new List<string>();
            foreach (var result in results)
            {
                mensagens.Add(result.Message);
            }
            return mensagens;
        }
    }
}
