using RestSharp;

namespace AutoPractice12.Services.Endpoints
{
    public static class EmployeeEndpoint
    {
        public static RestRequest GetAllEmployees()
            => new RestRequest("employees", Method.GET);

        public static RestRequest GetEmployee(int id)
            => new RestRequest($"employee/{id}", Method.GET);
    }
}
