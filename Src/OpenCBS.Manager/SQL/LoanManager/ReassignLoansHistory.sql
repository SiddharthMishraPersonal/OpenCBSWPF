INSERT INTO dbo.ContractAssignHistory (loanofficerTo_id, loanofficerFrom_id, contract_id)
SELECT @To, cr.loanofficer_id, c.id
FROM dbo.Contracts c
LEFT JOIN dbo.Credit cr ON cr.id = c.id
WHERE c.id IN @Ids