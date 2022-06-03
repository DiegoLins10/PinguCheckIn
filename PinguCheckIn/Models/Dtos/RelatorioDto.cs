﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Models.Dtos
{
    public class RelatorioDto
    {
        public int IdReserva { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Quarto { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public int Status { get; set; }
        public string StatusString { get; set; }
        public DateTime DataReserva { get; set; }
        public decimal ValorTotal { get; set; }

    }
}
