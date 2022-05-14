using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Models.Dtos
{
    public class QuartoDto
    {
        public int IdQuarto { get; set; }
        public string Nome { get; set; }
        public string Tamanho { get; set; }
        public string QtdCamas { get; set; }
        public string[] Beneficios { get; set; }
        public double Valor { get; set; }
        public string Acomoda { get; set; }
        public string Imagem { get; set; }
    }
}
