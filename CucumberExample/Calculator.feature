Feature: Calculator
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

Scenario: Handle negative nunmbers
	Given I have entered -50 into the calculator
	And I have entered +50 into the calculator
	When I press add
	Then the result should be 0 on the screen

Scenario: Handle Adding Three Numbers
Given I have entered the following set of values and expected results
| Value1 | Value2 | Value 3 | ExpectedResult |
| 1      | 2      | 3       | 6              |
| 1      | -2      | 3       | 2              |
When I add them all together
Then the result should be as expected