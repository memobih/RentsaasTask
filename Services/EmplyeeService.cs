using Microsoft.EntityFrameworkCore;
using RentsaasTask.DataTransferObjects;
using RentsaasTask.Interfaces;
using RentsaasTask.Models;
using System;

namespace RentsaasTask.Services
{
    public class EmployeeService : IEmployeeService
    {


        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<(IEnumerable<Employee>, int)> GetAllAsync(string? search, int page, int pageSize)
        {
            var query = _context.Employees
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                query = query.Where(e =>
                    e.FirstName.Contains(search) ||
                    e.LastName.Contains(search) ||
                    e.Email.Contains(search) ||
                    e.Position.Contains(search));
            }

            var totalCount = await query.CountAsync();

            var employees = await query
                .OrderBy(e => e.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(e => new Employee
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Position = e.Position
                })
                .ToListAsync();

            return (employees, totalCount);
        }


        public async Task<Employee?> GetByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return null;

            return employee;
        }

        public async Task<Employee> AddAsync(EmployeeDto dto)
        {
            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Position = dto.Position
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();


            return employee;
        }

        public async Task<bool> UpdateAsync(int id, EmployeeDto dto)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email;
            employee.Position = dto.Position;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
