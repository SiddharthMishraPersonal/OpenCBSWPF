UPDATE 	tiers
SET 	city = cities.name
FROM 	dbo.Tiers tiers, dbo.City cities
WHERE 	(tiers.city = cities.name)
GO

INSERT INTO [dbo].[EventTypes]([event_type],[description],[sort_order]) VALUES('MSCE','Manual Schedule Change Event',720)

INSERT INTO dbo.ActionItems ([class_name],[method_name]) VALUES ('LoanServices','ManualScheduleBeforeDisbursement')
DECLARE @actionId INT
SELECT @actionId = SCOPE_IDENTITY()
INSERT INTO dbo.AllowedRoleActions ([action_item_id],[role_id],[allowed]) VALUES (@actionId,1,'true')
INSERT INTO dbo.AllowedRoleActions ([action_item_id],[role_id],[allowed]) VALUES (@actionId,2,'true')
INSERT INTO dbo.AllowedRoleActions ([action_item_id],[role_id],[allowed]) VALUES (@actionId,3,'true')
INSERT INTO dbo.AllowedRoleActions ([action_item_id],[role_id],[allowed]) VALUES (@actionId,4,'true')
INSERT INTO dbo.AllowedRoleActions ([action_item_id],[role_id],[allowed]) VALUES (@actionId,5,'false')

INSERT INTO dbo.ActionItems ([class_name],[method_name]) VALUES ('LoanServices','ManualScheduleAfterDisbursement')
SET @actionId = SCOPE_IDENTITY()
INSERT INTO dbo.AllowedRoleActions ([action_item_id],[role_id],[allowed]) VALUES (@actionId,1,'true')
INSERT INTO dbo.AllowedRoleActions ([action_item_id],[role_id],[allowed]) VALUES (@actionId,2,'true')
INSERT INTO dbo.AllowedRoleActions ([action_item_id],[role_id],[allowed]) VALUES (@actionId,3,'true')
INSERT INTO dbo.AllowedRoleActions ([action_item_id],[role_id],[allowed]) VALUES (@actionId,4,'true')
INSERT INTO dbo.AllowedRoleActions ([action_item_id],[role_id],[allowed]) VALUES (@actionId,5,'false')
GO

DELETE FROM dbo.AllowedRoleActions
WHERE action_item_id = (SELECT id from dbo.ActionItems where method_name = 'CanUserEditRepaymentSchedule')
GO

DELETE FROM dbo.ActionItems
WHERE method_name = 'CanUserEditRepaymentSchedule'
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v13.7.0.0'
WHERE   [name] = 'VERSION'
GO
