using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO
{
    public class DatabaseSeeder
    {

        public static void Seed(OracleConnection conn)
        {

            conn.Open();


            string verificacaoClienteQuery = $"SELECT COUNT(*) FROM Clientes";

            using (OracleCommand verificacaoClientesCmd = new OracleCommand(verificacaoClienteQuery, conn))
            {

                int clientesRegistros = Convert.ToInt32(verificacaoClientesCmd.ExecuteScalar());

                if (clientesRegistros == 0)
                {
                    Console.WriteLine($"Nenhum registro encontrado na tabela Clientes.");
                    Console.WriteLine($"Seeding...");

                    string insertCliente = "INSERT INTO CLIENTES (ID_CLIENTE, PRIMEIRO_NOME, SOBRENOME, GENERO, CPF, DATA_NASCIMENTO, TELEFONE, EMAIL) " +
                                   "VALUES (SEQ_CLIENTES.NEXTVAL, 'Administrador', 'iaco', '0', '11323498078', TO_DATE('10/02/1980', 'DD/MM/YYYY'), '67998765424', 'Administrador@iaco.com')";


                    using (OracleCommand inserClientetCmd = new OracleCommand(insertCliente, conn))
                    {
                        
                        try
                        {
                            inserClientetCmd.ExecuteNonQuery();
                            Console.WriteLine("Cliente inserido com sucesso.");
                        }
                        catch (OracleException ex)
                        {
                            Console.WriteLine("Erro ao inserir cliente:");
                            Console.WriteLine(ex.Message);
                        }
                    }

                }

                Console.WriteLine($"Seeder já aplicado à tabela Clientes.");



            }

            conn.Close();

        }
    }
}
