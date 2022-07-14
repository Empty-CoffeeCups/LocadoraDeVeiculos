CREATE TABLE [dbo].[TBCliente] (
    [Id]            UNIQUEIDENTIFIER  NOT NULL,
    [Nome]          VARCHAR (50)  NOT NULL,
    [Documento]           VARCHAR (50)  NOT NULL,
    [TipoDeCliente] INT  NOT NULL,
    [Cnh]           VARCHAR(50)           NOT NULL,
    [Endereco]      VARCHAR(200)  NOT NULL,
    [Email]         VARCHAR (100) NOT NULL,
    [Telefone]      VARCHAR (100) NOT NULL, 
    CONSTRAINT [PK_TBCliente] PRIMARY KEY ([Id])
);

