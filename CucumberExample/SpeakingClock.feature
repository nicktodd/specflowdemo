Feature: SpeakingClock
	In order to get the time as a text
	I want to be able to pass in a Datetime 
	So that I can get a suitable String back for speaking
	
@mytag
Scenario: ConvertMidnightToText
	Given the time is 0 hours and 0 minutes
	When I request the time
	Then the result should be a time of midnight


Scenario: ConvertMiddayToText
	Given the time is 12 hours and 0 minutes
	When I request the time
	Then the result should be a time of midday



Scenario: ConvertMultipleTimesToText
	Given I have been provided this set of times and expected results
		| Hours | Minutes | ExpectedText |
		| 0     | 0       | midnight     |
		| 12    | 0       | midday       |
	When I request all the times as text
	Then all the text should match