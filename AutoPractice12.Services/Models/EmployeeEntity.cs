using Newtonsoft.Json;

namespace AutoPractice12.Services.Models
{
    public class EmployeeEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("employee_name")]
        public string EmployeeName { get; set; }

        [JsonProperty("employee_salary")]
        public string EmployeeSalary { get; set; }

        [JsonProperty("employee_age")]
        public string EmployeeAge { get; set; }

        [JsonProperty("profile_image")]
        public string ProfileImage { get; set; }
    }
}
