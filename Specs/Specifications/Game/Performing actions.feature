Feature: Working on an action

@US003
Scenario: When a villager is working on an action, the workload of this action goes down

	Given a ritual named "Crocto" with the following actions:
	| Action                | Workload |
	| Hunt an elephant      | 2        |
	| Tame a demonic rodent | 1        |
	
		
	And a village named "Podunk" inhabited by
	| Villager |
	| Alice    |

	And the village "Podunk" must perform the "Crocto" ritual

	When the "Podunk" village plan for the day is:
	| Villager | Action           |
	| Alice    | Hunt an elephant |

	Then the "Podunk" village has the following remaining actions to do:
	| Action                | workload |
	| Hunt an elephant      | 1        |
	| Tame a demonic rodent | 1        |
	
@US003
@ignore
Scenario: When nobody is doing an action, the workload of this action does not vary
	
	Given a ritual named "Crocto" with the following actions:
	| Action           | Workload |
	| Hunt an elephant | 2        |
		
	And a village named "Podunk" inhabited by
	| Villager |
	| Alice    |

	And the village "Podunk" must perform the "Crocto" ritual

	When the "Podunk" village plan for the day is:
	| Villager | Action              |
	
	Then the "Podunk" village has the following remaining actions to do:
	| Action           | workload |
	| Hunt an elephant | 2        |
	

@US003
@ignore
Scenario: A action is done when its workload reach 0

	Given a ritual named "Crocto" with the following actions:
	| Action              | Workload |
	| Hunting an elephant | 2        |
	| Summon a storm      | 1        |
		
	And a village named "Podunk" inhabited by
	| Villager |
	| Alice    |

	And the village "Podunk" must perform the "Crocto" ritual

	When the "Podunk" village plan for the day is:
	| Villager | Action         |
	| Alice    | Summon a storm |
	
	Then the "Podunk" village has the following remaining actions to do:
	| Action           | workload |
	| Hunt an elephant | 2        |
	   