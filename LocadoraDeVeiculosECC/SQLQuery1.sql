SELECT
	[Id],
	[Descricao],
	[Valor]
FROM
	[TBTaxas]

DELETE FROM [TBTaxas]
	WHERE
		[Id] = 1

UPDATE [TBTaxas]	
	SET
		[Descricao] = 'Taxa de Teste Editada',
		[Valor] = 'Valor Editado'
	WHERE
		[Id] = 1

INSERT INTO [TBTaxas]
(

	[Descricao],
	[Valor]	
)
VALUES
(
	'Taxa de Teste',
	'9999,99 R$'
)