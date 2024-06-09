@textbox
Feature: TextBox
 You can write some description here.

Background: 
	 Given I Navigate to Text Box Page
	
Scenario Outline: Text box page
	When I enter my Full Name as '<fullname>'
	And I enter my Email as '<email>'
	And I enter my current address as '<currentAddress>'
	And i Enter my Permanent address as '<permanentAddress>'
	And I click the 'SubmitButton' button
	Then i see my details displayed

Examples: 
    | TestCaseId | fullname    | email             | currentAddress | permanentAddress |
    | TC_001     | Stanislav   | dada@com.com      | somewhere      | here             |
    | TC_002     | John Doe    | john@example.com  |  Main St    |  Elm St       |
    | TC_003     | Jane Smith  | jane@gmail.com    |  Oak Ave    |  Oak Ave      |
    | TC_004     | Alice Brown | alice@gmail.com   |  Pine St    |  Maple St     |
   
@BobTag
Examples: 
    | TestCaseId | fullname    | email             | currentAddress | permanentAddress |
    | TC_005     | Bob Johnson | bob@yahoo.com     |  Cedar St   | Birch St     |
  