﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace N2_1BIM_LP1.DAO
{
    public static class ConexaoBD
    {
        /// <summary>
        /// Abre a conexão com o banco de dados
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConexao()
        {
            string strConexao = "Data Source=localhost; database=Banco_LP1_N2_1B; integrated security=true";
            SqlConnection conexao = new SqlConnection(strConexao);
            conexao.Open();
            return conexao;
        }
    }
}
