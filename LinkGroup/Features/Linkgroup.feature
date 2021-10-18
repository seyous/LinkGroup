Feature: Link Group

Scenario: Smoke test
	When I open the home page
	Then page is displayed

Scenario: Search results
	Given I have opened the page
	And I have agreed to the cookie policy
	When I search for "Leeds"
	Then the search results are displayed

Scenario Outline: Investment managers
	Given I have opened the Found Solution page
	When I view Funds
	Then I can select the investment managers for "<Jurisdiction>" investors

	Examples:
		| Jurisdiction |
		| UK           |
		| Irish        |
		| Swiss        |