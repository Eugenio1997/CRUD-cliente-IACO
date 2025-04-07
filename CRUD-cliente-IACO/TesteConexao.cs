using System;
using Oracle.DataAccess.Client;
using System.Configuration;

namespace CRUD_cliente_IACO
{
    public class TesteConexao
    {
        private readonly string _connectionString;

        public TesteConexao()
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["OracleConnection"];
                if (connectionString == null)
                {
                    throw new ConfigurationErrorsException("String de conexão 'OracleConnection' não encontrada na seção connectionStrings.");
                }

                _connectionString = connectionString.ConnectionString;
                Console.WriteLine($"String de conexão lida com sucesso: {_connectionString}");
            }
            catch (ConfigurationErrorsException ex)
            {
                Console.WriteLine($"Erro de configuração: {ex.Message}");
                Console.WriteLine($"Arquivo de configuração com problema: {ex.Filename}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler string de conexão: {ex.Message}");
                Console.WriteLine($"Tipo do erro: {ex.GetType().FullName}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Erro interno: {ex.InnerException.Message}");
                }
                throw;
            }
        }

        public bool TestarConexao()
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    Console.WriteLine("Tentando abrir conexão...");
                    connection.Open();
                    Console.WriteLine("Conexão estabelecida com sucesso!");
                    
                    Console.WriteLine("\nInformações da conexão:");
                    Console.WriteLine($"Versão do servidor: {connection.ServerVersion}");
                    Console.WriteLine($"Estado da conexão: {connection.State}");
                    Console.WriteLine($"Service Name: {connection.ServiceName}");
                    
                    using (var command = new OracleCommand("SELECT INSTANCE_NAME, VERSION, STATUS FROM V$INSTANCE", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine($"\nDetalhes da instância:");
                                Console.WriteLine($"Nome da instância: {reader.GetString(0)}");
                                Console.WriteLine($"Versão: {reader.GetString(1)}");
                                Console.WriteLine($"Status: {reader.GetString(2)}");
                            }
                        }
                    }

                    return true;
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"\nErro Oracle #{ex.Number}:");
                Console.WriteLine($"Mensagem: {ex.Message}");
                Console.WriteLine($"Source: {ex.Source}");
                Console.WriteLine($"Data Provider: {ex.DataSource}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Erro interno: {ex.InnerException.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro geral:");
                Console.WriteLine($"Tipo: {ex.GetType().Name}");
                Console.WriteLine($"Mensagem: {ex.Message}");
                Console.WriteLine($"Source: {ex.Source}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Erro interno: {ex.InnerException.Message}");
                return false;
            }
        }

        public void MostrarVersaoBanco()
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new OracleCommand("SELECT * FROM V$VERSION", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"Versão do Oracle: {reader.GetString(0)}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter versão: {ex.Message}");
            }
        }
    }
} 