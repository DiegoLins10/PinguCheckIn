﻿using PinguCheckIn.Models.Dtos;
using PinguCheckIn.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Negocio.Reservas
{
    public class ReservaNegocio : NegocioBase
    {
        public string Reservar(ReservaDto reserva)
        {
            try
            {
                var clienteId = this.Contexto.Cliente.Where(d => d.IdUsuario == reserva.IdUsuario).Select(d => d.IdCliente).FirstOrDefault();
                Pagamento p = new Pagamento(reserva.NomeCartao, reserva.NumeroCartao, reserva.Dataexp, reserva.Cvv, reserva.Aceito, reserva.Nome, reserva.Sobrenome, reserva.Email, reserva.Endereco, reserva.Endereco2, reserva.Pais, reserva.Estado, reserva.Cep, reserva.TipoPagamento, clienteId);
                this.Contexto.Add(p);
                this.Contexto.SaveChanges();

                var idPagamento = this.Contexto.Pagamentos.Where(d => d.IdCliente == clienteId).OrderByDescending(x => x.IdPagamento).FirstOrDefault();
                Reserva r = new Reserva(reserva.DataEntrada, reserva.DataSaida, DateTime.Now, reserva.ValorTotal, 1, clienteId, reserva.IdQuarto, idPagamento.IdPagamento);
                this.Contexto.Add(r);
                this.Contexto.SaveChanges();

                return "Sucesso";
            }
            catch(Exception e)
            {
                return e.Message;
            }


        }
    }
}