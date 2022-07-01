CREATE TABLE [dbo].[TBCliente] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Nome]          VARCHAR (50)  NOT NULL,
    [CPF]           VARCHAR (80)  NULL,
    [CNPJ]          VARCHAR (80)  NULL,
    [TipoDeCliente] VARCHAR (80)  NOT NULL,
    [CNH]           BIT           NOT NULL,
    [Endereco]      VARCHAR(200)  NOT NULL,
    [Email]         VARCHAR (100) NOT NULL,
    [Telefone]      VARCHAR (100) NOT NULL
);

