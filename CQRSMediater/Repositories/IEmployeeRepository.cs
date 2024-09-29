using CQRSMediater.Models;

namespace CQRSMediater.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetEmployeesListAsync();
        public Task<Employee> GetEmployeeByIdAsync(int id);
        public Task<Employee> AddEmployeeAsync(Employee employee);
        public Task<int> UpdateEmployeeAsync(Employee employee);
        public Task<int> DeleteEmployeeAsync(int id);
    }
}
