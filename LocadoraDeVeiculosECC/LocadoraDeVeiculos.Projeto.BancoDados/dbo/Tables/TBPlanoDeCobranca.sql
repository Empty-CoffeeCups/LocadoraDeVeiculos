CREATE TABLE [dbo].[TBPlanoDeCobranca]
(
	[Id]          INT         IDENTITY(1,1) NOT NULL, 
    [TipoDePlano] VARCHAR(50) NOT NULL, 
    [ValorDiario] DECIMAL NOT NULL, 
    [ValorKmIncluso] DECIMAL NOT NULL, 
    [PrecoKmRodado] DECIMAL NOT NULL, 
    [GrupoDeVeiculos_Id] INT NOT NULL,
    CONSTRAINT [PK_TBPlanoDeCobranca] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBPlanoDeCobranca_TBGrupoDeVeiculos] FOREIGN KEY ([GrupoDeVeiculos_Id]) REFERENCES [dbo].[TBGrupoDeVeiculos] ([Id])
)
