using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.Modelos;

namespace CRUD_cliente_IACO.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnection _connection;

        public ClienteRepository(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        // CREATE - Inserir novo cliente
        public void InserirCliente(Cliente cliente)
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"
                    INSERT INTO CLIENTES 
                        (ID, NOME, EMAIL, TELEFONE, DATA_CADASTRO)
                    VALUES 
                        (SEQ_CLIENTES.NEXTVAL, :nome, :email, :telefone, :dataCadastro)
                    RETURNING ID INTO :id";

                var oracleCommand = (OracleCommand)command;

                oracleCommand.Parameters.Add(":nome", OracleDbType.Varchar2).Value = cliente.Nome;
                oracleCommand.Parameters.Add(":email", OracleDbType.Varchar2).Value = cliente.Email ?? (object)DBNull.Value;
                oracleCommand.Parameters.Add(":telefone", OracleDbType.Varchar2).Value = cliente.Telefone ?? (object)DBNull.Value;
                oracleCommand.Parameters.Add(":dataCadastro", OracleDbType.Date).Value = cliente.DataCadastro;
                
                var idParam = oracleCommand.Parameters.Add(":id", OracleDbType.Int32);
                idParam.Direction = ParameterDirection.Output;

                oracleCommand.ExecuteNonQuery();
                cliente.Id = Convert.ToInt32(idParam.Value.ToString());
            }
        }

        // READ - Consultar todos os clientes
        public List<Cliente> ConsultarClientes()
        {
            var clientes = new List<Cliente>();

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"
                    SELECT 
                        ID,
                        NOME,
                        EMAIL,
                        TELEFONE,
                        DATA_CADASTRO
                    FROM CLIENTES
                    ORDER BY NOME";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Cliente
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Nome = reader["NOME"].ToString(),
                            Email = reader["EMAIL"] != DBNull.Value ? reader["EMAIL"].ToString() : null,
                            Telefone = reader["TELEFONE"] != DBNull.Value ? reader["TELEFONE"].ToString() : null,
                            DataCadastro = Convert.ToDateTime(reader["DATA_CADASTRO"])
                        };

                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }

        // READ - Consultar cliente por ID
        public Cliente ConsultarClientePorId(int id)
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"
                    SELECT 
                        ID,
                        NOME,
                        EMAIL,
                        TELEFONE,
                        DATA_CADASTRO
                    FROM CLIENTES
                    WHERE ID = :id";

                var oracleCommand = (OracleCommand)command;
                oracleCommand.Parameters.Add(":id", OracleDbType.Int32).Value = id;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Cliente
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Nome = reader["NOME"].ToString(),
                            Email = reader["EMAIL"] != DBNull.Value ? reader["EMAIL"].ToString() : null,
                            Telefone = reader["TELEFONE"] != DBNull.Value ? reader["TELEFONE"].ToString() : null,
                            DataCadastro = Convert.ToDateTime(reader["DATA_CADASTRO"])
                        };
                    }
                    return null;
                }
            }
        }

        // UPDATE - Atualizar cliente
        public void AtualizarCliente(Cliente cliente)
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"
                    UPDATE CLIENTES 
                    SET 
                        NOME = :nome,
                        EMAIL = :email,
                        TELEFONE = :telefone
                    WHERE ID = :id";

                var oracleCommand = (OracleCommand)command;
                oracleCommand.Parameters.Add(":nome", OracleDbType.Varchar2).Value = cliente.Nome;
                oracleCommand.Parameters.Add(":email", OracleDbType.Varchar2).Value = cliente.Email ?? (object)DBNull.Value;
                oracleCommand.Parameters.Add(":telefone", OracleDbType.Varchar2).Value = cliente.Telefone ?? (object)DBNull.Value;
                oracleCommand.Parameters.Add(":id", OracleDbType.Int32).Value = cliente.Id;

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception($"Cliente com ID {cliente.Id} não encontrado.");
                }
            }
        }

        // DELETE - Excluir cliente
        public void ExcluirCliente(int id)
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM CLIENTES WHERE ID = :id";
                
                var oracleCommand = (OracleCommand)command;
                oracleCommand.Parameters.Add(":id", OracleDbType.Int32).Value = id;

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception($"Cliente com ID {id} não encontrado.");
                }
            }
        }
    }
} 