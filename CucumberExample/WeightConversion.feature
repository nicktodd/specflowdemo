Feature: WeightConversion
	In order to find out my imperial equivalent
	As somebody who knows their weight in kg
	I want to be told the weight in pounds

@WeightConversion
Scenario: Convert from kg to pounds
    Given The user has navigated to the website
	And They have entered 81 in the kg field
	When I press convert
	Then the result should be 178.5744 in the lb field
