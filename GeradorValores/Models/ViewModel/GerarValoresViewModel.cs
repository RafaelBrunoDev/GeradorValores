using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeradorValores.Models.ViewModel
{
    public class GerarValoresViewModel
    {
        public tbl_funcionarios Funcionario { get; set; }
        public List<tbl_funcionarios_valor_hora> Valores { get; set; }
    }

}