SELECT
    c.id ContractId,
    c.contract_code ContractCode,
    COALESCE(p.first_name, g.name, corp.name, '') ClientFirstName,
    COALESCE(p.last_name, '') ClientLastName,
    COALESCE(p.father_name, '') ClientFatherName,
    d.name DistrictName,
    cr.amount Amount,
    ISNULL(olb.olb, 0) olb,
    c.status StatusCode,
    c.start_date StartDate,
    c.close_date CloseDate,
    cr.nb_of_installment NumberOfInstallments,
    pack.name LoanProductName,
    it.name InstallmentType,
    cr.interest_rate InterestRate
FROM dbo.Contracts c
LEFT JOIN dbo.Credit cr ON cr.id = c.id
LEFT JOIN dbo.Packages pack ON pack.id = cr.package_id
LEFT JOIN dbo.InstallmentTypes it ON it.id = pack.installment_type
LEFT JOIN dbo.Projects j ON j.id = c.project_id
LEFT JOIN dbo.Tiers t ON t.id = j.tiers_id
LEFT JOIN dbo.Districts d ON d.id = t.district_id
LEFT JOIN
(
    SELECT contract_id, SUM(capital_repayment - paid_capital) olb
    FROM dbo.Installments
    GROUP BY contract_id
) olb ON olb.contract_id = c.id
LEFT JOIN dbo.Persons p ON p.id = j.tiers_id
LEFT JOIN dbo.Groups g ON g.id = j.tiers_id
LEFT JOIN dbo.Corporates corp ON corp.id = j.tiers_id
WHERE cr.loanofficer_id = @Id
