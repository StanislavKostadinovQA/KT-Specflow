@buttons
Feature: Buttons
This test scenarios covers some of the features on Buttons page. bla bla bla 

Background: 
	Given I navigate to Buttons page 

Scenario Outline: Buttons scenario name 
	When I am on the Buttons page
	And I click '<button>' on Buttons page
	Then I should see the '<message>'
		
Examples: 
	| button            | message            |
	| DoubleClickButton | DoubleClickMessage |
	| RightClickButton  | RightClickMessage  |
	| ClickMeButton     | ClickMeMessage     |