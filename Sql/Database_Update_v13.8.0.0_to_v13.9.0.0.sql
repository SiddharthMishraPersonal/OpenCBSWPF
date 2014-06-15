DECLARE @default SYSNAME, @sql NVARCHAR(MAX)
SELECT @default = name 
FROM sys.default_constraints 
WHERE parent_object_id = object_id('dbo.ReschedulingOfALoanEvents')
AND TYPE = 'D'
AND parent_column_id = (
    SELECT column_id 
    FROM sys.columns 
    WHERE object_id = object_id('dbo.ReschedulingOfALoanEvents')
    and name = 'charge_interest_during_shift'
    )
SET @sql = N'alter table dbo.ReschedulingOfALoanEvents drop constraint ' + @default
EXEC sp_executesql @sql
ALTER TABLE dbo.ReschedulingOfALoanEvents DROP COLUMN charge_interest_during_shift
GO

ALTER TABLE dbo.ReschedulingOfALoanEvents ADD preferred_first_installment_date DATETIME NOT NULL DEFAULT(GETDATE())
GO

UPDATE dbo.ReschedulingOfALoanEvents
SET preferred_first_installment_date=
	DATEADD(dd, it.nb_of_days + re.date_offset, DATEADD(mm, it.nb_of_months, ce.event_date))
	FROM dbo.ReschedulingOfALoanEvents re
	LEFT JOIN dbo.ContractEvents ce ON ce.id=re.id
	LEFT JOIN dbo.Credit cr ON cr.id=ce.contract_id
	LEFT JOIN dbo.Packages pk ON pk.id=cr.package_id
	LEFT JOIN dbo.InstallmentTypes it ON it.id=pk.installment_type
GO

DECLARE @default SYSNAME, @sql NVARCHAR(MAX)
SELECT @default = name 
FROM sys.default_constraints 
WHERE parent_object_id = object_id('dbo.ReschedulingOfALoanEvents')
AND TYPE = 'D'
AND parent_column_id = (
    SELECT column_id 
    FROM sys.columns 
    WHERE object_id = object_id('dbo.ReschedulingOfALoanEvents')
    and name = 'date_offset'
    )
SET @sql = N'alter table dbo.ReschedulingOfALoanEvents drop constraint ' + @default
EXEC sp_executesql @sql
ALTER TABLE dbo.ReschedulingOfALoanEvents DROP COLUMN date_offset
GO
	
UPDATE  [TechnicalParameters]
SET     [value] = 'v13.9.0.0'
WHERE   [name] = 'VERSION'
GO