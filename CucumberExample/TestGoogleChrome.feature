Feature: TestGoogleChrome
	In order to search on Google
	As a consumer
	I want to be be able to search for items

@mytag
Scenario: Search for Java
	Given I search for Java
	When I press the search button
	Then the title should be Java in the browser
