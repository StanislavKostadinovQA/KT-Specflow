@WebTable
Feature: WebTable
 You can write some description here.

Background: 
	 Given I Navigate to Web Table Page
	
Scenario Outline: Add New user to web table
	When I am on Web table page
	And I click the Add button
	And i should see the registration form
	And I enter a valid '<FirstName>', '<LastName>' , '<Email>' , '<Age>' , '<Salary>' , '<Department>'

 Examples:
 |  TestCase   | FirstName | LastName  | Email				      | Age | Salary | Department |
 |	TC - 001   | John      | Doe       | john.doe@example.com	  | 30  | 50000  | IT         |
 |  TC - 002   | Alice     | Smith     | alice.smith@example.com  | 25  | 60000  | Marketing  |
 |	TC - 003   | Bob       | Johnson   | bob.johnson@example.com  | 35  | 70000  | HR         |
 |  TC - 004   | Emma      | Williams  | emma.williams@example.com| 28  | 55000  | Finance    |	

 
 Scenario Outline: Edit existing User
	When I am on Web table page
	And I click the 'EditButton' button
	And i should see the registration form
	When I Change the firstname as '<name>'
	And I click the 'SubmitButton' button
	Then I should see the '<name>' into the '<element>' element

Examples: 
	| name      | element      |
	| Stanislav | WebTableRoll |



Scenario Outline: Delete user from table
	When I am on Web table page
	And I click the 'DeleteButton' button
	Then the user should be deleted