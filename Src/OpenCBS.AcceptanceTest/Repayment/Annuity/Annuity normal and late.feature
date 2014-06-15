Feature: Annuity normal and late

Scenario: Simple early repayment

    Given these settings
        | Name							| Value   |
        | USE_CENTS						| Yes     |
        | INCREMENTAL_DURING_DAYOFFS	| Yes     |
        | ACCOUNTING_PROCESS			| Accrual |
        | USE_DAILY_ACCRUAL_OF_PENALTY  | False   |
    And the "ANNUITY" loan product

    When I create a loan
        | Name                   | Value      |
        | Installments           | 12         |
        | Amount                 | 45000      |
        | Interest rate          | 42		  | 
        | Grace period           | 0          |
        | Rounding               | End        |   
        | Start date             | 25.03.2014 |
        | First installment date | 25.04.2014 |
    And I set line of credit limit to 1000000
    And I disburse on 25.03.2014
    
	Then the schedule is
        | Number | Expected date | Expected interest | Expected principal | Expected total | Olb      | Paid principal | Paid interest |
        | 1      | 25.04.2014    | 1575,00           | 3081,78            | 4656,78        | 45000,00 | 0              | 0             |
        | 2      | 26.05.2014    | 1467,14           | 3189,64            | 4656,78        | 41918,22 | 0              | 0             |
        | 3      | 25.06.2014    | 1355,50           | 3301,28            | 4656,78        | 38728,58 | 0              | 0             |
        | 4      | 25.07.2014    | 1239,96           | 3416,82            | 4656,78        | 35427,30 | 0              | 0             |
        | 5      | 25.08.2014    | 1120,37           | 3536,41            | 4656,78        | 32010,48 | 0              | 0             |
        | 6      | 25.09.2014    | 996,59            | 3660,19            | 4656,78        | 28474,07 | 0              | 0             |
        | 7      | 27.10.2014    | 868,49            | 3788,29            | 4656,78        | 24813,88 | 0              | 0             |
        | 8      | 25.11.2014    | 735,90            | 3920,88            | 4656,78        | 21025,59 | 0              | 0             |
        | 9      | 25.12.2014    | 598,66            | 4058,12            | 4656,78        | 17104,71 | 0              | 0             |
        | 10     | 26.01.2015    | 456,63            | 4200,15            | 4656,78        | 13046,59 | 0              | 0             |
        | 11     | 25.02.2015    | 309,63            | 4347,15            | 4656,78        | 8846,44  | 0              | 0             |
        | 12     | 25.03.2015    | 157,48            | 4499,29            | 4656,77        | 4499,29  | 0              | 0             |	

    # Repay one installments on time and expected amount
    When I repay 4656,78 on 25.04.2014

	Then the schedule is
        | Number | Expected date | Expected interest | Expected principal | Expected total | Olb      | Paid principal | Paid interest |
        | 1      | 25.04.2014    | 1575,00           | 3081,78            | 0		       | 45000,00 | 3081,78        | 1575,00       |
        | 2      | 26.05.2014    | 1467,14           | 3189,64            | 4656,78        | 41918,22 | 0              | 0             |
        | 3      | 25.06.2014    | 1355,50           | 3301,28            | 4656,78        | 38728,58 | 0              | 0             |
        | 4      | 25.07.2014    | 1239,96           | 3416,82            | 4656,78        | 35427,30 | 0              | 0             |
        | 5      | 25.08.2014    | 1120,37           | 3536,41            | 4656,78        | 32010,48 | 0              | 0             |
        | 6      | 25.09.2014    | 996,59            | 3660,19            | 4656,78        | 28474,07 | 0              | 0             |
        | 7      | 27.10.2014    | 868,49            | 3788,29            | 4656,78        | 24813,88 | 0              | 0             |
        | 8      | 25.11.2014    | 735,90            | 3920,88            | 4656,78        | 21025,59 | 0              | 0             |
        | 9      | 25.12.2014    | 598,66            | 4058,12            | 4656,78        | 17104,71 | 0              | 0             |
        | 10     | 26.01.2015    | 456,63            | 4200,15            | 4656,78        | 13046,59 | 0              | 0             |
        | 11     | 25.02.2015    | 309,63            | 4347,15            | 4656,78        | 8846,44  | 0              | 0             |
        | 12     | 25.03.2015    | 157,48            | 4499,29            | 4656,77        | 4499,29  | 0              | 0             |	

    # Force to repay installment #2 earlier
    When I repay 4656,78 on 20.05.2014

	Then the schedule is
        | Number | Expected date | Expected interest | Expected principal | Expected total | Olb      | Paid principal | Paid interest |
        | 1      | 25.04.2014    | 1575,00           | 3081,78            | 0		       | 45000,00 | 3081,78        | 1575,00       |
        | 2      | 26.05.2014    | 1467,14           | 3189,64            | 0              | 41918,22 | 3189,64        | 1467,14       |
        | 3      | 25.06.2014    | 1355,50           | 3301,28            | 4656,78        | 38728,58 | 0              | 0             |
        | 4      | 25.07.2014    | 1239,96           | 3416,82            | 4656,78        | 35427,30 | 0              | 0             |
        | 5      | 25.08.2014    | 1120,37           | 3536,41            | 4656,78        | 32010,48 | 0              | 0             |
        | 6      | 25.09.2014    | 996,59            | 3660,19            | 4656,78        | 28474,07 | 0              | 0             |
        | 7      | 27.10.2014    | 868,49            | 3788,29            | 4656,78        | 24813,88 | 0              | 0             |
        | 8      | 25.11.2014    | 735,90            | 3920,88            | 4656,78        | 21025,59 | 0              | 0             |
        | 9      | 25.12.2014    | 598,66            | 4058,12            | 4656,78        | 17104,71 | 0              | 0             |
        | 10     | 26.01.2015    | 456,63            | 4200,15            | 4656,78        | 13046,59 | 0              | 0             |
        | 11     | 25.02.2015    | 309,63            | 4347,15            | 4656,78        | 8846,44  | 0              | 0             |
        | 12     | 25.03.2015    | 157,48            | 4499,29            | 4656,77        | 4499,29  | 0              | 0             |

    # Force to repay 10000 in automatic mode.
	# When we force to repay in automatic mode, it means the system has to spread entered amount over installments according to 
	# embeded script logic.
	# This script automated logic says to take amounts in this order:
	# 1. Comission
	# 2. Penalties accrued
	# 3. Interest for the #First active installment
	# 4. Principal for the #First active installment
	# 5. Interest for the #First+1 active installment# 
	# 6. Principal for the #First+1 active installment
	# 7. Repeat steps 5 and 6 increasing numer of active installment till amount is more than zero

	# In our case:
	# 1. Commission = 0

	When I accrue_penalties 0

	# 2. Penalties accrued = 0
	# 3. First active installment is #3. Interest for this installment is 1355,50 and it is less than amount remaining (10000)
	# 4. First active installment is #3. Principal for this installment is 3301,28 and it is less than amount remaining (8644,5)
	# 5. First+1 active installment is #4. Interest for this installment is 1239,96 and it is less than amount remaining (5343,22)
	# 6. First+1 active installment is #4. Principal for this installment is 3416,82 and it is less than amount remaining (4103,26)
	# 7. First+2 active installment is #5. Interest for this installment is 1120,37 and it is alread more than amount remaining (686,44)
	# so it means we just put this 686,44 as paid interest for the installment #5
	
	When I repay 10000 on 25.06.2014

	Then the schedule is
        | Number | Expected date | Expected interest | Expected principal | Expected total | Olb      | Paid principal | Paid interest |
        | 1      | 25.04.2014    | 1575,00           | 3081,78            | 0		       | 45000,00 | 3081,78        | 1575,00       |
        | 2      | 26.05.2014    | 1467,14           | 3189,64            | 0              | 41918,22 | 3189,64        | 1467,14       |
        | 3      | 25.06.2014    | 1355,50           | 3301,28            | 0              | 38728,58 | 3301,28        | 1355,50       |
        | 4      | 25.07.2014    | 1239,96           | 3416,82            | 0              | 35427,30 | 3416,82        | 1239,96       |
        | 5      | 25.08.2014    | 1120,37           | 3536,41            | 3970,34        | 32010,48 | 0              | 686,44        |
        | 6      | 25.09.2014    | 996,59            | 3660,19            | 4656,78        | 28474,07 | 0              | 0             |
        | 7      | 27.10.2014    | 868,49            | 3788,29            | 4656,78        | 24813,88 | 0              | 0             |
        | 8      | 25.11.2014    | 735,90            | 3920,88            | 4656,78        | 21025,59 | 0              | 0             |
        | 9      | 25.12.2014    | 598,66            | 4058,12            | 4656,78        | 17104,71 | 0              | 0             |
        | 10     | 26.01.2015    | 456,63            | 4200,15            | 4656,78        | 13046,59 | 0              | 0             |
        | 11     | 25.02.2015    | 309,63            | 4347,15            | 4656,78        | 8846,44  | 0              | 0             |
        | 12     | 25.03.2015    | 157,48            | 4499,29            | 4656,77        | 4499,29  | 0              | 0             |

    # Force to repay 10000 in custom mode.
	# When we force to repay in custom mode, it means the system has to spread entered amounts over installments according to 
	# defined way. 
	# We would like to spread amounts as:
	# 1. Commission = 1000

	When I accrue_penalties 300

	# 2. Penalties = 300
	# 3. Interest = 3000
	# 4. Principal = 5700

	# NOTE: We don't have collumns for penalties and commission in the schedule for the time being, so in this test we just don't indicate 
	# them inside the schedule

	# So, the logic is simple, we just go installment by installment and fill them in with the mounts till zero

	When I repay 10000 on 20.08.2014 with 1000 for commission with 300 for penalties with 3000 for interest

	Then the schedule is
        | Number | Expected date | Expected interest | Expected principal | Expected total | Olb      | Paid principal | Paid interest |
        | 1      | 25.04.2014    | 1575,00           | 3081,78            | 0		       | 45000,00 | 3081,78        | 1575,00       |
        | 2      | 26.05.2014    | 1467,14           | 3189,64            | 0              | 41918,22 | 3189,64        | 1467,14       |
        | 3      | 25.06.2014    | 1355,50           | 3301,28            | 0              | 38728,58 | 3301,28        | 1355,50       |
        | 4      | 25.07.2014    | 1239,96           | 3416,82            | 0              | 35427,30 | 3416,82        | 1239,96       |
        | 5      | 25.08.2014    | 1120,37           | 3536,41            | 0              | 32010,48 | 3536,41        | 1120,37       |
        | 6      | 25.09.2014    | 996,59            | 3660,19            | 1496,60        | 28474,07 | 2163,59        | 996,59        |
        | 7      | 27.10.2014    | 868,49            | 3788,29            | 3788,29        | 24813,88 | 0              | 868,49        |
        | 8      | 25.11.2014    | 735,90            | 3920,88            | 3955,79        | 21025,59 | 0              | 700,99        |
        | 9      | 25.12.2014    | 598,66            | 4058,12            | 4656,78        | 17104,71 | 0              | 0             |
        | 10     | 26.01.2015    | 456,63            | 4200,15            | 4656,78        | 13046,59 | 0              | 0             |
        | 11     | 25.02.2015    | 309,63            | 4347,15            | 4656,78        | 8846,44  | 0              | 0             |
        | 12     | 25.03.2015    | 157,48            | 4499,29            | 4656,77        | 4499,29  | 0              | 0             |

	# We got a bit weird schedule.
	# Now we wanna make automatic repayment again for 100000.
	# Let's follow automatic schema explained before.
	
	# In our case:
	# 1. Commission = 0

	When I accrue_penalties 500

	# 2. Penalties accrued = 500
	# 3. First active installment is #6. Interest for this installment is 0 and it is less than amount remaining (9500)
	# 4. First active installment is #6. Principal for this installment is 1496,60 and it is less than amount remaining (9500)
	# 5. First+1 active installment is #7. Interest for this installment is 0 and it is less than amount remaining (8003,40)
	# 6. First+1 active installment is #7. Principal for this installment is 3788,29 and it is less than amount remaining (8003,40)
	# 7. First+2 active installment is #8. Interest for this installment is 34,91 and it is less than amount remaining (4215,11)
	# 8. First+2 active installment is #8. Principal for this installment is 3920,88 and it is less than amount remaining (4180,2)
	# 8. First+3 active installment is #9. Interest for this installment is 598,66 and it is already more than amount remaining (259,32)
	# That 259.32 goes to interest of the installment #9
	
	When I repay 10000 on 27.01.2015
	
	Then the schedule is
        | Number | Expected date | Expected interest | Expected principal | Expected total | Olb      | Paid principal | Paid interest |
        | 1      | 25.04.2014    | 1575,00           | 3081,78            | 0		       | 45000,00 | 3081,78        | 1575,00       |
        | 2      | 26.05.2014    | 1467,14           | 3189,64            | 0              | 41918,22 | 3189,64        | 1467,14       |
        | 3      | 25.06.2014    | 1355,50           | 3301,28            | 0              | 38728,58 | 3301,28        | 1355,50       |
        | 4      | 25.07.2014    | 1239,96           | 3416,82            | 0              | 35427,30 | 3416,82        | 1239,96       |
        | 5      | 25.08.2014    | 1120,37           | 3536,41            | 0              | 32010,48 | 3536,41        | 1120,37       |
        | 6      | 25.09.2014    | 996,59            | 3660,19            | 0              | 28474,07 | 3660,19        | 996,59        |
        | 7      | 27.10.2014    | 868,49            | 3788,29            | 0              | 24813,88 | 3788,29        | 868,49        |
        | 8      | 25.11.2014    | 735,90            | 3920,88            | 0              | 21025,59 | 3920,88        | 735,90        |
        | 9      | 25.12.2014    | 598,66            | 4058,12            | 4397,46        | 17104,71 | 0              | 259,32        |
        | 10     | 26.01.2015    | 456,63            | 4200,15            | 4656,78        | 13046,59 | 0              | 0             |
        | 11     | 25.02.2015    | 309,63            | 4347,15            | 4656,78        | 8846,44  | 0              | 0             |
        | 12     | 25.03.2015    | 157,48            | 4499,29            | 4656,77        | 4499,29  | 0              | 0             |

	# Let's make total repayment without changing the schedule
	# Total amount to be paid is 18367,79

	When I repay 18367,79 on 30.01.2015
	
	Then the schedule is
        | Number | Expected date | Expected interest | Expected principal | Expected total | Olb      | Paid principal | Paid interest |
        | 1      | 25.04.2014    | 1575,00           | 3081,78            | 0		       | 45000,00 | 3081,78        | 1575,00       |
        | 2      | 26.05.2014    | 1467,14           | 3189,64            | 0              | 41918,22 | 3189,64        | 1467,14       |
        | 3      | 25.06.2014    | 1355,50           | 3301,28            | 0              | 38728,58 | 3301,28        | 1355,50       |
        | 4      | 25.07.2014    | 1239,96           | 3416,82            | 0              | 35427,30 | 3416,82        | 1239,96       |
        | 5      | 25.08.2014    | 1120,37           | 3536,41            | 0              | 32010,48 | 3536,41        | 1120,37       |
        | 6      | 25.09.2014    | 996,59            | 3660,19            | 0              | 28474,07 | 3660,19        | 996,59        |
        | 7      | 27.10.2014    | 868,49            | 3788,29            | 0              | 24813,88 | 3788,29        | 868,49        |
        | 8      | 25.11.2014    | 735,90            | 3920,88            | 0              | 21025,59 | 3920,88        | 735,90        |
        | 9      | 25.12.2014    | 598,66            | 4058,12            | 0              | 17104,71 | 4058,12        | 598,66        |
        | 10     | 26.01.2015    | 456,63            | 4200,15            | 0              | 13046,59 | 4200,15        | 456,63        |
        | 11     | 25.02.2015    | 309,63            | 4347,15            | 0              | 8846,44  | 4347,15        | 309,63        |
        | 12     | 25.03.2015    | 157,48            | 4499,29            | 0              | 4499,29  | 4499,29        | 157,48        |
	