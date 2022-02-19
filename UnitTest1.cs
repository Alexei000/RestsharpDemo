using System.Collections.Generic;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using Xunit;

namespace RestsharpDemo
{
    public class UnitTest1
    {
        [Fact]
        public async void FirstGetTest()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/{postid}");
            request.AddUrlSegment("postid", 1);

            string content = (await client.ExecuteAsync(request)).Content;

            var output = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
            output["author"].Should().Be("Karthik KK");
        }

        [Fact]
        public async void PostWithAnonymousBody()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts/{postid}/profile", Method.Post)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddBody(new { name = "Raj" });
            request.AddUrlSegment("postid", 1);

            var response = await client.ExecuteAsync(request);
            var output = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            var result = output["name"];

            result.Should().Be("Raj");
        }

        [Fact]
        public async void PostWithTypedBody()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts", Method.Post)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddBody(new Post { Id = 15, Author = "Anon", Title = "Some demo course"});

            var response = await client.ExecutePostAsync<Post>(request);

            response.Data?.Author?.Should()?.Be("Anon");
        }
    }
}
