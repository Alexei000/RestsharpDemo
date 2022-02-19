using System;
using System.Threading.Tasks;
using FluentAssertions;
using RestSharp;
using RestsharpDemo.Base;
using TechTalk.SpecFlow;

namespace RestsharpDemo.Steps
{
    [Binding]
    public class GetPostsSteps
    {
        private readonly Settings _settings;

        public GetPostsSteps(Settings settings)
        {
            _settings = settings;
        }

        [Given(@"I perform GET operation for ""([^""]*)""")]
        public void GivenIPerformGetOperationFor(string url)
        {
            _settings.Client = new RestClient(_settings.BaseUrl);
            _settings.Request = new RestRequest(url);
        }

        [When(@"I perform operation or post ""([^""]*)""")]
        public async Task WhenIPerformOperationOrPost(int postId)
        {
            _settings.Request.AddUrlSegment("postid", postId);
            _settings.Response = await _settings.Client.ExecuteAsync<Post>(_settings.Request);
        }

        [Then(@"I should see the ""([^""]*)"" name as ""([^""]*)""")]
        public void ThenIShouldSeeTheNameAs(string key, string value)
        {
            _settings.Response.Data?.Author.Should().Be(value);
        }

    }
}
