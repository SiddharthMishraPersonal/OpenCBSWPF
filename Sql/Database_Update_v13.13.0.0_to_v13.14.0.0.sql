INSERT INTO [dbo].[Statuses] ([status_name]) VALUES ('Deleted')
INSERT INTO [dbo].[Statuses] ([status_name]) VALUES ('Non-accrual')
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v13.14.0.0'
WHERE   [name] = 'VERSION'
GO
