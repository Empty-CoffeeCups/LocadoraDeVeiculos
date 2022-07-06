CREATE TABLE [dbo].[TBPlanoDeCobranca]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TipoDePlano] INT NOT NULL, 
    [ValorDiario] DECIMAL NOT NULL, 
    [KmLivreIncluso] DECIMAL NOT NULL, 
    [PrecoKmRodado] DECIMAL NOT NULL, 
    [GrupoDeVeiculo_Id] INT NOT NULL,
     CONSTRAINT [FK_TBPlanoDeCobranca_TBGrupoDeVeiculos] FOREIGN KEY ([GrupoDeVeiculo_id]) REFERENCES [dbo].[TBGrupoDeVeiculos] ([Id])
)
