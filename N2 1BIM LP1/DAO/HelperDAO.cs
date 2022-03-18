using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace N2_1BIM_LP1.DAO
{
    public static class HelperDAO
    {
        public static DataTable ExecutaSQL(string sql, SqlParameter[] parameters)
        {
            using (var conexao = ConexaoBD.GetConexao())
            {
                using (var adapter = new SqlDataAdapter(sql, conexao))
                {
                    if (parameters != null)
                        adapter.SelectCommand.Parameters.AddRange(parameters);
                    DataTable tableTemp = new DataTable();
                    adapter.Fill(tableTemp);
                    conexao.Close();
                    return tableTemp;
                }
            }
        }
    }
}
