ALTER TABLE Packages
ADD interest_scheme INT NOT NULL DEFAULT(1)
GO

UPDATE Packages SET interest_scheme = 1
GO

UPDATE Packages
   SET interest_scheme = 4 
   WHERE installment_type IN
   (SELECT id FROM InstallmentTypes WHERE nb_of_months = 1 AND nb_of_days = 0)
GO
   
UPDATE Packages
   SET interest_scheme = 2 
   WHERE installment_type IN
   (SELECT id FROM InstallmentTypes WHERE nb_of_months = 0 AND nb_of_days = 30)
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.2.0.0'
WHERE   [name] = 'VERSION'
GO
