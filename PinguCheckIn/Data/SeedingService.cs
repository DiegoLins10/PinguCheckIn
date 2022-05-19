using PinguCheckIn.Models;
using PinguCheckIn.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Data
{
    public class SeedingService
    {
        private PinguCheckInContext _context;

        public SeedingService(PinguCheckInContext context)
        {
            _context = context;
        }

        public void Seed()
        {

            if (!_context.Usuario.Any())
            {
                Usuario us1 = new Usuario("diego.lins@fatec.sp.gov.br", "teste10", "Diego", "Fernandes Lins", "24053232813", "180037808", "11987549239", DateTime.Now, true);
                Usuario us2 = new Usuario("Vinicius.Oliveira@fatec.sp.gov.br", "teste10", "Vinicius", " Oliveira", "24033332813", "180337808", "1166667779", DateTime.Now, true);
                Usuario us3 = new Usuario("Nathan@fatec.sp.gov.br", "teste10", "Nathan", "Silva", "24444232813", "180222808", "11966669239", DateTime.Now, true);
                _context.Usuario.AddRange(us1, us2, us3);
            }
            if (!_context.Quarto.Any())
            {
                Quarto q1 = new Quarto("Quarto, 1 cama King (Bridge View)", "41 m²", "1 cama King", "Wi-Fi grátis", 1247.00, "Acomoda 3", "/assets/imagens-quartos/quarta cama King 1.png");
                Quarto q2 = new Quarto("Quarto, 2 camas de solteiro", "41 m²", "2 camas de solteiro", "Wi-Fi grátis", 1147.00, "Acomoda 3", "/assets/imagens-quartos/quarto cama 2 solteiros.png");
                Quarto q3 = new Quarto("Quarto, 1 cama Queen", "41 m²", "1 cama Queen", "Wi-Fi grátis", 1100.00, "Acomoda 2", "/assets/imagens-quartos/Quarto 1 cama queen.png");
                Quarto q4 = new Quarto("Apartamento, 3 quartos, Sacada", "102 m²", "3 camas de casal", "Wi-Fi grátis;Café da manhã incluído", 1720.00, "Acomoda 5", "/assets/imagens-quartos/apartamento, 3 quartos, sacada.png");
                Quarto q5 = new Quarto("Apartamento, 1 cama Queen, Sacada", "42 m²", "1 cama Queen", "Wi-Fi grátis;Café da manhã incluído", 414.00, "Acomoda 2", "/assets/imagens-quartos/apartamento, 1 cama queen, sacada.png");
                Quarto q6 = new Quarto("Quarto standard, 1 cama King", "22 m²", "1 cama King", "Wi-Fi grátis", 407.00, "Acomoda 2", "/assets/imagens-quartos/quarto standard, 1 cama king.png");
                Quarto q7 = new Quarto("Standard Room Twin", "22 m²", "2 camas de solteiro", "Wi-Fi grátis;Buffet de café da manhã", 331.00, "Acomoda 2", "/assets/imagens-quartos/standard room twin.png");
                Quarto q8 = new Quarto("Standard Room Queen", "22 m²", "1 cama Queen", "Wi-Fi grátis;Buffet de café da manhã", 361.00, "Acomoda 2", "/assets/imagens-quartos/stand room queen.png");
                Quarto q9 = new Quarto("Premium Room Queen", "22 m²", "1 cama Queen", "Wi-Fi grátis;Buffet de café da manhã", 436.00, "Acomoda 2", "/assets/imagens-quartos/premium room queen.png");

                _context.Quarto.AddRange(q1, q2, q3, q4, q5, q6, q7, q8, q9);
            }
            if (!_context.Cliente.Any())
            {
                Cliente c1 = new Cliente(null, null, null, null, null, null, null, null, 1);
                Cliente c2 = new Cliente(null, null, null, null, null, null, null, null, 2);
                Cliente c3 = new Cliente(null, null, null, null, null, null, null, null, 3);

                _context.Cliente.AddRange(c1, c2, c3);
            }
            



            /* adicionando no banco de dados usando entity framework*/
            

            _context.SaveChanges();
        }
    }
}
