use pingu

select * from Reserva
where DataEntrada < '17/06/2022' and '14/06/2022' < dataSaida


select * from Cliente c
inner join Usuario u on c.IdUsuario = u.IdUsuario 


select * from Quarto