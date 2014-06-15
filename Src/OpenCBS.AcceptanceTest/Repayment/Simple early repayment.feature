Feature: Simple early repayment

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
        | Amount                 | 10000      |
        | Interest rate          | 0,03       |
        | Grace period           | 0          |
        | Rounding               | End        |   
        | Start date             | 11.06.2013 |
        | First installment date | 11.07.2013 |
    And I set line of credit limit to 100000
    And I disburse on 11.06.2013
    
    Then the schedule is
        | Number | Expected date | Expected interest | Expected principal | Expected total | Olb    | Paid principal | Paid interest |
        | 1      | 11.07.2013    | 300               | 705                | 1005           | 10000  | 0              | 0             |
        | 2      | 12.08.2013    | 279               | 726                | 1005           | 9295   | 0              | 0             |
        | 3      | 11.09.2013    | 257               | 748                | 1005           | 8569   | 0              | 0             |
        | 4      | 11.10.2013    | 235               | 770                | 1005           | 7821   | 0              | 0             |
        | 5      | 11.11.2013    | 212               | 793                | 1005           | 7051   | 0              | 0             |
        | 6      | 11.12.2013    | 188               | 817                | 1005           | 6258   | 0              | 0             |
        | 7      | 13.01.2014    | 163               | 842                | 1005           | 5441   | 0              | 0             |
        | 8      | 11.02.2014    | 138               | 867                | 1005           | 4599   | 0              | 0             |
        | 9      | 11.03.2014    | 112               | 893                | 1005           | 3732   | 0              | 0             |
        | 10     | 11.04.2014    | 85                | 920                | 1005           | 2839   | 0              | 0             |
        | 11     | 12.05.2014    | 58                | 947                | 1005           | 1919   | 0              | 0             |
        | 12     | 11.06.2014    | 29                | 972                | 1001           | 972    | 0              | 0             |

    # Repay one installments on time and expected amount
    When I repay 2010 on 11.07.2013

    Then the schedule is
        | Number | Expected date | Expected interest | Expected principal | Expected total | Olb    | Paid principal | Paid interest |
        | 1      | 11.07.2013    | 300               | 705                | 0	           | 10000  | 705            | 300           |
        | 2      | 12.08.2013    | 279               | 726                | 0	           | 9295   | 726            | 279           |
        | 3      | 11.09.2013    | 257               | 748                | 1005           | 8569   | 0              | 0             |
        | 4      | 11.10.2013    | 235               | 770                | 1005           | 7821   | 0              | 0             |
        | 5      | 11.11.2013    | 212               | 793                | 1005           | 7051   | 0              | 0             |
        | 6      | 11.12.2013    | 188               | 817                | 1005           | 6258   | 0              | 0             |
        | 7      | 13.01.2014    | 163               | 842                | 1005           | 5441   | 0              | 0             |
        | 8      | 11.02.2014    | 138               | 867                | 1005           | 4599   | 0              | 0             |
        | 9      | 11.03.2014    | 112               | 893                | 1005           | 3732   | 0              | 0             |
        | 10     | 11.04.2014    | 85                | 920                | 1005           | 2839   | 0              | 0             |
        | 11     | 12.05.2014    | 58                | 947                | 1005           | 1919   | 0              | 0             |
        | 12     | 11.06.2014    | 29                | 972                | 1001           | 972    | 0              | 0             |

	# Client comes on 22.08.2013 and repays 4500 in advance with NO_KEEP_SCHEDULE
	# Step 1: To calculate accrued interest. In our case client used days between 12.08.2013 (means starting from 13.08.2013) and 22.08.2013
	# it means. client used 10 days. So, accrued interest will be 8569*36%/360*10=85.69 -> Rounded to 86
	# Step 2: The total amount client pays is 4500, so 4500-86=4414 goes to principal, new OLB will be 8569-4414=4155
	# Step 3: To calculate interest between 22.08.2013 till 11.09.2013, 4155*36%/360*20=83.1 -> Rounded to 83

	# Repay one installments on time and expected amount
    When I repay 4500 on 22.08.2013 with no keep schedule 

    Then the schedule is
        | Number | Expected date | Expected interest | Expected principal | Expected total | Olb   | Paid principal | Paid interest |
        | 1      | 11.07.2013    | 300               | 705                | 0              | 10000 | 705            | 300           |
        | 2      | 12.08.2013    | 279               | 726                | 0              | 9295  | 726            | 279           |
        | 3      | 22.08.2013    | 86                | 4414               | 0              | 8569  | 4414           | 86            |
        | 4      | 11.09.2013    | 83	             | 362                | 487            | 4155  | 0              | 0             |
        | 5      | 11.10.2013    | 114               | 373                | 487            | 3793  | 0              | 0             |
        | 6      | 11.11.2013    | 103               | 384                | 487            | 3420  | 0              | 0             |
        | 7      | 11.12.2013    | 91                | 396                | 487            | 3036  | 0              | 0             |
        | 8      | 13.01.2014    | 79                | 408                | 487            | 2640  | 0              | 0             |
        | 9      | 11.02.2014    | 67                | 420                | 487            | 2232  | 0              | 0             |
        | 10     | 11.03.2014    | 54                | 433                | 487            | 1812  | 0              | 0             |
        | 11     | 11.04.2014    | 41                | 446                | 487            | 1379  | 0              | 0             |
        | 12     | 12.05.2014    | 28                | 459                | 487            | 933   | 0              | 0             |
        | 13     | 11.06.2014    | 14                | 474                | 488            | 474   | 0              | 0             |
