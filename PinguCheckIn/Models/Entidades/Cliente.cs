using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Models.Entidades
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public char? Sexo { get; set; }
        public string Nacionalidade { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Complemento { get; set; }
        public long? Numero { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        public Cliente(char? sexo, string nacionalidade, string logradouro, string bairro, string cep, string cidade, string uf, string complemento, int idUsuario)
        {
            Sexo = sexo;
            Nacionalidade = nacionalidade;
            Logradouro = logradouro;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Uf = uf;
            Complemento = complemento;
            IdUsuario = idUsuario;
        }

        public Cliente()
        {
        }
    }
}
