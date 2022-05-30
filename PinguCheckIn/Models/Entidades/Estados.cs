using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Models.Entidades
{
    public class Estados
    {
        [Key]
        public int IdEstado { get; set; }
        public string Nome { get; set; }
        [MaxLength(2)]
        public string UF { get; set; }

        public Estados(string nome, string uF)
        {
            Nome = nome;
            UF = uF;
        }
    }
}
