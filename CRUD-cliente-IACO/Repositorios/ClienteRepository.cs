using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using CRUD_cliente_IACO.Modelos;
using CRUD_cliente_IACO.Enums;
using System.Linq;
using System.Windows.Forms;
using CRUD_cliente_IACO.Extensions;

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

            try
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
                        oracleCommand.Parameters.Add("primeiroNome", OracleDbType.Varchar2).Value = cliente.PrimeiroNome;
                        oracleCommand.Parameters.Add("sobrenome", OracleDbType.Varchar2).Value = cliente.Sobrenome;
                        oracleCommand.Parameters.Add("genero", OracleDbType.Varchar2).Value = (int)cliente.Genero;

                        // Remove a máscara do CPF antes de inserir
                        string cpfSemMascara = new string(cliente.CPF.Where(char.IsDigit).ToArray());
                        oracleCommand.Parameters.Add("cpf", OracleDbType.Varchar2).Value = cpfSemMascara;

                        oracleCommand.Parameters.Add("dataNascimento", OracleDbType.Date).Value =
                            cliente.DataNascimento != DateTime.MinValue ? (object)cliente.DataNascimento : DBNull.Value;
                        oracleCommand.Parameters.Add("telefone", OracleDbType.Varchar2).Value =
                            string.IsNullOrEmpty(cliente.Telefone) ? (object)DBNull.Value : cliente.Telefone;
                        oracleCommand.Parameters.Add("email", OracleDbType.Varchar2).Value =
                            string.IsNullOrEmpty(cliente.Email) ? (object)DBNull.Value : cliente.Email;

                        var idClienteParam = oracleCommand.Parameters.Add("idCliente", OracleDbType.Int32);
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
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
            }
                
        }


       
        // READ - Consultar todos os clientes
        public List<Cliente> ConsultarClientes()
        {

            try
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
                                    Genero = reader["GENERO"] != DBNull.Value ? (GenerosEnum)Convert.ToInt32(reader["GENERO"]) : GenerosEnum.Outros,
                                    CPF = reader["CPF"].ToString(),
                                    Email = reader["EMAIL"] != DBNull.Value ? reader["EMAIL"].ToString() : null,
                                    Telefone = reader["TELEFONE"] != DBNull.Value ? reader["TELEFONE"].ToString() : null,
                                    DataNascimento = reader["DATA_NASCIMENTO"] != DBNull.Value ? Convert.ToDateTime(reader["DATA_NASCIMENTO"]) : DateTime.MinValue,

                                };

                                clientes.Add(cliente); // Adicionar o cliente à lista dentro do loop
                            }
                        }
                    }
                    catch (OracleException ex)
                    {
                        Console.WriteLine("Erro ao ler clientes");
                        Console.WriteLine(ex.Message);
                    }

                }

                return clientes;
            }
            finally
            {
                if(_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
            }
                
        }

        
        // READ - Consultar cliente por ID
        public Cliente ConsultarClientePorId(int IdCliente)
        {
           try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                using (var oracleCommand = _connection.CreateCommand())
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
                        WHERE ID_CLIENTE = :IdCliente";

                    oracleCommand.Parameters.Add("IdCliente", OracleDbType.Int32).Value = IdCliente;

                    using (var reader = oracleCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                IdCliente = Convert.ToInt32(reader["ID_CLIENTE"]),
                                PrimeiroNome = reader["PRIMEIRO_NOME"].ToString(),
                                Sobrenome = reader["SOBRENOME"].ToString(),
                                Genero = reader["GENERO"] != DBNull.Value ? (GenerosEnum)Convert.ToInt32(reader["GENERO"]) : GenerosEnum.Outros,
                                CPF = reader["CPF"].ToString(),
                                Email = reader["EMAIL"] != DBNull.Value ? reader["EMAIL"].ToString() : null,
                                Telefone = reader["TELEFONE"] != DBNull.Value ? reader["TELEFONE"].ToString() : null,
                                DataNascimento = reader["DATA_NASCIMENTO"] != DBNull.Value ? Convert.ToDateTime(reader["DATA_NASCIMENTO"]) : DateTime.MinValue,
                            };
                        }
                        return null;
                    }
                }
            }
            finally
            {
                if(_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
            }
                
        }
       
        // UPDATE - Atualizar cliente
        public void AtualizarCliente(Cliente cliente)
        {

            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                using (var oracleCommand = _connection.CreateCommand())
                using (var transaction = _connection.BeginTransaction())
                {

                    try
                    {
                        
                        oracleCommand.CommandText = @"
                        UPDATE CLIENTES 
                        SET 
                            PRIMEIRO_NOME = :primeiroNome,
                            SOBRENOME = :sobrenome,
                            GENERO = :genero,
                            CPF = :cpf,
                            DATA_NASCIMENTO = :dataNascimento,
                            TELEFONE = :telefone,
                            EMAIL = :email
                        WHERE ID_CLIENTE = :idCliente";


                        oracleCommand.Parameters.Add("primeiroNome", OracleDbType.Varchar2).Value = cliente.PrimeiroNome;
                        oracleCommand.Parameters.Add("sobrenome", OracleDbType.Varchar2).Value = cliente.Sobrenome;
                        oracleCommand.Parameters.Add("genero", OracleDbType.Varchar2).Value = cliente.Genero.ParaChar();
                        oracleCommand.Parameters.Add("cpf", OracleDbType.Varchar2).Value = cliente.CPF ?? (object)DBNull.Value;
                        oracleCommand.Parameters.Add("dataNascimento", OracleDbType.Date).Value =
                            cliente.DataNascimento != DateTime.MinValue ? (object)cliente.DataNascimento : DBNull.Value;
                        oracleCommand.Parameters.Add("telefone", OracleDbType.Varchar2).Value = cliente.Telefone ?? (object)DBNull.Value;
                        oracleCommand.Parameters.Add("email", OracleDbType.Varchar2).Value = cliente.Email ?? (object)DBNull.Value;
                        oracleCommand.Parameters.Add("idCliente", OracleDbType.Int32).Value = cliente.IdCliente;


                        var confirmar = MessageBox.Show("Tem certeza que deseja atualizar os dados do cliente?", "Editar Cliente", MessageBoxButtons.YesNo);
                        if (confirmar == DialogResult.Yes)
                        {
                            oracleCommand.ExecuteNonQuery();
                            transaction.Commit();
                            MessageBox.Show("Os dados do cliente foram atualizados com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }


                    }
                    catch (OracleException ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Erro ao atualizar cliente:");
                        Console.WriteLine(ex.Message);
                    }

                }

            }
            finally
            {
                if(_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
            }
                

        }
        
        // DELETE - Excluir cliente
        public void ExcluirCliente(int idCliente)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                using (var transaction = _connection.BeginTransaction())
                using (var oracleCommand = _connection.CreateCommand())
                {
                    oracleCommand.CommandText = @"
                        UPDATE CLIENTES 
                        SET 
                            PRIMEIRO_NOME = :primeiroNome,
                            SOBRENOME = :sobrenome,
                            GENERO = :genero,
                            CPF = :cpf,
                            DATA_NASCIMENTO = :dataNascimento,
                            TELEFONE = :telefone,
                            EMAIL = :email
                        WHERE ID_CLIENTE = :idCliente";



                    oracleCommand.Transaction = transaction;
                    oracleCommand.CommandText = @"
                        DELETE FROM CLIENTES 
                        WHERE ID_CLIENTE = :idCliente";

                    oracleCommand.Parameters.Add("idCliente", OracleDbType.Int32).Value = idCliente;

                    Console.WriteLine($"Tentando excluir cliente com ID: {idCliente}");


                    int rowsAffected = oracleCommand.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        transaction.Rollback();
                        throw new Exception($"Cliente com ID {idCliente} não encontrado.");
                    }

                    transaction.Commit();
                    MessageBox.Show("O cliente foi excluido com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            finally
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Close();
            }
                
        }

        public List<Cliente> BuscarClientesPorNome(string nome)
        {
            var lista = new List<Cliente>();

            try
            {
                
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                using (var oracleCommand = _connection.CreateCommand())
                {
                    oracleCommand.CommandText = @"
                        SELECT * 
                        FROM Clientes c 
                        WHERE 
                            LOWER(c.PRIMEIRO_NOME) LIKE :nome";


                    oracleCommand.Parameters.Add(new OracleParameter("nome", OracleDbType.Varchar2)).Value = "%" + nome.ToLowerInvariant() + "%";



                    try
                    {
                        using (var reader = oracleCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine((GenerosEnum)Convert.ToInt32(reader["GENERO"]));

                                lista.Add(new Cliente
                                {
                                    IdCliente = Convert.ToInt32(reader["ID_CLIENTE"]),
                                    PrimeiroNome = reader["PRIMEIRO_NOME"].ToString(),
                                    Sobrenome = reader["SOBRENOME"].ToString(),
                                    Genero = reader["GENERO"] != DBNull.Value ? (GenerosEnum)Convert.ToInt32(reader["GENERO"]) : GenerosEnum.Outros,
                                    CPF = reader["CPF"].ToString(),
                                    Email = reader["EMAIL"] != DBNull.Value ? reader["EMAIL"].ToString() : null,
                                    Telefone = reader["TELEFONE"] != DBNull.Value ? reader["TELEFONE"].ToString() : null,
                                    DataNascimento = reader["DATA_NASCIMENTO"] != DBNull.Value ? Convert.ToDateTime(reader["DATA_NASCIMENTO"]) : DateTime.MinValue,

                                });



                                    

                            }
                        }
                    }
                    catch (OracleException ex)
                    {
                        Console.WriteLine("O erro: " + ex.Message);
                    }

                }

                
            }
            catch(OracleException ex)
            {
                Console.WriteLine("O erro: " + ex.Message);
            }
            finally
            {
                if(_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
            }
            return lista;
        }

        public bool VerificarClienteExistePorCPF(string cpf)
        {

            int clienteExiste = 0;
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();


                using (var oracleCommand = _connection.CreateCommand())
                {
                    oracleCommand.CommandText = @"
                        SELECT COUNT(*)
                        FROM Clientes c
                        WHERE c.CPF = :cpf
                    ";

                    //oracleCommand.Parameters.Add("cpf", OracleDbType.Varchar2).Value = cpf;
                    oracleCommand.Parameters.Add(new OracleParameter("cpf", cpf));
                    try
                    {
                        clienteExiste = Convert.ToInt32(oracleCommand.ExecuteScalar());
                    }
                    catch (OracleException ex)
                    {
                        Console.WriteLine("O erro: " + ex.Message);
                    }
                    
                }

            }
            catch (OracleException ex)
            {
                Console.WriteLine("O erro: " + ex.Message);
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
            }

            return clienteExiste > 0;

        }

        public List<Cliente> BuscarClientesPorGenero(string generoId)
        {
            var lista = new List<Cliente>();

            try
            {

                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                using (var oracleCommand = _connection.CreateCommand())
                {
                    oracleCommand.CommandText = @"
                        SELECT * 
                        FROM Clientes c
                        WHERE c.GENERO = :generoId";


                    oracleCommand.Parameters.Add(new OracleParameter("generoId", OracleDbType.Varchar2)).Value = generoId;



                    try
                    {
                        using (var reader = oracleCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("GENERO: " + (GenerosEnum)Convert.ToInt32(reader["GENERO"]));

                                GenerosEnum genero = Convert.ToString(reader["GENERO"]).ParaGenerosEnum();

                                lista.Add(new Cliente
                                {
                                    IdCliente = Convert.ToInt32(reader["ID_CLIENTE"]),
                                    PrimeiroNome = reader["PRIMEIRO_NOME"].ToString(),
                                    Sobrenome = reader["SOBRENOME"].ToString(),
                                    Genero = reader["GENERO"] != DBNull.Value ? genero : GenerosEnum.Outros,
                                    CPF = reader["CPF"].ToString(),
                                    Email = reader["EMAIL"] != DBNull.Value ? reader["EMAIL"].ToString() : null,
                                    Telefone = reader["TELEFONE"] != DBNull.Value ? reader["TELEFONE"].ToString() : null,
                                    DataNascimento = reader["DATA_NASCIMENTO"] != DBNull.Value ? Convert.ToDateTime(reader["DATA_NASCIMENTO"]) : DateTime.MinValue,

                                });

                            }
                        }
                    }
                    catch (OracleException ex)
                    {
                        Console.WriteLine("O erro: " + ex.Message);
                    }

                }


            }
            catch (OracleException ex)
            {
                Console.WriteLine("O erro: " + ex.Message);
            }
            finally
            {
                
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                
            }
            return lista;
        }

    }

};
