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
        private readonly OracleConnection _connection;

        public ClienteRepository(OracleConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));
            
            _connection = connection;
        }

        public ClienteRepository()
        {

        }

        // CREATE - Inserir novo cliente
        public void InserirCliente(Cliente cliente)
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            using (var oracleCommand = _connection.CreateCommand())
            {
                oracleCommand.CommandText = @"
                    INSERT INTO CLIENTES 
                        (ID, PRIMEIRO_NOME, SOBRENOME, EMAIL, TELEFONE, DATA_NASCIMENTO, CEP, RUA, NUMERO_RESIDENCIA, BAIRRO, CIDADE, ESTADO )
                    VALUES 
                        (SEQ_CLIENTES.NEXTVAL, :primeiroNome, :sobrenome, :email, :telefone, :dataNascimento, :cep, :rua, :numeroResidencia, :bairro, :cidade, :estado)
                    RETURNING ID INTO :id";


                //TELA DE CADASTRO DE DADOS PESSOAIS DO CLIENTE (1º TELA)

                oracleCommand.Parameters.Add(":primeiroNome", OracleDbType.Varchar2).Value = cliente.PrimeiroNome;
                oracleCommand.Parameters.Add(":sobrenome", OracleDbType.Varchar2).Value = cliente.Sobrenome;
                oracleCommand.Parameters.Add(":email", OracleDbType.Varchar2).Value = cliente.Email ?? (object)DBNull.Value;
                oracleCommand.Parameters.Add(":telefone", OracleDbType.Varchar2).Value = cliente.Telefone ?? (object)DBNull.Value;
                oracleCommand.Parameters.Add(":dataNascimento", OracleDbType.Date).Value = cliente.DataNascimento != DateTime.MinValue ? (object)cliente.DataNascimento : DBNull.Value;

                //TELA DE CADASTRO DE ENDEREÇO DO CLIENTE (2º TELA)

                oracleCommand.Parameters.Add(":cep", OracleDbType.Varchar2).Value = cliente.Endereco.CEP;
                oracleCommand.Parameters.Add(":rua", OracleDbType.Varchar2).Value = cliente.Endereco.Rua;
                oracleCommand.Parameters.Add(":numeroResidencia", OracleDbType.Varchar2).Value = cliente.Endereco.NumeroResidencia;
                oracleCommand.Parameters.Add(":bairro", OracleDbType.Varchar2).Value = cliente.Endereco.Bairro;
                oracleCommand.Parameters.Add(":cidade", OracleDbType.Date).Value = cliente.Endereco.Cidade;
                oracleCommand.Parameters.Add(":estado", OracleDbType.Date).Value = cliente.Endereco.Estado;



                /*
                Define que este é um parâmetro de saída (OUTPUT)
                ParameterDirection.Output indica que o valor virá do banco de dados para o programa
                Isso é necessário porque estamos usando RETURNING ID INTO :id na query
                */
                var idParam = oracleCommand.Parameters.Add(":id", OracleDbType.Int32);
                idParam.Direction = ParameterDirection.Output;


                oracleCommand.ExecuteNonQuery();
                cliente.Id = Convert.ToInt32(idParam.Value.ToString());
            }
        }

        /*
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
                        PRIMEIRO_NOME,
                        SOBRENOME,
                        EMAIL,
                        TELEFONE,
                        DATA_NASCIMENTO
                    FROM CLIENTES
                    ORDER BY PRIMEIRO_NOME, SOBRENOME";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Cliente
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            PrimeiroNome = reader["PRIMEIRO_NOME"].ToString(),
                            Sobrenome = reader["SOBRENOME"].ToString(),
                            Email = reader["EMAIL"] != DBNull.Value ? reader["EMAIL"].ToString() : null,
                            Telefone = reader["TELEFONE"] != DBNull.Value ? reader["TELEFONE"].ToString() : null,
                            DataNascimento = Convert.ToDateTime(reader["DATA_NASCIMENTO"])
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

            using (var oracleCommand = _connection.CreateCommand())
            {
                oracleCommand.CommandText = @"
                    SELECT 
                        ID,
                        PRIMEIRO_NOME,
                        SOBRENOME,
                        EMAIL,
                        TELEFONE,
                        DATA_NASCIMENTO
                    FROM CLIENTES
                    WHERE ID = :id";

                oracleCommand.Parameters.Add(":id", OracleDbType.Int32).Value = id;

                using (var reader = oracleCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Cliente
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            PrimeiroNome = reader["PRIMEIRO_NOME"].ToString(),
                            Sobrenome = reader["SOBRENOME"].ToString(),
                            Email = reader["EMAIL"] != DBNull.Value ? reader["EMAIL"].ToString() : null,
                            Telefone = reader["TELEFONE"] != DBNull.Value ? reader["TELEFONE"].ToString() : null,
                            DataNascimento = reader["DATA_NASCIMENTO"] != DBNull.Value ? Convert.ToDateTime(reader["DATA_NASCIMENTO"]) : DateTime.MinValue
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

            using (var oracleCommand = _connection.CreateCommand())
            {
                oracleCommand.CommandText = @"
                    UPDATE CLIENTES 
                    SET 
                        PRIMEIRO_NOME = :primeiroNome,
                        SOBRENOME = :sobrenome,
                        EMAIL = :email,
                        TELEFONE = :telefone
                    WHERE ID = :id";

              
                oracleCommand.Parameters.Add(":primeiroNome", OracleDbType.Varchar2).Value = cliente.PrimeiroNome;
                oracleCommand.Parameters.Add(":sobrenome", OracleDbType.Varchar2).Value = cliente.Sobrenome;
                oracleCommand.Parameters.Add(":email", OracleDbType.Varchar2).Value = cliente.Email ?? (object)DBNull.Value;
                oracleCommand.Parameters.Add(":telefone", OracleDbType.Varchar2).Value = cliente.Telefone ?? (object)DBNull.Value;
                oracleCommand.Parameters.Add(":id", OracleDbType.Int32).Value = cliente.Id;

                int rowsAffected = oracleCommand.ExecuteNonQuery();
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

            using (var oracleCommand = _connection.CreateCommand())
            {
                oracleCommand.CommandText = "DELETE FROM CLIENTES WHERE ID = :id";
                
                oracleCommand.Parameters.Add(":id", OracleDbType.Int32).Value = id;

                int rowsAffected = oracleCommand.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception($"Cliente com ID {id} não encontrado.");
                }
            }
        }
        */
    }
} 