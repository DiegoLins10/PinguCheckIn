using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Models.Entidades
{
    public class Pagamento
    {
        [Key]
        public int IdPagamento { get; set; }
        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string Dataexp { get; set; }
        public string Cvv { get; set; }
        public bool Aceito { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Endereco2 { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public int TipoPagamento { get; set; }
        public int IdCliente { get; set; }

        public Pagamento(string nomeCartao, string numeroCartao, string dataexp, string cvv, bool aceito, string nome, string sobrenome, string email, string endereco, string endereco2, string pais, string estado, string cep, int tipoPagamento, int idCliente)
        {
            NomeCartao = nomeCartao;
            NumeroCartao = numeroCartao;
            Dataexp = dataexp;
            Cvv = cvv;
            Aceito = aceito;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Endereco = endereco;
            Endereco2 = endereco2;
            Pais = pais;
            Estado = estado;
            Cep = cep;
            TipoPagamento = tipoPagamento;
            IdCliente = idCliente;
        }
    }
}
