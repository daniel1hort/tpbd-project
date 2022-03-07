CREATE VIEW [dbo].[EmployeeSalaries] AS 
	SELECT
		[Employee].[Id] AS EmployeeId,
		[FirstName],
		[LastName],
		[JobTitle],
		[GrossSalary],
		[PayRise],
		[BonusGrossSalary],
		[Deductions],
		[Salary].[Id] AS SalaryId,
		[EmitedAt],
		[ForMonth],
		[TotalGrossSalary],
		[TotalTaxableSalary],
		[Tax],
		[CAS],
		[CASS],
		[NetSalary]
	FROM [Employee]
	INNER JOIN [Salary] ON [Salary].[EmployeeId] = [Employee].[Id]


