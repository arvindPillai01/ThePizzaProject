Feature: Login

As a user
I want to login to my account
So that I can access the application
@login
  Scenario: User provides valid credentials
    Given the user is on the login page
    When the user enters valid username and password
    And clicks the login button
    Then they should be logged in successfully
