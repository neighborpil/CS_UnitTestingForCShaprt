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
