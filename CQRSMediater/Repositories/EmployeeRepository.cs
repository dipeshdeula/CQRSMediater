using CQRSMediater.Data;
using CQRSMediater.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediater.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var result = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var filteredData = _context.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (filteredData != null)
            {
                _context.Employees.Remove(filteredData);

            }
            return await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var filteredData = await _context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();

            return filteredData;



        }

        public async Task<List<Employee>> GetEmployeesListAsync()
        {
            var filteredData = await _context.Employees.ToListAsync();
            
                return filteredData;

            

        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync();
        }
    }
}
