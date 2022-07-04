CREATE TABLE [dbo].[TBCondutor]
(
	[Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Nome]       VARCHAR (150) NOT NULL,
    [CPF]        VARCHAR (80)  NOT NULL,
    [CNH]        VARCHAR (80)  NOT NULL,
    [ValidadeCnh]   DATE     NOT NULL,
    [Email]      VARCHAR (200) NOT NULL,
    [Telefone]   VARCHAR (50)  NOT NULL,
    [Endereco]   VARCHAR (200) NOT NULL,
    [Cliente_Id] INT           NOT NULL,
    CONSTRAINT [PK_TBCondutor] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBCondutor_TBCliente] FOREIGN KEY ([Cliente_Id]) REFERENCES [dbo].[TBCliente] ([Id])
)
