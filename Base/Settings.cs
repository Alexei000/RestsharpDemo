using System;
using RestSharp;

namespace RestsharpDemo.Base
{
    public class Settings
    {
        public Uri BaseUrl { get; set; } = new("http://localhost:3000");
        public RestClient Client = new();
        public RestRequest Request = new();
        public RestResponse<Post> Response = new();
    }
}
