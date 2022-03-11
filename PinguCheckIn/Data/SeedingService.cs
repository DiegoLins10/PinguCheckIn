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

            Usuario us1 = new Usuario("diegolins10", "teste10", "Diego Fernandes Lins", "diego.lins@fatec.sp.gov.br", "24053232813", "180037808", "11987549239", true); 
            Usuario us2 = new Usuario("vini10", "teste10", "Vinicius Oliveira", "Vinicius.Oliveira@fatec.sp.gov.br", "24033332813", "180337808", "1166667779", true); 
            Usuario us3 = new Usuario("nathan10", "teste10", "Nathan Silva", "Nathan@fatec.sp.gov.br", "24444232813", "180222808", "11966669239", true);



            /* adicionando no banco de dados usando entity framework*/
            _context.Usuario.AddRange(us1, us2, us3);

            _context.SaveChanges();
        }
    }
}
