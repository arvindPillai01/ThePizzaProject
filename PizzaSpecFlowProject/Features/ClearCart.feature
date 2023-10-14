Feature: Clear Cart

As a user
I want to clear the items from my cart
So that I can start a fresh order

Scenario: User clears the cart
    Given the user is on the cart page
    When the user clicks the clear cart button
    Then the cart should be empty