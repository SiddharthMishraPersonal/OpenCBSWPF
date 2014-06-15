UPDATE dbo.Credit
SET dbo.Credit.nb_of_installment = inst.num
FROM dbo.Credit
INNER JOIN (
SELECT contract_id, COUNT(contract_id) AS num
FROM dbo.Installments 
GROUP BY contract_id
) AS inst ON inst.contract_id = dbo.Credit.id
WHERE dbo.Credit.nb_of_installment != inst.num
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v13.11.0.0'
WHERE   [name] = 'VERSION'
GO
