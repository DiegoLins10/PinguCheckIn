using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Models.Entidades
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataReserva { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; }
        public int Status { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("Quarto")]
        public int IdQuarto { get; set; }
        public virtual Quarto Quarto { get; set; }


        public Reserva()
        {
                
        }
    }
}
