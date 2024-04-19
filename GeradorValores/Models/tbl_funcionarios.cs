using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeradorValores.Models
{
    public class tbl_funcionarios
    {
        [Key]
        public int codigo { get; set; }
        public string nome { get; set; }

        public virtual ICollection<tbl_funcionarios_valor_hora> ValoresHora { get; set; }
    }



}