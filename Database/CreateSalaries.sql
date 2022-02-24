﻿CREATE PROCEDURE [dbo].[CreateSalaries]
AS
	DECLARE @lastMonthDate DATE;
	SET @lastMonthDate = DATEADD(MONTH, -1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1));

	INSERT INTO [dbo].[Salary](
		[EmployeeId],
		[ForMonth],
		[TotalGrossSalary],
		[TotalTaxableSalary],
		[Tax],
		[CAS],
		[CASS],
		[NetSalary])
	SELECT 
		[Id],
		@lastMonthDate,
		[TotalGrossSalary],
		[TotalGrossSalary] * (1 - [CAS] - [CASS]),
		[TotalGrossSalary] * (1 - [CAS] - [CASS]) * [Tax],
		[TotalGrossSalary] * [CAS],
		[TotalGrossSalary] * [CASS],
		[TotalGrossSalary] * (1 - [CAS] - [CASS]) * (1 - [Tax])
	FROM(
		SELECT
			*,
			CAST([GrossSalary] AS FLOAT) * [PayRise] + CAST([BonusGrossSalary] AS FLOAT) AS [TotalGrossSalary],
			(SELECT [Value] FROM [Constant] WHERE [Id] = 1) AS [Tax],
			(SELECT [Value] FROM [Constant] WHERE [Id] = 2) AS [CAS],
			(SELECT [Value] FROM [Constant] WHERE [Id] = 3) AS [CASS]
		FROM
			[dbo].[Employee]
	) T;

RETURN @@ROWCOUNT;
