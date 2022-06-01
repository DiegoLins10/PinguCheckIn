using PinguCheckIn.Models.Dtos;
using PinguCheckIn.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Negocio.Historico
{
    public class HistoricoNegocio : NegocioBase
    {
        public List<ReservaDto> RetornarReservas(int idUsuario)
        {
                var buscar = (from usuario in Contexto.Usuario
                              join c in Contexto.Cliente on usuario.IdUsuario equals c.IdUsuario
                              join r in Contexto.Reserva on c.IdCliente equals r.IdCliente
                              join q in Contexto.Quarto on r.IdQuarto equals q.IdQuarto
                              join p in Contexto.Pagamentos on r.IdPagamento equals p.IdPagamento
                              where usuario.IdUsuario == idUsuario
                              select new ReservaDto
                              {
                                  IdReserva = r.IdReserva,
                                  Status = (Status)r.Status,
                                  StatusString = ((Status)r.Status).ToString(),
                                  Nome = q.Nome,
                                  Camas = q.QtdCamas,
                                  ValorTotal = r.ValorTotal,
                                  Valor = q.Valor,
                                  DataEntrada = r.DataEntrada,
                                  DataSaida = r.DataSaida,
                                  Foto = q.Imagem,
                                  DataReserva = r.DataReserva
                              }
                          ).ToList();


                return buscar;


            
        }

        public string CancelarReserva(int idReserva)
        {
            try
            {
                var reserva = this.Contexto.Reserva.Where(r => r.IdReserva == idReserva).FirstOrDefault();

                if (reserva == null)
                {
                    return "Reserva não encontrada";
                }

                reserva.Status = (int)Status.Cancelada;
                this.Contexto.SaveChanges();

                return "Cancelada com sucesso";
            }
            catch(Exception e)
            {
                return e.Message;
            }

           
        }
    }
}
