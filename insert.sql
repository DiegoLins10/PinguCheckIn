USE [Pingu]
GO

INSERT INTO [dbo].[Reserva]
           ([DataEntrada]
           ,[DataSaida]
           ,[DataReserva]
           ,[ValorTotal]
           ,[Status]
           ,[IdCliente]
           ,[IdQuarto])
     VALUES
           ('19/06/2022'
           ,'22/06/2022'
           ,GETDATE()
           ,10000
           ,1
           ,2
           ,6)
GO


