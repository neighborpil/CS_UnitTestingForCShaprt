# CS_UnitTestingForCShaprt
Example codes of udemy course Unit Testing for C# Developers


=====================================
# Advantages of automated unit testing
 - reduces the bug
 - I can refactor without checking all related part manualy

# Types of tests
1. Unit test
 - testing an application **without** external dependencies like db, web services
 - cheap to write
 - execute fast
2. Integration test
 - testing an application **with** external dependencies like db, web services
3. End-to-end test
 - Drives an applicatioin through its UI
 - Like Selenium
 - Record the interaction of a user with out application and then play it back and 
   check if the application is returning the right result or not 
 - very slow
 - brittle. Small change can esaily break the teset
 
 # When should I use
 1. Unit test
  - Complex log
  - Calculation
 2. Integration test
  - simply reads some data and writes it to a database

# TDD fundamental
 - Write a failing test
 - Write the simplest code to make the test pass
 - Refacor if necessary

# Characteristics of Good Unit Tests
 - Clean, readable and maintainable
 - No logic, no conditional statments(if,else,foreach..)
 - Each test should be isolated
 - Not too specific/general

# What to test
 - Test the outcome of a method
 - Functions are seperated to 2 types

1. Query
 - Return some values
 - Should test and verify that function is returning the right value

2. Command
 - Performs an action, making a change in the system
 - May return values
 - Test outcome
 - Ex1. changing the state of memory
 - Ex2. Writing to a database
 - Ex3. Calling web services
 - Ex4. Sending a message que

 # What not to test
  - Language features(Don't test C# language features)
  - 3rd-party code

 # Test method structure
  - <pre>[MethodName]_[Scenario]_[ExpectedBehaviour]</pre>