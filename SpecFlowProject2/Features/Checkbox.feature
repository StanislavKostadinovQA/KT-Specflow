@checkbox
Feature: CheckBox page
 You can write some description here.

Background:
	Given I navigate to Check Box page

	Scenario Outline: Click on the checkboxes
		When I am on the CheckBox page
		And I click the 'ExpandButton' button on Checkbox Page
		And The document tree is expanded
		When I select document with name '<documentName>'
		Then I Should see an output Message

Examples: 
	| documentName	      |
	| DesktopFolder		  |
	| WorkspaceFolder     |
	| OfficeFolder        |
		 	