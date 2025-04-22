using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.Modelos;
using CRUD_cliente_IACO.Enums;
using System.Linq;

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

        // CREATE - Inserir novo cliente
        public void InserirCliente(Cliente cliente)
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            using (var oracleCommand = _connection.CreateCommand())
            using (var transaction = _connection.BeginTransaction()) // para garantir atomicidade
            {
                oracleCommand.Transaction = transaction;

                try
                {
                  
                    // 1. INSERIR CLIENTE
                    oracleCommand.CommandText = @"
                INSERT INTO CLIENTES 
                    (ID_CLIENTE, PRIMEIRO_NOME, SOBRENOME, GENERO, CPF, DATA_NASCIMENTO, TELEFONE, EMAIL)
                VALUES 
                    (SEQ_CLIENTES.NEXTVAL, :primeiroNome, :sobrenome, :genero, :cpf, :dataNascimento, :telefone, :email)
                RETURNING ID_CLIENTE INTO :idCliente";

                    oracleCommand.Parameters.Clear();
                    oracleCommand.Parameters.Add(":primeiroNome", OracleDbType.Varchar2).Value = cliente.PrimeiroNome;
                    oracleCommand.Parameters.Add(":sobrenome", OracleDbType.Varchar2).Value = cliente.Sobrenome;
                    oracleCommand.Parameters.Add(":genero", OracleDbType.Varchar2).Value = (int)cliente.Genero;
                    oracleCommand.Parameters.Add(":cpf", OracleDbType.Varchar2).Value = cliente.CPF;
                    oracleCommand.Parameters.Add(":dataNascimento", OracleDbType.Date).Value =
                        cliente.DataNascimento != DateTime.MinValue ? (object)cliente.DataNascimento : DBNull.Value;
                    oracleCommand.Parameters.Add(":telefone", OracleDbType.Varchar2).Value =
                        string.IsNullOrEmpty(cliente.Telefone) ? (object)DBNull.Value : cliente.Telefone;
                    oracleCommand.Parameters.Add(":email", OracleDbType.Varchar2).Value =
                        string.IsNullOrEmpty(cliente.Email) ? (object)DBNull.Value : cliente.Email;

                    var idClienteParam = oracleCommand.Parameters.Add(":idCliente", OracleDbType.Int32);
                    idClienteParam.Direction = ParameterDirection.Output;

                    oracleCommand.ExecuteNonQuery();
                    cliente.IdCliente = Convert.ToInt32(idClienteParam.Value.ToString());

                    transaction.Commit();
                }
                catch (OracleException ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Erro ao inserir cliente:");
                    Console.WriteLine(ex.Message);
                }
            }
        }


       
        // READ - Consultar todos os clientes
        public List<Cliente> ConsultarClientes()
        {
            var clientes = new List<Cliente>();

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            using (var oracleCommand = _connection.CreateCommand())
            {

                try
                {
                    oracleCommand.CommandText = @"
                    SELECT 
                        c.ID_CLIENTE,
                        c.PRIMEIRO_NOME,
                        c.SOBRENOME,
                        c.GENERO,
                        c.CPF,
                        c.DATA_NASCIMENTO,
                        c.TELEFONE,
                        c.EMAIL
                    FROM CLIENTES c
                    ORDER BY c.PRIMEIRO_NOME, c.SOBRENOME";

                    using (var reader = oracleCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cliente = new Cliente
                            {
                                IdCliente = Convert.ToInt32(reader["ID_CLIENTE"]),
                                PrimeiroNome = reader["PRIMEIRO_NOME"].ToString(),
                                Sobrenome = reader["SOBRENOME"].ToString(),
                                Genero = reader["GENERO"] != DBNull.Value ? (GenerosEnum)Convert.ToInt32(reader["GENERO"]) : GenerosEnum.PrefiroNaoIdentificar,
                                CPF = reader["CPF"].ToString(),
                                Email = reader["EMAIL"] != DBNull.Value ? reader["EMAIL"].ToString() : null,
                                Telefone = reader["TELEFONE"] != DBNull.Value ? reader["TELEFONE"].ToString() : null,
                                DataNascimento = reader["DATA_NASCIMENTO"] != DBNull.Value ? Convert.ToDateTime(reader["DATA_NASCIMENTO"]) : DateTime.MinValue,
                               
                            };

                            clientes.Add(cliente); // Adicionar o cliente à lista dentro do loop
                        }
                    }
                }
                catch( OracleException ex)
                {
                    Console.WriteLine("Erro ao ler clientes");
                    Console.WriteLine(ex.Message);
                }

            }

            return clientes;
        }
        
        /*
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