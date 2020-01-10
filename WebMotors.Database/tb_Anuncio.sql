CREATE TABLE [dbo].[tb_Anuncio]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Marca] VARCHAR(45) NOT NULL, 
    [Modelo] VARCHAR(45) NOT NULL, 
    [Versao] VARCHAR(45) NOT NULL, 
    [Ano] VARCHAR(45) NOT NULL, 
    [Quilometragem] INT NOT NULL, 
    [Observacao] VARCHAR(MAX) NOT NULL
)
