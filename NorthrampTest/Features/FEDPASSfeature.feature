Feature: FEDPASS
	Executing tests in FEDPASS 


@FEDPASS
Scenario: Test Login
	Given I open Chrome 
	And I navigate to FEDPASS
	Then I login

@FEDPASS
Scenario: Basic navigation
	Given I open Chrome
	And I navigate to FEDPASS
	Then I login
	And I navigate to "Resources" and "Resources/FundingAssignments" 

@FEDPASS
Scenario: Create Investment
	Given I open Chrome 
	And I navigate to FEDPASS
	Then I login
	And I navigate to "Portfolio" and "Portfolio/Investments"
	Then I create an Investment with title "Test Automation"

@FEDPASS
Scenario: Edit Investment
	Given I open Chrome 
	And I navigate to FEDPASS
	Then I login
	And I navigate to "Portfolio" and "Portfolio/Investments"
	Then I edit the Investment "Test Automation"

@FEDPASS
Scenario: Delete Investment
	Given I open Chrome 
	And I navigate to FEDPASS
	Then I login
	And I navigate to "Portfolio" and "Portfolio/Investments"
	Then I delete the Investment "Test Automation"

@FEDPASS
Scenario: Create Component
	Given I open Chrome 
	And I navigate to FEDPASS
	Then I login
	And I navigate to "Portfolio" and "Portfolio/Components"
	Then I create a Component with title "Test Automation"