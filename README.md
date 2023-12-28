Test Driven Development (TDD) is a powerful methodology that can lead to more maintainable and reliable code.

By writing tests first and then implementing the code to make those tests pass, we ensure that our code meets
the specified requirements and remains functional during future changes.

This project's structure and tests indicate a way of understanding basic TDD principles.
As we continue with our exploration of TDD, we may want to consider the following:

Edge Cases: Ensure that our tests cover various edge cases and boundary conditions to thoroughly validate
the behavior of our code.

Refactoring: After getting all tests to pass, we can consider refactoring our code while keeping the tests green.
This helps in maintaining a clean and well-structured codebase.

Test Readability: We try to make sure our test names clearly convey the behavior they are testing.
Well-named tests serve as documentation for our code.

Test Independence: Each test should be independent of others. We usually avoid creating dependencies between tests
to ensure that failures in one test don't affect others.

Continuous Integration: We consider setting up a continuous integration (CI) system to run our tests
automatically whenever changes are pushed to the repository.
