﻿CREATE TABLE [dbo].[TBTaxas] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [Descricao] VARCHAR (250)   NOT NULL,
    [Valor]     DECIMAL (18, 2) NOT NULL, 
    [TipoCalculo] INT NOT NULL
    CONSTRAINT [PK_TBTaxa] PRIMARY KEY CLUSTERED ([Id] ASC)
);

