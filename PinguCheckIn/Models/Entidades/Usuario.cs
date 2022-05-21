using PinguCheckIn.Models.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        [MaxLength(11)]
        public string Cpf { get; set; }
        [MaxLength(20)]
        public string Rg { get; set; }
        [MaxLength(11)]
        public string Celular { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Funcionario { get; set; }

        public Usuario(string email, string senha, string nome, string sobrenome, string cpf, string rg, string celular, DateTime dataNascimento, bool funcionario)
        {
            Email = email;
            Senha = senha;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Rg = rg;
            Celular = celular;
            DataNascimento = dataNascimento;
            Funcionario = funcionario;
        }
    }

}
