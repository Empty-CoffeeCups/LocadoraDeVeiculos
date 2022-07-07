CREATE TABLE [dbo].[TBPlanoDeCobranca]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TipoDePlano] INT NOT NULL, 
    [ValorDiario] DECIMAL NOT NULL, 
    [ValorKmIncluso] DECIMAL NOT NULL, 
    [PrecoKmRodado] DECIMAL NOT NULL, 
    [GrupoDeVeiculos_Id] INT NOT NULL,
    CONSTRAINT [FK_TBPlanoDeCobranca_TBGrupoDeVeiculos] FOREIGN KEY ([GrupoDeVeiculos_Id]) REFERENCES [dbo].[TBGrupoDeVeiculos] ([Id])
)
