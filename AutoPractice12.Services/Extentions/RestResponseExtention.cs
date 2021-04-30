using System;
using Newtonsoft.Json;
using RestSharp;

namespace AutoPractice12.Services.Extentions
{
    public static class RestResponseExtention
    {
        public static T As<T>(this IRestResponse response)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (JsonException ex)
            {
                throw new Exception("Response content contains not valid JSON data.", ex);
            }
        }

        public static IRestResponse EnsureSuccess(this IRestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed ||
                response.StatusCode >= System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception($"{response.StatusCode}. {response.ErrorMessage}, response was from uri {response.ResponseUri}");
            }

            return response;
        }
    }
}
