using Newtonsoft.Json;

namespace EmployeeApi.Models
{
    public class Employee
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Department { get; set; }
    }
}
