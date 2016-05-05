Feature: Village creation

@US001
Scenario: A village village has a name and some villagers
	Given my village is named "Podunk"
	And my village is inhabited by
	| Villager |
	| Alice    |
	When I create my village
	Then the village creation is a success
	And village "Podunk" is inhabited by
	| Villager |
	| Alice    |