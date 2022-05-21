using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Models.Dtos
{
    public class FiltroQuarto
    {
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }

        public int IdQuarto { get; set; }
    }
}
