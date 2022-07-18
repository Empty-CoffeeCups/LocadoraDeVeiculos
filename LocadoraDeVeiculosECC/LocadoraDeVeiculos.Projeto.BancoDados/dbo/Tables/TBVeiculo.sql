CREATE TABLE [dbo].[TBVeiculo]
(
	[Id]            UNIQUEIDENTIFIER  NOT NULL,
    [GrupoDeVeiculos] UNIQUEIDENTIFIER NOT NULL,
	[Modelo] VARCHAR(50) NOT NULL, 
    [Marca] VARCHAR(50) NOT NULL, 
    [Placa] VARCHAR(50) NOT NULL, 
    [Cor] VARCHAR(50) NOT NULL, 
    [TipoCombustivel] INT NOT NULL, 
    [CapacidadeDoTanque] INT NOT NULL, 
    [Ano] DATE NOT NULL, 
    [KmPercorrido] INT NOT NULL, 
    [Foto] VARBINARY(MAX) NOT NULL, 
     

    CONSTRAINT [PK_TBVeiculo] PRIMARY KEY ([Id])
)
