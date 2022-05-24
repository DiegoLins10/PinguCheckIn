using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Models.Dtos
{
    public class AlterarSenhaDto
    {
        public int? IdUsuario { get; set; }
        public string Senha { get; set; }
    }
}
