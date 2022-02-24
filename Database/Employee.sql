CREATE TABLE [dbo].[Employee]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[JobTitle] VARCHAR(50) NOT NULL,
	[GrossSalary] MONEY NOT NULL,
	[PayRise] FLOAT DEFAULT 1,
	[BonusGrossSalary] MONEY DEFAULT 0,
	[Deductions] MONEY DEFAULT 0,
	[Picture] VARBINARY(MAX),

	CONSTRAINT [U_Name] UNIQUE([FirstName], [LastName]),
)
