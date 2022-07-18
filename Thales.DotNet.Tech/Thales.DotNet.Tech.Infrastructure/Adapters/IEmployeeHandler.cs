using Thales.DotNet.Tech.Infrastructure.Entities;

namespace Thales.DotNet.Tech.Infrastructure.Adapters;

public interface IEmployeeHandler
{
    Task<List<Employee>?> GetAsync();

    Task<Employee?> GetByIdAsync(object id);

}