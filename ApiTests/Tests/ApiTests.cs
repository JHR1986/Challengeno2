// Necessary namespaces
using NUnit.Framework;
using RestSharp;
using System.Net;
using Newtonsoft.Json;

namespace ApiTests
{
    // Indicate that this is a test fixture containing test cases
    [TestFixture]
    public class ApiTests
    {
        // Declare a RestClient instance
        private RestClient _client;

        // Setup method to initialize the RestClient before each test
        [SetUp]
        public void Setup()
        {
            // Initialize RestClient with the base URL (provided in the challenge) for the API
            _client = new RestClient("https://jsonplaceholder.typicode.com");
        }

        // Teardown method to dispose of the RestClient after each test
        [TearDown]
        public void Teardown()
        {
            // Dispose of RestClient after each test
            _client?.Dispose();
        }

        // Test method for GET request
        [Test]
        public void GetPostById_ShouldReturnPost()
        {
            // Start by creating a GET request for the endpoint /posts/1
            var request = new RestRequest("/posts/1", Method.Get);
            // The execute the GET request
            var response = _client.ExecuteGet(request);

            // Then log the request and response
            TestContext.WriteLine("GET Request: /posts/1");
            TestContext.WriteLine($"Response Status: {response.StatusCode}");
            TestContext.WriteLine($"Response Content: {response.Content}");

            // The user can then verify that the status code is 200 (OK)
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            // Deserialize the response content to a Post object
            var post = JsonConvert.DeserializeObject<Post>(response.Content);

            // The user can also verify that the post is not null and contains the expected data
            Assert.That(post, Is.Not.Null);
            Assert.That(post?.Id, Is.EqualTo(1));
            Assert.That(post?.UserId, Is.Not.Null);
            Assert.That(post?.Title, Is.Not.Null);
            Assert.That(post?.Body, Is.Not.Null);
        }

        // Test method for POST request
        [Test]
        public void CreatePost_ShouldReturnCreatedPost()
        {
            // Start by creating a POST request for the endpoint /posts
            var request = new RestRequest("/posts", Method.Post);
            // Then add JSON body data for the new post
            request.AddJsonBody(new { userId = 1, title = "foo", body = "bar" });

            // Then execute the POST request
            var response = _client.ExecutePost(request);

            // Log the request and response
            TestContext.WriteLine("POST Request: /posts");
            TestContext.WriteLine("Request Body: {\"userId\": 1, \"title\": \"foo\", \"body\": \"bar\"}");
            TestContext.WriteLine($"Response Status: {response.StatusCode}");
            TestContext.WriteLine($"Response Content: {response.Content}");

            // Verify that the status code is 201 (Created)
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            // Deserialize the response content to a Post object
            var post = JsonConvert.DeserializeObject<Post>(response.Content);

            // Verify that the post is not null and contains the expected data
            Assert.That(post, Is.Not.Null);
            Assert.That(post?.UserId, Is.EqualTo(1));
            Assert.That(post?.Title, Is.EqualTo("foo"));
            Assert.That(post?.Body, Is.EqualTo("bar"));
        }

        // Test method for PUT request
        [Test]
        public void UpdatePost_ShouldReturnUpdatedPost()
        {
            // Start by creating a PUT request for the endpoint /posts/1
            var request = new RestRequest("/posts/1", Method.Put);
            // Add JSON body data for updating the post
            request.AddJsonBody(new { userId = 1, id = 1, title = "updated", body = "updated body" });

            // Execute the PUT request
            var response = _client.ExecutePut(request);

            // Log the request and response
            TestContext.WriteLine("PUT Request: /posts/1");
            TestContext.WriteLine("Request Body: {\"userId\": 1, \"id\": 1, \"title\": \"updated\", \"body\": \"updated body\"}");
            TestContext.WriteLine($"Response Status: {response.StatusCode}");
            TestContext.WriteLine($"Response Content: {response.Content}");

            // Verify that the status code is 200 (OK)
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            // Deserialize the response content to a Post object
            var post = JsonConvert.DeserializeObject<Post>(response.Content);

            // Verify that the post is not null and contains the expected data
            Assert.That(post, Is.Not.Null);
            Assert.That(post?.UserId, Is.EqualTo(1));
            Assert.That(post?.Id, Is.EqualTo(1));
            Assert.That(post?.Title, Is.EqualTo("updated"));
            Assert.That(post?.Body, Is.EqualTo("updated body"));
        }

        // Test method for DELETE request
        [Test]
        public void DeletePost_ShouldReturnNoContent()
        {
            // Start by creating a DELETE request for the endpoint /posts/1
            var request = new RestRequest("/posts/1", Method.Delete);

            // Execute the DELETE request
            var response = _client.Execute(request);

            // Log the request and response
            TestContext.WriteLine("DELETE Request: /posts/1");
            TestContext.WriteLine($"Response Status: {response.StatusCode}");
            TestContext.WriteLine($"Response Content: {response.Content}");

            // Verify that the status code is 200 (OK) or 204 (No Content)
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK).Or.EqualTo(HttpStatusCode.NoContent));
        }

        // Class to represent the structure of a Post
        public class Post
        {
            public int UserId { get; set; }
            public int Id { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
        }
    }
}