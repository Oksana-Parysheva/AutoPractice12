using System;
using System.Collections.Generic;
using AutoPractice12.Common;
using AutoPractice12.Database;
using NUnit.Framework;
using RestSharp;

namespace AutoPractice12.Tests
{
    [SetUpFixture]
    public class BaseFixture
    {
        private IRestClient _client;

        protected IRestClient Client
            => _client ?? (_client = new RestClient("http://dummy.restapiexample.com/api/v1/")
                   .AddDefaultHeader("Accept-Encoding", "gzip, deflate")
                   .AddDefaultHeader("Accept", "application/json")
                   .AddDefaultHeader("Accept-Language", "ru,en-US;q=0.9,en;q=0.8,ru-RU;q=0.7"));

        [OneTimeSetUp]
        public void SetupDatabase()
        {
            ConfigurationProvider.GetCurrent();
        }
    }
}