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

            //query para verificar se a tabela esta vazia ou populada
            string verificacaoEnderecosQuery = $"SELECT COUNT(*) FROM Enderecos";


            using (OracleCommand verificacaoEnderecosCmd = new OracleCommand(verificacaoEnderecosQuery, conn))
            {


                int enderecosRegistros = Convert.ToInt32(verificacaoEnderecosCmd.ExecuteScalar());

                if (enderecosRegistros == 0)
                {
                    Console.WriteLine($"Nenhum registro encontrado na tabela Enderecos.");
                    Console.WriteLine($"Seeding...");

                    //making an insert to clientes and endereco tables
                    string insertEndereco = $"INSERT INTO ENDERECOS (ID_ENDERECO, CEP, RUA, NUMERO_RESIDENCIA, BAIRRO, CIDADE, ESTADO) " +
                                                        $"VALUES (SEQ_ENDERECOS.NEXTVAL, '57048564', 'Rua numero 90', '800', 'Serraria', 'Maceio', 'AL')";


                    OracleCommand insertEnderecoCmd = new OracleCommand(insertEndereco, conn);

                    try
                    {
                        insertEnderecoCmd.ExecuteNonQuery();
                        Console.WriteLine("Endereço inserido com sucesso.");
                    }
                    catch (OracleException ex)
                    {
                        Console.WriteLine("Erro ao inserir endereço:");
                        Console.WriteLine(ex.Message);
                    }

                }

                Console.WriteLine($"Seeder já aplicado à tabela Enderecos.");

            }


            // Recupera um ID_ENDERECO existente
            int idEnderecoExistente = 1;
            using (OracleCommand cmd = new OracleCommand("SELECT ID_ENDERECO FROM ENDERECOS WHERE ROWNUM = 1", conn))
            {
                idEnderecoExistente = Convert.ToInt32(cmd.ExecuteScalar());
            }



            string verificacaoClienteQuery = $"SELECT COUNT(*) FROM Clientes";

            using (OracleCommand verificacaoClientesCmd = new OracleCommand(verificacaoClienteQuery, conn))
            {

                int clientesRegistros = Convert.ToInt32(verificacaoClientesCmd.ExecuteScalar());

                if (clientesRegistros == 0)
                {
                    Console.WriteLine($"Nenhum registro encontrado na tabela Clientes.");
                    Console.WriteLine($"Seeding...");

                    string insertCliente = "INSERT INTO CLIENTES (ID_CLIENTE, ID_ENDERECO, PRIMEIRO_NOME, SOBRENOME, GENERO, CPF, DATA_NASCIMENTO, TELEFONE, EMAIL) " +
                                   "VALUES (SEQ_CLIENTES.NEXTVAL, :idEndereco, 'Administrador', 'iaco', '0', '11323498078', TO_DATE('10/02/1980', 'DD/MM/YYYY'), '67998765424', 'Administrador@iaco.com')";


                    using (OracleCommand inserClientetCmd = new OracleCommand(insertCliente, conn))
                    {
                        inserClientetCmd.Parameters.Add(new OracleParameter("idEndereco", idEnderecoExistente));

                        try
                        {
                            inserClientetCmd.ExecuteNonQuery();
                            Console.WriteLine("Endereço inserido com sucesso.");
                        }
                        catch (OracleException ex)
                        {
                            Console.WriteLine("Erro ao inserir endereço:");
                            Console.WriteLine(ex.Message);
                        }
                    }

                    Console.WriteLine("Cliente inserido com sucesso.");

                }

                Console.WriteLine($"Seeder já aplicado à tabela Clientes.");



            }

            conn.Close();

        }
    }
}
