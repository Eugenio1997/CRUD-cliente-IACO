using CRUD_clientes_IACO.Modelos;
using System;
using System.Data;
using System.IO;
using System.Data.SQLite;


namespace CRUD_cliente_IACO.Infraestrutura
{
    class DalHelper
    {

        private static SQLiteConnection sqliteConnection;
        //string filePath = @"c:\IACO.sqlite";
        private static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=c:\\dados\\IACO.db;Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void CreateDatabaseSQLite()
        {
            try
            {
                if (!File.Exists(@"c:\dados\IACO.db"))
                {
                    SQLiteConnection.CreateFile(@"c:\dados\IACO.db");
                }

            }
            catch
            {
                throw;
            }
        }


        public static void CreateTableSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = cmd.CommandText = @"
                                                        CREATE TABLE IF NOT EXISTS Clientes (
                                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                            PrimeiroNome Varchar(50),
                                                            Sobrenome Varchar(50),
                                                            CPF Varchar(12),
                                                            DataNascimento Date,
                                                            Telefone Varchar(11),
                                                            Email Varchar(50))
                                                        ";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void InsertToDB(Cliente cliente)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Clientes(PrimeiroNome, Sobrenome, CPF, DataNascimento, Telefone, Email) values (@PrimeiroNome, @Sobrenome, @CPF, @DataNascimento, @Telefone, @Email)";
                    cmd.Parameters.AddWithValue("@PrimeiroNome", cliente.PrimeiroNome);
                    cmd.Parameters.AddWithValue("@Sobrenome", cliente.Sobrenome);
                    cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
                    cmd.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
                    cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                    cmd.Parameters.AddWithValue("@Email", cliente.Email);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetClients()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clientes";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
