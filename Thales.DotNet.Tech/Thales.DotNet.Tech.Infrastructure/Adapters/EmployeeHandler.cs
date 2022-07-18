using System.Net.Http.Headers;
using Newtonsoft.Json;
using Thales.DotNet.Tech.Infrastructure.Entities;

namespace Thales.DotNet.Tech.Infrastructure.Adapters;

public class EmployeeHandler : IEmployeeHandler
{
    private readonly IGeneralConfiguration _configuration;
    private ResponseEmployee? responseEmployee { get; set; }
    private Employee? getEmployee { get; set; }

    public EmployeeHandler(IGeneralConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<List<Employee>?> GetAsync()
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(_configuration.GetEmployees).ConfigureAwait(false);
        
        response.EnsureSuccessStatusCode();

        await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
        {
            if (x.IsFaulted)
                throw x.Exception;

            responseEmployee = JsonConvert.DeserializeObject<ResponseEmployee>(x.Result);

        });

        return responseEmployee.data.ToList();
    }

    public async Task<Employee?> GetByIdAsync(object id)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await httpClient.GetAsync($"{_configuration.GetEmployeeById}{id}").ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
        {
            if (x.IsFaulted)
                throw x.Exception;

            getEmployee = JsonConvert.DeserializeObject<Employee>(x.Result);

        });

        return getEmployee;
    }
}

public class GeneralConfiguration : IGeneralConfiguration
{
    public string GetEmployeeById { get; set; }
    public string GetEmployees { get; set; }
}

public interface IGeneralConfiguration
{
    string GetEmployeeById { get; set; }

    string GetEmployees { get; set; }
}