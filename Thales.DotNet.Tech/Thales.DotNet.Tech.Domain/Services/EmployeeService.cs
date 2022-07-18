using Thales.DotNet.Tech.Domain.Dto;
using Thales.DotNet.Tech.Infrastructure.Adapters;


namespace Thales.DotNet.Tech.Domain.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeHandler _handler;

    public EmployeeService(IEmployeeHandler handler)
    {
        _handler = handler;
    }
    public async Task<List<EmployeeDto>> GetAllEmployees()
    {
        List<EmployeeDto> listEmployeeDtos = new List<EmployeeDto>();

        try
        {
            var employess = await _handler.GetAsync();
            foreach (var employee in employess)
            {
                EmployeeDto employeeDto = new EmployeeDto
                {
                    Id = employee.Id,
                    EmployeeName = employee.employee_name,
                    EmployeeSalary = employee.employee_salary,
                    EmployeeAge = employee.employee_age,
                    ProfileImage = employee.profile_image,
                    EmployeeAnualSalary = employee.employee_salary * 12
                };
                listEmployeeDtos.Add(employeeDto);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return listEmployeeDtos;
    }

    public async Task<EmployeeDto?> GetEmployeeById(int id)
    {
        EmployeeDto employeeDto;

        try
        {
            var employee = await _handler.GetByIdAsync(id);
            employeeDto = new EmployeeDto
            {
                Id = employee.Id,
                EmployeeName = employee.employee_name,
                EmployeeSalary = employee.employee_salary,
                EmployeeAge = employee.employee_age,
                ProfileImage = employee.profile_image,
                EmployeeAnualSalary = employee.employee_salary * 12
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return employeeDto;
    }
}

public interface IEmployeeService
{
    Task<List<EmployeeDto>?> GetAllEmployees();

    Task<EmployeeDto?> GetEmployeeById(int id);
}