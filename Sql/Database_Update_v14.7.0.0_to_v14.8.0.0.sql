update Credit 
set interest_rate = cr.interest_rate * FLOOR(365 / (it.nb_of_months*30 + it.nb_of_days))
from Credit cr
left join InstallmentTypes it on it.id = cr.installment_type
GO

update Packages
set interest_rate = p.interest_rate * FLOOR(365 / (it.nb_of_months*30 + it.nb_of_days)),
	interest_rate_min = p.interest_rate_min * FLOOR(365 / (it.nb_of_months*30 + it.nb_of_days)),
	interest_rate_max = p.interest_rate_max * FLOOR(365 / (it.nb_of_months*30 + it.nb_of_days))
from Packages p
left join InstallmentTypes it on it.id = p.installment_type
GO

update ReschedulingOfALoanEvents
set previous_interest_rate = re.previous_interest_rate * FLOOR(365 / (it.nb_of_months*30 + it.nb_of_days)),
	interest = re.interest * FLOOR(365 / (it.nb_of_months*30 + it.nb_of_days))
from ReschedulingOfALoanEvents re
left join ContractEvents ce on ce.id = re.id
left join Credit cr on cr.id = ce.contract_id
left join InstallmentTypes it on it.id = cr.installment_type
GO

update TrancheEvents
set interest_rate = tr.interest_rate * FLOOR(365 / (it.nb_of_months*30 + it.nb_of_days))
from TrancheEvents tr
left join ContractEvents ce on ce.id = tr.id
left join Credit cr on cr.id = ce.contract_id
left join InstallmentTypes it on it.id = cr.installment_type
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.8.0.0'
WHERE   [name] = 'VERSION'
GO