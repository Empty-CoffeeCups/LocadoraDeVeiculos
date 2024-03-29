﻿CREATE TABLE [dbo].[TBFuncionario] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [Nome]          VARCHAR (50)    NOT NULL,
    [Usuario]       VARCHAR (50)    NOT NULL,
    [Senha]         VARCHAR (50)    NOT NULL,
    [DataDeEntrada] DATE            NOT NULL,
    [Salario]       DECIMAL (18, 2) NOT NULL,
    [Admin]         BIT             NOT NULL, 
    CONSTRAINT [PK_TBFuncionario] PRIMARY KEY ([Id])
);

