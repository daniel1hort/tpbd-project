/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS(SELECT * FROM [dbo].[Constant] WHERE [Id] = 1)
    INSERT INTO [dbo].[Constant]([Id], [Name], [NumericValue], [ValueType])
    VALUES(1, 'Tax', 0.1, 0);
GO

IF NOT EXISTS(SELECT * FROM [dbo].[Constant] WHERE [Id] = 2)
    INSERT INTO [dbo].[Constant]([Id], [Name], [NumericValue], [ValueType])
    VALUES(2, 'CAS', 0.25, 0);
GO

IF NOT EXISTS(SELECT * FROM [dbo].[Constant] WHERE [Id] = 3)
    INSERT INTO [dbo].[Constant]([Id], [Name], [NumericValue], [ValueType])
    VALUES(3, 'CASS', 0.1, 0);
GO

IF NOT EXISTS(SELECT * FROM [dbo].[Constant] WHERE [Id] = 4)
    INSERT INTO [dbo].[Constant]([Id], [Name], [LiteralValue], [ValueType])
    VALUES(3, 'Password', 'Admin0099', 1);
GO