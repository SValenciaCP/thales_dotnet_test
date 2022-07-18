using System.Text.Json.Serialization;

namespace Thales.DotNet.Tech.Infrastructure.Entities;

public class Employee
{
    public Employee()
    {
    }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("employee_name")]
    public string employee_name { get; set; }


    [JsonPropertyName("employee_salary")]
    public int employee_salary { get; set; }

    [JsonPropertyName("employee_age")]
    public int employee_age { get; set; }

    [JsonPropertyName("profile_image")]
    public string profile_image { get; set; }

}