Challenge 2: API Testing
------------------------

This challenge test demonstrates how to create and execute API tests using NUnit to validate a RESTful API. 
The tests that I completed were performed on the JSONPlaceholder API.

Prerequisites
-------------

-   .NET SDK (I downloaded this and updated the PATH to connect it to my VSCode IDE)

-   NuGet packages:

    -   NUnit

    -   RestSharp

    -   Newtonsoft.Json

Overview of what I completed for the test:
------------------

1.  I installed the items mentioned above

2.  I installed the necessary packages

Test Cases
----------

1.  **GET Request:**

    -   Endpoint: `/posts/1`

    -   Items I confirmed:

        -   Verify the response status code is `200 OK`.

        -   Verify the response body contains the expected post data (e.g., `userId`, `id`, `title`, `body`).

2.  **POST Request:**

    -   Endpoint: `/posts`

    -   Request Body:

        json

        ```
        {
          "userId": 1,
          "title": "foo",
          "body": "bar"
        }

        ```

    -   Items I confirmed:

        -   Verify the response status code is `201 Created`.

        -   Verify the response body contains the details of the newly created post.

3.  **PUT Request:**

    -   Endpoint: `/posts/1`

    -   Request Body:

        json

        ```
        {
          "userId": 1,
          "id": 1,
          "title": "updated",
          "body": "updated body"
        }

        ```

    -   Items I confirmed:

        -   Verify the response status code is `200 OK`.

        -   Verify the response body contains the updated post details.

4.  **DELETE Request:**

    -   Endpoint: `/posts/1`

    -   Items I confirmed:

        -   Verify the response status code is `200 OK` or `204 No Content`.

        -   Verify the response body.

Logging
-------

I ensured that each test case included logs of the requests and responses. 
These logs are correctly printed in the test output.

Running the Tests
-----------------

To run the tests, I used the following command:

sh

```
dotnet test

```

Test Results
------------

The test results are displayed in the console output. 
I also coded it so that I could also generate a detailed test report using the NUnit console runner:

sh

```
dotnet test --logger "trx;LogFileName=TestResults.xml"

```

Project Structure
-----------------

This is the project structure I created, setting out the folders and files:

```
MyApiProject/
├── src/
│   ├── MyApiProject/
│   │   ├── Controllers/
│   │   ├── Models/
│   │   ├── Services/
│   │   └── ...
├── tests/
│   ├── MyApiProject.Tests/
│   │   ├── ApiTests.cs
│   │   └── ...

```

Logs
----

I ensured that request and response logs are captured in the output of each test case.

In summary, I ensured that I achieved every stage of the test, and that it was running successfully.