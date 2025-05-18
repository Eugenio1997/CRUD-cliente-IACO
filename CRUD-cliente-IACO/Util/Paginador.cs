using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO.Util
{


    public class PaginacaoResultado<T>
    {
        public List<T> Registros { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }

    }

    public static class Paginador
    {
        public static PaginacaoResultado<T> ExecutarPaginacao<T>(
            string tabelaOuView,
            string ordenacao,
            int paginaAtual,
            int registrosPorPagina,
            Func<IDataReader, T> mapeador,
            OracleConnection conexao)
        {
            var resultado = new PaginacaoResultado<T>();
            var registros = new List<T>();

            // Query para total de registros
            string queryTotal = $"SELECT COUNT(*) FROM {tabelaOuView}";

            using (var cmdTotal = conexao.CreateCommand())
            {
                cmdTotal.CommandText = queryTotal;
                resultado.TotalRegistros = Convert.ToInt32(cmdTotal.ExecuteScalar());
                resultado.TotalPaginas = (int)Math.Ceiling((double)resultado.TotalRegistros / registrosPorPagina);
            }

            int offset = (paginaAtual - 1) * registrosPorPagina;

            string queryPaginada = $@" 
                SELECT *
                FROM {tabelaOuView}
                ORDER BY {ordenacao} ASC
                OFFSET :offset ROWS
                FETCH NEXT :registrosPorPagina ROWS ONLY
            ";

            using (var cmd = conexao.CreateCommand())
            {
                cmd.CommandText = queryPaginada;

                cmd.Parameters.Add(new OracleParameter("offset", offset));
                cmd.Parameters.Add(new OracleParameter("registrosPorPagina", registrosPorPagina));


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        registros.Add(mapeador(reader));
                    }
                }
            }

            resultado.Registros = registros;
            return resultado;
        }
    }
}
