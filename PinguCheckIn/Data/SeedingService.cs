using PinguCheckIn.Models;
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
            if (_context.Usuario.Any())
            {
                return; // DB já foi populado
            }

            Usuario us1 = new Usuario("diego.lins@fatec.sp.gov.br", "teste10", "Diego", "Fernandes Lins", "24053232813", "180037808", "11987549239", DateTime.Now, true); 
            Usuario us2 = new Usuario("Vinicius.Oliveira@fatec.sp.gov.br", "teste10", "Vinicius", " Oliveira", "24033332813", "180337808", "1166667779", DateTime.Now, true); 
            Usuario us3 = new Usuario("Nathan@fatec.sp.gov.br", "teste10", "Nathan", "Silva", "24444232813", "180222808", "11966669239", DateTime.Now, true);



            /* adicionando no banco de dados usando entity framework*/
            _context.Usuario.AddRange(us1, us2, us3);

            _context.SaveChanges();
        }
    }
}
