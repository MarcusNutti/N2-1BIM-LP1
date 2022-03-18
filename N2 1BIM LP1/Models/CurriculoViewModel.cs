using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N2_1BIM_LP1.Models
{
    /// <summary>
    /// Representação dos campos do CV, está idêntica à representação no banco
    /// </summary>
    public class CurriculoViewModel
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public float PretensaoSalarial {get;set;}
        public string CargoPretendido { get; set; }
        public string FormacaoAcademica1 { get; set; }
        public string FormacaoAcademica2 { get; set; }
        public string FormacaoAcademica3 { get; set; }
        public string FormacaoAcademica4 { get; set; }
        public string FormacaoAcademica5 { get; set; }
        public string Experiencia1 { get; set; }
        public string Experiencia2 { get; set; }
        public string Experiencia3 { get; set; }
        public string Idiomas { get; set; }


    }
}
