using PinguCheckIn.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Models.Dtos
{
    public class ReservaDto
    {
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int IdQuarto { get; set; }
        public decimal ValorTotal { get; set; }
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
        public int IdUsuario { get; set; }
        public int IdReserva { get; set; }
        public Status Status { get; set; }
        public string StatusString { get; set; }

        public string Camas { get; set; }

        public double Valor { get; set; }
        public string Foto { get; set; }

        public string Error { get; set; }
        public DateTime DataReserva { get; set; }
    }
}
