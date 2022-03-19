CREATE TABLE [dbo].[Constant]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] VARCHAR(20) NOT NULL UNIQUE,
	[NumericValue] FLOAT, 
    [LiteralValue] VARCHAR(256),
	[ValueType] INT NOT NULL
)
