using RentsaasTask.DataTransferObjects;
using RentsaasTask.Models;

namespace RentsaasTask.Interfaces
{
    public interface IEmployeeService

    {
        Task<(IEnumerable<Employee> employees, int totalCount)> GetAllAsync(string? search, int page, int pageSize);
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee> AddAsync(EmployeeDto dto);
        Task<bool> UpdateAsync(int id, EmployeeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
