Feature: Ritual creation
	
@US002
Scenario: A ritual has a name and some actions
	Given my ritual is named "AshkEnte"
	And my ritual is composed of these actions
	| Action                         | Workload |
	| Drink a thimble of mouse blood | 1        |
	When I create my ritual
	Then the ritual creation is a success
	And ritual "AshkEnte" has the following actions
	| Action                         | Workload |
	| Drink a thimble of mouse blood | 1        |


	