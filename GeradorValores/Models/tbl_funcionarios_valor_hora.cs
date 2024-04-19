using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeradorValores.Models
{
    public class tbl_funcionarios_valor_hora
    {
        [Key]
        public int codigo { get; set; }

        public int id_funcionario { get; set; }
        public decimal? valor_hora { get; set; }
        public int? ano { get; set; }
        public int? mes { get; set; }
        public bool? ativo { get; set; }

        [ForeignKey("id_funcionario")]
        public virtual tbl_funcionarios Funcionario { get; set; }
    }



}