using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Models.Entidades
{
    public class Quarto
    {
        [Key]
        public int IdQuarto { get; set; }
        public string Nome { get; set; }
        public string Tamanho { get; set; }
        public string QtdCamas { get; set; }
        public string Beneficios { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double Valor { get; set; }
        public string Acomoda { get; set; }
        public string Imagem { get; set; }

        public Quarto(string nome, string tamanho, string qtdCamas, string beneficios, double valor, string acomoda, string imagem)
        {
            Nome = nome;
            Tamanho = tamanho;
            QtdCamas = qtdCamas;
            Beneficios = beneficios;
            Valor = valor;
            Acomoda = acomoda;
            Imagem = imagem;
        }

        public Quarto()
        {
        }
    }
}
