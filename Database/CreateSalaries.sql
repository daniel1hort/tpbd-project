CREATE PROCEDURE [dbo].[CreateSalaries]
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
			[Id],
			CAST([GrossSalary] AS FLOAT) * [PayRise] + CAST([BonusGrossSalary] AS FLOAT) AS [TotalGrossSalary],
			(SELECT [NumericValue] FROM [Constant] WHERE [Id] = 1) AS [Tax],
			(SELECT [NumericValue] FROM [Constant] WHERE [Id] = 2) AS [CAS],
			(SELECT [NumericValue] FROM [Constant] WHERE [Id] = 3) AS [CASS]
		FROM
			[dbo].[Employee]
		WHERE
			(SELECT Salary.[Id] 
			 FROM Salary 
			 WHERE EmployeeId = [Employee].[Id]
			 AND YEAR(Salary.ForMonth) = YEAR(@lastMonthDate)
			 AND MONTH(Salary.ForMonth) = MONTH(@lastMonthDate)) 
			IS NULL
	) T;

RETURN @@ROWCOUNT;
