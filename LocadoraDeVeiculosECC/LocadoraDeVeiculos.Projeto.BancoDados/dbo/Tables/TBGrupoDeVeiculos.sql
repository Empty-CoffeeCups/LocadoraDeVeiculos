CREATE TABLE [dbo].[TBGrupoDeVeiculos] (
    [Id]          UNIQUEIDENTIFIER  NOT NULL,
    [NomeDoGrupo] VARCHAR (50) NOT NULL, 
    CONSTRAINT [PK_TBGrupoDeVeiculos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

