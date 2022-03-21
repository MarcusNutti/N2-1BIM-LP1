using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using N2_1BIM_LP1.Models;
using System.Data;

namespace N2_1BIM_LP1.DAO
{
    public class CurriculoDAO
    {
        private SqlParameter[] CriaParametros(CurriculoViewModel cv)
        {
            SqlParameter[] parametros = new SqlParameter[16];
            parametros[0] = new SqlParameter("cpf", cv.Cpf);
            parametros[1] = new SqlParameter("nome", cv.Nome);
            parametros[2] = new SqlParameter("endereco", cv.Endereco);
            parametros[3] = new SqlParameter("telefone", cv.Telefone);
            parametros[4] = new SqlParameter("email", cv.Email);
            parametros[5] = new SqlParameter("pretensaoSalarial", cv.PretensaoSalarial);
            parametros[6] = new SqlParameter("cargoPretendido", cv.CargoPretendido);
            parametros[7] = new SqlParameter("formacaoAcademica1", cv.FormacaoAcademica1);
            parametros[8] = new SqlParameter("formacaoAcademica2", cv.FormacaoAcademica2);
            parametros[9] = new SqlParameter("formacaoAcademica3", cv.FormacaoAcademica3);
            parametros[10] = new SqlParameter("formacaoAcademica4", cv.FormacaoAcademica4);
            parametros[11] = new SqlParameter("formacaoAcademica5", cv.FormacaoAcademica5);
            parametros[12] = new SqlParameter("experiencia1", cv.Experiencia1);
            parametros[13] = new SqlParameter("experiencia2", cv.Experiencia2);
            parametros[14] = new SqlParameter("experiencia3", cv.Experiencia3);
            parametros[15] = new SqlParameter("idiomas", cv.Idiomas);

            SubstituiNULL(ref parametros);

            return parametros;
        }

        public void Inserir(CurriculoViewModel cv)
        {
            string sql = "insert into curriculos" +
                         "(cpf, nome, endereco, telefone, email, pretensaoSalarial, cargoPretentido, " +
                         "formacaoAcademica1, formacaoAcademica2, formacaoAcademica3, formacaoAcademica4, formacaoAcademica5," +
                         "experiencia1, experiencia2, experiencia3, idiomas) " +
                         "values " +
                         "(@cpf, @nome, @endereco, @telefone, @email, @pretensaoSalarial, @cargoPretendido, " +
                         "@formacaoAcademica1, @formacaoAcademica2, @formacaoAcademica3, @formacaoAcademica4, @formacaoAcademica5," +
                         "@experiencia1, @experiencia2, @experiencia3, @idiomas) ";
            HelperDAO.ExecutaSQL(sql, CriaParametros(cv));
        }

        public void Alterar(CurriculoViewModel cv)
        {
            string sql = "update curriculos set " +
                            "cpf = @cpf ," +
                            "nome = @nome, " +
                            "telefone = @telefone, " +
                            "email = @email, " +
                            "pretensaoSalarial = @pretensaoSalarial, " +
                            "cargoPretentido = @cargoPretendido, " +
                            "formacaoAcademica1 = @formacaoAcademica1, " +
                            "formacaoAcademica2 = @formacaoAcademica2, " +
                            "formacaoAcademica3 = @formacaoAcademica3, " +
                            "formacaoAcademica4 = @formacaoAcademica4, " +
                            "formacaoAcademica5 = @formacaoAcademica5, " +
                            "experiencia1 = @experiencia1, " +
                            "experiencia2 = @experiencia2, " +
                            "experiencia3 = @experiencia3, " +
                            "idiomas = @idiomas";
            HelperDAO.ExecutaSQL(sql, CriaParametros(cv));
        }

        public void Excluir(string cpf)
        {
            string sql = "delete curriculos where cpf =" + cpf;
            HelperDAO.ExecutaSQL(sql, null);
        }

        public CurriculoViewModel Consultar(string cpf)
        {
            using (SqlConnection cx = ConexaoBD.GetConexao())
            {
                string sql = "select * from curriculos where cpf = " + cpf;
                DataTable tabela = HelperDAO.ExecutaSQL(sql, null);
                if (tabela.Rows.Count == 0)
                    return null;
                else
                    return MontaModel(tabela.Rows[0]);
            }
        }

        public static CurriculoViewModel MontaModel(DataRow registro)
        {
            CurriculoViewModel cv = new CurriculoViewModel();
            cv.Cpf = Convert.ToString(registro["cpf"]);
            cv.Nome = Convert.ToString(registro["nome"]);
            cv.Endereco = Convert.ToString(registro["endereco"]);
            cv.Telefone = Convert.ToString(registro["telefone"]);
            cv.Email = Convert.ToString(registro["email"]);
            cv.PretensaoSalarial = Convert.ToSingle(registro["pretensaoSalarial"]);
            cv.CargoPretendido = Convert.ToString(registro["cargoPretentido"]); /* pus errado aqui, pois é assim que está no banco, para consertar despois devemos primeiro mudar o banco */
            cv.FormacaoAcademica1 = Convert.ToString(registro["formacaoAcademica1"]);
            cv.FormacaoAcademica2 = Convert.ToString(registro["formacaoAcademica2"]);
            cv.FormacaoAcademica3 = Convert.ToString(registro["formacaoAcademica3"]);
            cv.FormacaoAcademica4 = Convert.ToString(registro["formacaoAcademica4"]);
            cv.FormacaoAcademica5 = Convert.ToString(registro["formacaoAcademica5"]);
            cv.Experiencia1 = Convert.ToString(registro["experiencia1"]);
            cv.Experiencia2 = Convert.ToString(registro["experiencia2"]);
            cv.Experiencia3 = Convert.ToString(registro["experiencia3"]);
            cv.Idiomas = Convert.ToString(registro["idiomas"]);

            return cv;
        }

        public List<CurriculoViewModel> ListaCurriculos()
        {
            using (var cx = ConexaoBD.GetConexao())
            {
                List<CurriculoViewModel> lista_de_curriculos = new List<CurriculoViewModel>();
                string sql = "select * from curriculos";
                DataTable tabela = HelperDAO.ExecutaSQL(sql, null);
                if (tabela.Rows.Count == 0)
                    return null;
                else
                {
                    for (int i = 0; i < tabela.Rows.Count; i++)
                        lista_de_curriculos.Add(MontaModel(tabela.Rows[i]));
                }
                return lista_de_curriculos;
            }
        }

        /// <summary>
        /// Esta função substitui todos os campos que porventura estejam como NULL por uma String.Empty,
        /// para não dar erro na inserção no banco.
        /// </summary>
        /// <param name="sqlParameters"></param>
        private void SubstituiNULL (ref SqlParameter[] sqlParameters)
        {
            for (int i = 0; i < sqlParameters.Length; i++)
                if (sqlParameters[i].Value == null)
                    sqlParameters[i].Value = String.Empty;
        }
    }
}
