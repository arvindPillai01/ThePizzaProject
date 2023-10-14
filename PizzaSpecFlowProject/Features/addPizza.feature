Feature: addPizza

Adding pizza items to the cart after log in
@addingItem
#
# Scenario: User provides valid credentials
#    Given the user is on the login page
#    When the user enters valid username and password
#    And clicks the login button
#    Then they should be logged in successfully


Scenario: Adding a pizza to the cart after logging in
    Given the user is on the pizza ordering page
    When the user selects a pizza and adds it to the cart
    Then the pizza should be added to the cart

#Scenario: Adding multiple pizzas to the cart
#    Given the user is on the pizza ordering page
#    When the user selects multiple pizzas and adds them to the cart
#    Then all selected pizzas should be added to the cart