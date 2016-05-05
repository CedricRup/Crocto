Feature: End of game

@US004
@ignore	
Scenario: The village wins if all action of the ritual are done before the due date


	Given a ritual named "Crocto" with the following actions:
	| Action           | Workload |
	| Hunt an elephant | 1        |
		
	And a village named "Podunk" inhabited by
	| Villager |
	| Alice    |

	And the village "Podunk" must perform the "Crocto" ritual before the 13 day ends

	When the "Podunk" village plan for the day is:
	| Villager | Action           |
	| Alice    | Hunt an elephant |
		
	Then the "Podunk" village is safe!
	

@US004
@ignore	
Scenario: The village is eaten if the ritual is not performed before the due date


	Given a ritual named "Crocto" with the following actions:
	| Action              | Workload |
	| Hunting an elephant | 2        |
		
	And a village named "Podunk" inhabited by
	| Villager |
	| Alice    |

	And the village "Podunk" must perform the "Crocto" before the 1 day ends

	When the "Podunk" village plan for the day is:
	| Villager | Action              |
	| Alice    | Hunting an elephant |
	
	Then the whole "Podunk" village is eaten by the Crocto 

	
