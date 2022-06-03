using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PinguCheckIn.Models.Dtos;
using PinguCheckIn.Models.Enums;
using PinguCheckIn.Shared;

namespace PinguCheckIn.Negocio.Csv
{
    public class RelatoriosNegocio : NegocioBase
    {
        
        public FileDto GerarRelatorio(string status, string periodo)
        {
            int[] statusArray = new int[1];
            int[] statusArray2 = new int[3] { 1,2,3};
            DayOfWeek Day = DateTime.Now.DayOfWeek;
            int Days = Day - DayOfWeek.Sunday; //here you can set your Week Start Day
            DateTime WeekStartDate = new DateTime();
            DateTime WeekEndDate = new DateTime();
            List<RelatorioDto> result = new List<RelatorioDto>();
            DateTime diaHj = DateTime.Today;
            if (!status.Equals("N"))
            {
                statusArray[0] = int.Parse(status);
            }


            if (periodo.Equals("3")) // periodo semana
            {
                WeekStartDate = DateTime.Now.AddDays(-Days);
                WeekEndDate = WeekStartDate.AddDays(6);

                result = (from r in this.Contexto.Reserva
                          join c in this.Contexto.Cliente on r.IdCliente equals c.IdCliente
                          join u in this.Contexto.Usuario on c.IdUsuario equals u.IdUsuario
                          join q in this.Contexto.Quarto on r.IdQuarto equals q.IdQuarto
                          where r.DataReserva >= WeekStartDate && r.DataReserva <= WeekEndDate && (statusArray[0] != 0 ? statusArray.Contains(r.Status) : statusArray2.Contains(r.Status))
                          select new RelatorioDto()
                          {
                              IdReserva = r.IdReserva,
                              Nome = u.Nome,
                              Sobrenome = u.Sobrenome,
                              Quarto = q.Nome,
                              Entrada = r.DataEntrada,
                              Saida = r.DataSaida,
                              Status = r.Status,
                              StatusString = ((Status)r.Status).ToString(),
                              DataReserva = r.DataReserva,
                              Cpf = u.Cpf,
                              Email = u.Email,
                              ValorTotal = r.ValorTotal
                          }).ToList();
            }
            else if (periodo.Equals("2")) //periodo dia
            {

                var query = (from r in this.Contexto.Reserva
                          join c in this.Contexto.Cliente on r.IdCliente equals c.IdCliente
                          join u in this.Contexto.Usuario on c.IdUsuario equals u.IdUsuario
                          join q in this.Contexto.Quarto on r.IdQuarto equals q.IdQuarto
                          where (statusArray[0] != 0 ? statusArray.Contains(r.Status) : statusArray2.Contains(r.Status))
                          select new RelatorioDto()
                          {
                              IdReserva = r.IdReserva,
                              Nome = u.Nome,
                              Sobrenome = u.Sobrenome,
                              Quarto = q.Nome,
                              Entrada = r.DataEntrada,
                              Saida = r.DataSaida,
                              Status = r.Status,
                              StatusString = ((Status)r.Status).ToString(),
                              DataReserva = r.DataReserva,
                              Cpf = u.Cpf,
                              Email = u.Email,
                              ValorTotal = r.ValorTotal
                          }).ToList();

                result = query.Where(d => d.DataReserva.ToString("dd/MM/yyyy").Equals(diaHj.ToString("dd/MM/yyyy"))).ToList();
            }
           else if (periodo.Equals("4")) // periodo mes
            {
                var firstDayOfMonth = new DateTime(diaHj.Year, diaHj.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                result = (from r in this.Contexto.Reserva
                          join c in this.Contexto.Cliente on r.IdCliente equals c.IdCliente
                          join u in this.Contexto.Usuario on c.IdUsuario equals u.IdUsuario
                          join q in this.Contexto.Quarto on r.IdQuarto equals q.IdQuarto
                          where r.DataReserva >= firstDayOfMonth && r.DataReserva <= lastDayOfMonth && (statusArray[0] != 0 ? statusArray.Contains(r.Status) : statusArray2.Contains(r.Status))
                          select new RelatorioDto()
                          {
                              IdReserva = r.IdReserva,
                              Nome = u.Nome,
                              Sobrenome = u.Sobrenome,
                              Quarto = q.Nome,
                              Entrada = r.DataEntrada,
                              Saida = r.DataSaida,
                              Status = r.Status,
                              StatusString = ((Status)r.Status).ToString(),
                              DataReserva = r.DataReserva,
                              Cpf = u.Cpf,
                              Email = u.Email,
                              ValorTotal = r.ValorTotal
                          }).ToList();
            }

            else {
                // sem periodo nenhum
                result = (from r in this.Contexto.Reserva
                          join c in this.Contexto.Cliente on r.IdCliente equals c.IdCliente
                          join u in this.Contexto.Usuario on c.IdUsuario equals u.IdUsuario
                          join q in this.Contexto.Quarto on r.IdQuarto equals q.IdQuarto
                          where (statusArray[0] != 0 ? statusArray.Contains(r.Status) : statusArray2.Contains(r.Status))
                          select new RelatorioDto()
                          {
                              IdReserva = r.IdReserva,
                              Nome = u.Nome,
                              Sobrenome = u.Sobrenome,
                              Quarto = q.Nome,
                              Entrada = r.DataEntrada,
                              Saida = r.DataSaida,
                              Status = r.Status,
                              StatusString = ((Status)r.Status).ToString(),
                              DataReserva = r.DataReserva,
                              Cpf = u.Cpf,
                              Email = u.Email,
                              ValorTotal = r.ValorTotal
                          }).ToList();
            }

           



            var csvData = new StringBuilder();

            csvData.AppendLine("ID_RESERVA;NOME;SOBRENOME;QUARTO;ENTRADA;SAIDA;STATUS_RESERVA;DATA_RESERVA;CPF;EMAIL;VALOR_TOTAL;");


            foreach (var line in result)
            {
                csvData.AppendFormat(
                    "{0};{1};{2};{3};{4};{5};{6};{7};\t{8};{9};{10};",
                    line.IdReserva.GetValue(60),
                    line.Nome.GetValue(100).removerAcentos().ToUpper(),
                    line.Sobrenome.GetValue(100).removerAcentos().ToUpper(),
                    line.Quarto.GetValue(100).removerAcentos().ToUpper(),
                    line.Entrada.ToString("dd-MM-yyyy"),
                    line.Saida.ToString("dd-MM-yyyy"),
                    line.StatusString.GetValue(20),
                    line.DataReserva.ToString("dd-MM-yyyy"),
                    line.Cpf.GetValue(15),
                    line.Email.GetValue(100),
                    line.ValorTotal.ToString("F2")
                );
                csvData.AppendLine();
            }

            /*
             * (OutputData) => Gera o arquivo no formato esperado
             */
            FileDto file = new FileDto();


            file.FileName = "reservas_pingu.CSV";
            file.Path =
                @$"{Directory.GetCurrentDirectory() + "\\Relatorios\\"} {file.FileName}";


            File.WriteAllText(
                file.Path,
                csvData.ToString());



            return file;
        }


    }
}
