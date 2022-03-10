using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Celular { get; set; }
        public bool Funcionario { get; set; }

    }
}
